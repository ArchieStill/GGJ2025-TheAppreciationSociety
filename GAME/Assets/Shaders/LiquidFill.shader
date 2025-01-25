Shader "Custom/LiquidFill"
{
    Properties
    {
        _Color      ("Tint Color", Color)  = (0, 0.5, 1, 1)
        _FillHeight ("Fill Height", float) = 0.0
    }

    SubShader
    {
        // Render after opaque objects. We can keep "Queue"="Transparent" if we want partial transparency
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 200

        CGPROGRAM
        // Use a Surface Shader with alpha support
        #pragma surface surf Standard alpha:fade
        #pragma target 3.0

        struct Input
        {
            // We'll sample the world‐space position to decide if it's above or below _FillHeight
            float3 worldPos;
        };

        float4 _Color;
        float  _FillHeight;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Base color of the liquid
            o.Albedo = _Color.rgb;

            // If the pixel is above the fill level, make it fully transparent (discard)
            if (IN.worldPos.y > _FillHeight)
            {
                // Setting alpha to 0 basically hides (cuts out) anything above the fill level.
                o.Alpha = 0;
            }
            else
            {
                // Below the fill level, use the color's alpha (default = 1, or tweak in Inspector)
                o.Alpha = _Color.a;
            }

            // Optionally adjust smoothness, metallic, etc. for a watery look:
            o.Smoothness = 0.8;  // some reflectivity
            o.Metallic   = 0.0;
        }
        ENDCG
    }

    // Fallback helps if the hardware can't do this shader. "Transparent/Cutout/VertexLit" or "Diffuse"
    Fallback "Transparent/Cutout/VertexLit"
}
