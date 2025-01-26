Shader "Custom/LiquidAdvanced"
{
    Properties
    {
        // Basic liquid color (tint). Alpha controls overall transparency.
        _Color ("Liquid Color", Color) = (0, 0.5, 1, 0.7)

        // The local-space height at which liquid becomes "empty" above.
        _LocalFill ("Local Fill Height", Float) = 0.0

        // Wave controls
        _WaveAmplitude ("Wave Amplitude", Float) = 0.1
        _WaveFrequency ("Wave Frequency", Float) = 2.0
        _WaveSpeed     ("Wave Speed", Float)     = 1.0

        // Fresnel power: higher = tighter "rim" effect
        _FresnelPower ("Fresnel Power", Float)   = 2.0

        // Refraction amount: how much we distort the background GrabPass
        _RefractionAmount ("Refraction Distortion", Float) = 0.02
    }

    // Grab the screen behind the object for refraction
    SubShader
    {
        // This pass copies the screen into _GrabTexture BEFORE we draw the main pass
        GrabPass { "_GrabTexture" }

        // Our main pass for the liquid
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 200

        CGPROGRAM
        // A Surface Shader with alpha blending and a custom final color step:
        #pragma surface surf Standard alpha:fade vertex:vert finalcolor:finalColor
        #pragma target 3.0

        // We'll sample the screen (grab) texture in the finalColor function
        sampler2D _GrabTexture;

        // Surface Shader input structure
        struct Input
        {
            float3 worldPos;    // built-in world position
            float4 screenPos;   // for computing UV into the grab texture
            float3 worldNormal; // surface normal in world space
            INTERNAL_DATA
        };

        // Inspector properties
        float4 _Color;
        float  _LocalFill;
        float  _WaveAmplitude;
        float  _WaveFrequency;
        float  _WaveSpeed;
        float  _FresnelPower;
        float  _RefractionAmount;

        // This vertex function allows us to pass custom data or do manipulations.
        // Here, we just keep it minimal, but we do want localPos in the pixel shader,
        // so we'll transform worldPos back into local space.
        void vert(inout appdata_full v)
        {
            // No changes needed to v.vertex here, but you *could* animate the mesh, etc.
        }

        // Our main Surface function (called per-pixel after the vertex stage).
        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            // Convert the world position to local space
            float3 localPos = mul(unity_WorldToObject, float4(IN.worldPos, 1.0)).xyz;

            // Compute a simple wave offset in local XZ, based on time
            float time = _Time.y * _WaveSpeed;
            float wave =
                sin((localPos.x + time) * _WaveFrequency) * _WaveAmplitude +
                sin((localPos.z + time) * _WaveFrequency * 0.5) * (_WaveAmplitude * 0.5);

            // If above the fill plane + wave offset, set alpha = 0 (transparent)
            if (localPos.y > (_LocalFill + wave))
            {
                o.Albedo = 0;
                o.Alpha  = 0;
            }
            else
            {
                // Below the fill, use the chosen color
                o.Albedo = _Color.rgb;
                o.Alpha  = _Color.a;

                // Basic PBR parameters for a watery look (tweak as desired)
                o.Metallic  = 0.0;
                o.Smoothness= 0.9;  // quite reflective
            }
        }

        // Final color modification, after lighting, to apply refraction + Fresnel
        void finalColor(Input IN, SurfaceOutputStandard o, inout half4 color)
        {
            // If alpha=0, skip (it's invisible above the fill)
            if (color.a <= 0.0)
                return;

            // A simple Fresnel factor (0 at center, 1 at grazing angles)
            float3 viewDir = normalize(_WorldSpaceCameraPos - IN.worldPos);
            float3 normal  = normalize(IN.worldNormal);
            float fresnel  = pow(1.0 - saturate(dot(viewDir, normal)), _FresnelPower);

            // Refract: shift screen UV by surface normal for a distortion effect
            float2 screenUV = IN.screenPos.xy / IN.screenPos.w;
            // Distort by the normal’s X & Y
            screenUV += normal.xy * _RefractionAmount;

            // Sample the screen behind the object
            float4 grabbed = tex2D(_GrabTexture, screenUV);

            // Combine the “grabbed” background color with the surface color
            // Weighted by Fresnel => stronger distortion near edges
            // You can tweak the lerp factor to your liking
            half4 refracted = lerp(color, grabbed, fresnel * 0.75);

            // Write the final color (keep the same alpha from the surface)
            color.rgb = refracted.rgb;
        }
        ENDCG
    }

    Fallback "Transparent/Cutout/VertexLit"
}
