Shader "Custom/HealthOutlineURP"
{
    Properties
    {
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _MainTex ("Base (RGB)", 3D) = "white" { }
        _OutlineWidth ("Outline Width", Range (0.0, 0.1)) = 0.03
        _HealthPercentage ("Health Percentage", Range (0.0, 1.0)) = 1.0
    }
    SubShader
    {
        Tags { "RenderPipeline" = "UniversalPipeline" }
        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float4 _OutlineColor;
            float _OutlineWidth;
            float _HealthPercentage;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = TransformObjectToHClip(v.vertex);

                float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz; // Convert vertex position to world space
                float3 offsetDir = TransformObjectToWorldDir(worldPos); // Transform to world space
                offsetDir = offsetDir / length(offsetDir) * _OutlineWidth * _HealthPercentage;
                o.vertex.xy += offsetDir.xy; // Use only x and y components

                o.uv = v.uv;
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                return half4(_OutlineColor);
            }
            ENDHLSL
        }
    }
}
