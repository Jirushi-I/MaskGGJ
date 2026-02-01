Shader "Custom/ShaderMask"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        [HDR] _Color ("Tint Color", Color) = (1,1,1,1)
        _VisionRadius ("Vision Radius", Range(0, 1)) = 0.3
        _EdgeSoftness ("Edge Softness", Range(0, 0.5)) = 0.1
        _BlurAmount ("Blur Amount", Range(0, 20)) = 0
        _CenterAlpha ("Center Alpha", Range(0, 1)) = 0.5 // Contrôle l'alpha au centre uniquement
    }
    
    SubShader
    {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        Blend SrcAlpha OneMinusSrcAlpha
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };
            
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
            };
            
            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _MainTex_TexelSize;
            float4 _Color;
            float _VisionRadius;
            float _EdgeSoftness;
            float _BlurAmount;
            float _CenterAlpha;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color;
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                float2 center = i.uv - 0.5;
                float aspectRatio = _MainTex_TexelSize.x / _MainTex_TexelSize.y;
                center.x *= aspectRatio;
                
                float dist = length(center) * 2.0;
                
                // Masque circulaire pour la visibilité
                float mask = 1.0 - smoothstep(_VisionRadius, _VisionRadius + _EdgeSoftness, dist);
                
                // Flou
                fixed4 col = tex2D(_MainTex, i.uv);
                
                if (_BlurAmount > 0)
                {
                    float blur = _BlurAmount * 0.002;
                    col = tex2D(_MainTex, i.uv) * 0.25;
                    col += tex2D(_MainTex, i.uv + float2(blur, 0)) * 0.125;
                    col += tex2D(_MainTex, i.uv + float2(-blur, 0)) * 0.125;
                    col += tex2D(_MainTex, i.uv + float2(0, blur)) * 0.125;
                    col += tex2D(_MainTex, i.uv + float2(0, -blur)) * 0.125;
                    col += tex2D(_MainTex, i.uv + float2(blur, blur)) * 0.0625;
                    col += tex2D(_MainTex, i.uv + float2(-blur, blur)) * 0.0625;
                    col += tex2D(_MainTex, i.uv + float2(blur, -blur)) * 0.0625;
                    col += tex2D(_MainTex, i.uv + float2(-blur, -blur)) * 0.0625;
                }
                
                // Application de la teinte de couleur
                col *= _Color * i.color;
                
                // Application du masque pour les RGB (noir aux bords)
                col.rgb *= mask;
                
                // Alpha : plein aux bords (noir opaque), réduit au centre (transparent)
                // Inverse du masque pour l'alpha
                float alphaMultiplier = lerp(_CenterAlpha, 1.0, 1.0 - mask);
                col.a = _Color.a * i.color.a * alphaMultiplier;
                
                return col;
            }
            ENDCG
        }
    }
}