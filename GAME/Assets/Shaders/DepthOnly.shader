Shader "Custom/DepthOnly"
{
    SubShader
    {
        // Force into the Geometry render queue (before normal transparent)
        Tags { "Queue" = "Geometry+10" "RenderType"="Opaque" }

        Pass
        {
            // Write to depth buffer as if fully opaque
            ZWrite On
            ZTest LEqual
            ColorMask 0  // don't draw any color

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

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
                // Just here to satisfy the pipeline; no color output
                return 0;
            }
            ENDCG
        }
    }
}
