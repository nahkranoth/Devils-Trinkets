// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Lava"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_SecTex("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM

			#define M_PI 3.1415926535897932384626433832795
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;

			sampler2D _SecTex;
			float4 _SecTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);

				o.vertex.y += sin(_Time + v.uv.y);

				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture

				i.uv.x += sin(i.uv.y + _Time.x * 0.1)* 0.3;
				i.uv.y += cos(i.uv.x + _Time.y * 0.1)* 0.3;

				fixed4 col = tex2D(_MainTex, i.uv + (1 + cos(2 * M_PI * 0.1 * _Time).x) * 0.1);
				fixed4 col2 = tex2D(_SecTex, i.uv + (1 + sin(2 * M_PI * 0.1 * _Time).y) * 0.1);

				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				

				col *= (0.5 * (1 + sin(4 * M_PI * _Time).x)) + 0.5;
				col2 *= (0.5 * (1 + cos(4 * M_PI * _Time).x)) + 0.5;
				
				fixed4 result = col + col2 / 2;

				return result;
			}
			ENDCG
		}
	}
}
