Shader "Custom/BlurShader"
{
    Properties
    {
        _MainTex("Base (RGB)", 2D) = "white" {}
        _BlurSpread("Blur Spread", Float) = 0.6
    }
        SubShader
        {
            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"

                sampler2D _MainTex;
                float _BlurSpread;

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                half4 frag(v2f i) : SV_Target
                {
                    float2 uv = i.uv;
                    half4 color = tex2D(_MainTex, uv);
                    // Sample neighboring pixels to create blur effect
                    float2 offset = float2(_BlurSpread / 100.0, _BlurSpread / 100.0);
                    color += tex2D(_MainTex, uv + offset);
                    color += tex2D(_MainTex, uv - offset);
                    color += tex2D(_MainTex, uv + float2(-offset.x, offset.y));
                    color += tex2D(_MainTex, uv + float2(offset.x, -offset.y));
                    return color * 0.25; // Average the colors
                }
                ENDCG
            }
        }
}
