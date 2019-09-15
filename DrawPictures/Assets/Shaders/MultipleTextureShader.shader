Shader "Unlit/MultiplePictuer"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Tex1("Texture1", 2D) = "white" {}
        _Tex2("Texture2", 2D) = "white" {}
        _Tex3("Texture3", 2D) = "white" {}
        _ColorTex("ColorTexture", 2D) = "white" {}
        _BGColor ("BGColor", Color) = (1,1,1,1)
        _Color1("Color1", Color) = (1,1,1,1)
        _Color2("Color2", Color) = (1,1,1,1)
        _Color3("Color3", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
        LOD 100
        
        //Blend SrcAlpha OneMinusSrcAlpha 

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 col : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float4 col: COLOR;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            
            sampler2D _Tex1;
            float4 _Tex1_ST;
            
            sampler2D _Tex2;
            float4 _Tex2_ST;
            
            sampler2D _Tex3;
            float4 _Tex3_ST;
            
            sampler2D _ColorTex;
            float4 _ColorTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.uv = o.uv - float2(0.5, 0.5);
                o.uv = o.uv * 2;
                
                o.col = v.col;
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }
            
            float4 _BGColor;
            
            float4 _Color1;
            float4 _Color2;
            float4 _Color3;

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = _BGColor;
                
                fixed4 tex = tex2D(_Tex1, i.uv * _Tex1_ST.xy - _Tex1_ST.zw * _Tex1_ST.xy + float2(0.5, 0.5));
                tex = tex * _Color1;
                col = lerp(col, tex, tex.a);
                
                tex = tex2D(_Tex2, i.uv * _Tex2_ST.xy - _Tex2_ST.zw * _Tex2_ST.xy + float2(0.5, 0.5));
                tex = tex * _Color2;
                col = lerp(col, tex, tex.a);
                
                tex = tex2D(_ColorTex, i.uv * _ColorTex_ST.xy - _ColorTex_ST.zw * _ColorTex_ST.xy + float2(0.5, 0.5));
                tex = tex * i.col;
                col = lerp(col, tex, tex.a);
                
                tex = tex2D(_Tex3, i.uv * _Tex3_ST.xy - _Tex3_ST.zw * _Tex3_ST.xy + float2(0.5, 0.5));
                tex = tex * _Color3;
                col = lerp(col, tex, tex.a);
                
                return col;
            }
            ENDCG
        }
    }
}
