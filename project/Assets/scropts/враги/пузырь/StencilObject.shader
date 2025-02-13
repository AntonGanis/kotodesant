Shader "Custom/StencilObject"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}  // Добавляем свойство текстуры
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Stencil
        {
            Ref 1          // Значение, записанное кубом
            Comp notequal  // Показываем только там, где НЕТ значения 1
        }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"  // Подключаем утилиты Unity

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

            sampler2D _MainTex;   // Основная текстура объекта

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                return tex2D(_MainTex, i.uv);  // Возвращаем оригинальную текстуру
            }
            ENDCG
        }
    }
}
