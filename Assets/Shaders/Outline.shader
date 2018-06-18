Shader "Unlit/Outline"
{
	Properties {
		_Color ("Main Color", Color) = (.5,.5,.5,1)
		_MainTex ("Texture", 2D) = "white" { }
		_OutlineColor ("Outline Color", Color) = (1,0,0,1)
		_OutlineWidth ("Outline width", Range (1.0, 5.0)) = 1.06
		//(0.0, 0.03)) = 0.005
		
		
	}
 
CGINCLUDE
#include "UnityCG.cginc"
 
struct appdata {
	float4 vertex : POSITION;
	float3 normal : NORMAL;
};
 
struct v2f {
	float4 pos : POSITION;
	//float4 color : COLOR;
};
 
uniform float _OutlineWidth;
uniform float4 _OutlineColor;
 
v2f vert(appdata v) {
	// just make a copy of incoming vertex data but scaled according to normal direction
	v.vertex.xyz *= _OutlineWidth;
	v2f o;

	o.pos = UnityObjectToClipPos(v.vertex);
	//o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
 
	//float3 norm   = mul ((float3x3)UNITY_MATRIX_IT_MV, v.normal);
	//float2 offset = TransformViewToProjection(norm.xy);
 
	//o.pos.xy += offset * o.pos.z * _OutlineWidth;
	//o.color = _OutlineColor;
	return o;
}
ENDCG
 
	SubShader {
		Tags { "Queue" = "Transparent" }

		pass //Render the outline
		{
			ZWrite Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			half4 frag(v2f i) : COLOR
			{
				return _OutlineColor;
			}
			ENDCG
		}

		pass //Render Normal
		{
			ZWrite On

			Material
			{
				Diffuse[_Color]
				Ambient[_Color]
			}

			Lighting On

			SetTexture[_MainTex]
			{
				ConstantColor[_Color]
			}

			SetTexture[_MainTex]
			{
				Combine previous * primary DOUBLE
			}
		}
	}
 
	Fallback "Diffuse"
}
