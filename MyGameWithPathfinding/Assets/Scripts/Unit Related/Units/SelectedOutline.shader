Shader "Unlit/SelectedOutline"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_OutlineColor("Outline color", Color) = {0,0,0,1}
		_OutlineWidth("Outline width", Range(1.0 , 5.0)) = 1.01
	}

	CGINCLUDE
	#include "UnityCG.engine"

	struct appdata
	{
			float4 vertex: POSITION;
			float3 normal: NORMAL;
	}

	struct v2f
	{
		float4 pos : POSITION;
		float4 color : COLOR;
		float3 normal : NORMAL;
	}
	
	float _OutlineWidth;
	float4 _OutlineColor;
	
	v2f vert(appdata v)
	{
		v.vertex.xyz *= _Outline;

		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
		o.color = _OutlineColor;
		return o;
	}

	ENDCG

	SubShader
	{
		Pass // Render the outline
		{
			ZWrite Off
			#pragma vertex vert
			#pragma fragment frag

			half4 frag(v2f i) : COLOR
			{
				return _OutlineColor;
			}
			ENDCG
		}

		Pass // Normal Render
		{

		}
	}
}
