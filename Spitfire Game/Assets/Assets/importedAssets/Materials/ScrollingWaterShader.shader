Shader "Unlit/ScrollingWaterShader"
{
    Properties
    {
        _Color ("Color Tint", Color) = (1, 1, 1, 1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _Speed ("Scroll Speed", Vector) = (0.1, 0.1, 0, 0)
        _Metallic ("Metallic", Range(0,1)) = 0.5
        _Smoothness ("Smoothness", Range(0,1)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        CGPROGRAM
        #pragma surface surf Standard

        sampler2D _MainTex;
        sampler2D _BumpMap;
        float2 _Speed;
        float4 _Color;
        float _Metallic;
        float _Smoothness;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float2 offset = _Time.y * _Speed;
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _Color.rgb;
            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap - offset));
            o.Metallic = _Metallic;
            o.Smoothness = _Smoothness;
        }
        ENDCG
    }
}
