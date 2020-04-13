Shader "Custom/PortalWindow"
{
    SubShader
    {
		Zwrite Off
		ColorMask 0
		Cull Off

		Stencil {
			Ref 1
			Pass replace
		}

        Pass
        {
        }
    }
}
