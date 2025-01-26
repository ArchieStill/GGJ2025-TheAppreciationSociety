Shader "Custom/TransparentColor"
{
    Properties
    {
        _Color("Tint", Color) = (0.0, 0.6, 1.0, 0.4)
    }
    SubShader
    {
        // Normal Transparent queue so it renders after Geometry
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        Pass
        {
            // Don’t write depth here; just do normal alpha blending
            ZWrite Off
            ZTest LEqual
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            float4 _Color;

            struct appdata
            {
                float4 vertex : POSITION;
            };
            struct v2f
            {
                float4 pos : SV_POSITION;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                return _Color;
            }
            ENDCG
        }
    }
}
