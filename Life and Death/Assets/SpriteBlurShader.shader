Shader "Custom/SpriteBlurShader"
{
    Properties
    {
        _MainTex("Base (RGB)", 2D) = "white" {}
        _BlurTex("Blur Texture", 2D) = "white" {}
    }
        SubShader
    {
        Tags { "Queue" = "Transparent" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

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

            sampler2D _MainTex;
            sampler2D _BlurTex;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 original = tex2D(_MainTex, i.uv);
                fixed4 blur = tex2D(_BlurTex, i.uv);
                return lerp(original, blur, original.a);
            }
            ENDCG
        }
    }
        FallBack "Sprites/Default"
}