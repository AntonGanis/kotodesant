Shader "Custom/StencilMask"
{
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Stencil
        {
            Ref 1          // Устанавливаем значение в буфере трафарета
            Comp always    // Всегда записывать
            Pass replace   // Заменяем значение
        }

        ColorMask 0   // Не отрисовываем сам объект (только маска)
        ZWrite off

        Pass
        {
            // Пустой pass для корректной компиляции
        }
    }
}
