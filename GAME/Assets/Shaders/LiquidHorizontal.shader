Shader "Custom/LiquidHorizontal"
{
    Properties
    {
        // Base liquid color & alpha
        _Color ("Liquid Color", Color) = (0, 0.4, 1, 0.9)

        // The global fill height (in world Y). Liquid is visible below this plane.
        _GlobalFill ("Global Fill Height", Float) = 0.0

        // Wave parameters
        _WaveAmplitude ("Wave Amplitude", Float) = 0.05
        _WaveFrequency ("Wave Frequency", Float) = 2.0
        _WaveSpeed     ("Wave Speed", Float)     = 1.0

        // Fresnel power for rim effect
        _FresnelPower ("Fresnel Power", Float)   = 2.0

        // Refraction distortion amount
        _RefractionAmount ("Refraction Distortion", Float) = 0.02
    }

    // We do a GrabPass to capture the background behind this object.
    SubShader
    {
        // 1) Copy screen behind object into _GrabTexture
        GrabPass { "_GrabTexture" }

        // 2) Main pass
        // Force transparency so we can discard above the fill plane & fade edges
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }

        // Turn OFF backface culling so we can see top and inside faces
        Cull Off

        LOD 2000

        CGPROGRAM
        // A Surface Shader with alpha blending, custom vertex, custom final color
        #pragma surface surf Standard alpha:fade finalcolor:finalColor vertex:vert
        #pragma target 3.0

        // We'll sample the screen texture for refraction
        sampler2D _GrabTexture;

        // Access Unity's built-in time
        // float4 _Time; //

        // Inspector properties
        float4 _Color;
        float  _GlobalFill;
        float  _WaveAmplitude;
        float  _WaveFrequency;
        float  _WaveSpeed;
        float  _FresnelPower;
        float  _RefractionAmount;

        struct Input
        {
            float3 worldPos;    // World-space position
            float3 worldNormal; // World-space normal
            float4 screenPos;   // For grabPass refraction
            INTERNAL_DATA
        };

        // Optional vertex modifier, if needed. We'll keep it trivial here.
        void vert(inout appdata_full v)
        {
            // No changes to the vertices themselves, but you could animate them.
        }

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            // Our wave offset depends on x,z in world space
            float time       = _Time.y * _WaveSpeed;
            float waveOffset =
                sin((IN.worldPos.x + time) * _WaveFrequency) * _WaveAmplitude +
                sin((IN.worldPos.z - time * 0.5) * _WaveFrequency * 0.7) * (_WaveAmplitude * 0.5);

            // If the worldPos.y is above _GlobalFill + wave, discard (alpha=0)
            if (IN.worldPos.y > (_GlobalFill + waveOffset))
            {
                o.Albedo = 0;
                o.Alpha  = 0;
            }
            else
            {
                // Below the fill plane, we show the liquid
                o.Albedo  = _Color.rgb;
                o.Alpha   = _Color.a; // partially transparent
                o.Metallic   = 0.0;
                o.Smoothness = 0.9;   // quite reflective
            }
        }

        // finalColor is called after lighting. Great for Fresnel & refraction.
        void finalColor(Input IN, SurfaceOutputStandard o, inout half4 color)
        {
            // If alpha=0, there's nothing to show
            if (color.a <= 0.0)
                return;

            // Compute a Fresnel factor
            float3 viewDir = normalize(_WorldSpaceCameraPos - IN.worldPos);
            float3 normal  = normalize(IN.worldNormal);
            float fresnel  = pow(1.0 - saturate(dot(viewDir, normal)), _FresnelPower);

            // Basic refraction: offset the screen UV by the normal
            float2 screenUV = IN.screenPos.xy / IN.screenPos.w;
            screenUV += normal.xy * _RefractionAmount;

            // Sample the background from the grab texture
            float4 refracted = tex2D(_GrabTexture, screenUV);

            // Mix between the surface color and the refracted background
            // Weighted by Fresnel, so edges distort more
            half4 mixColor = lerp(color, refracted, fresnel * 0.7);

            // Keep the same alpha from the surface
            color.rgb = mixColor.rgb;
        }
        ENDCG
    }
    Fallback "Transparent/Cutout/VertexLit"
}
