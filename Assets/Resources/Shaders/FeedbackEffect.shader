Shader "Custom/Feedback Effect"
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "black" {}
		_Fade ("Fade", Color) = (0, 0, 0, 1)
		_Alpha ("Alpha", Range(0.0, 1.0)) = 0.0
		_Blend ("Blend", Range(0.0, 1.0)) = 0.3
		_Rotate ("Rotate", Vector) = (1, 0, 0, 1)
	}
	SubShader
	{
		
		LOD 200
		
		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
		}
		
		ZTest Always Cull Off ZWrite Off
		Lighting Off
		Fog { Mode Off }
		Blend SrcAlpha OneMinusSrcAlpha
		
		Pass
		{
			ColorMask RGB
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			float4 _MainTex_ST;
			fixed _Blend;
			float4 _Rotate;
			float2 _Center;
			
			struct appdata_t
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD;
			};
			
			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 texcoord : TEXCOORD0;
			};

			v2f vert(appdata_t v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				float s = dot(v.texcoord.xy, _Rotate.xy) - dot(_Rotate.xy, _Center);
				float t = dot(v.texcoord.xy, _Rotate.zw) - dot(_Rotate.zw, _Center);
				o.texcoord = float2(s, t) + _Center;
				return o;
			}
			
			fixed4 frag(v2f i) : COLOR
			{
				fixed4 base = tex2D(_MainTex, i.texcoord);
				base.a = _Blend;
				return base;
			}
			
			ENDCG
		}
	} 
}
