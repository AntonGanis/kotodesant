Shader "Custom/StencilMask"
{
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Stencil
        {
            Ref 1          // ������������� �������� � ������ ���������
            Comp always    // ������ ����������
            Pass replace   // �������� ��������
        }

        ColorMask 0   // �� ������������ ��� ������ (������ �����)
        ZWrite off

        Pass
        {
            // ������ pass ��� ���������� ����������
        }
    }
}
