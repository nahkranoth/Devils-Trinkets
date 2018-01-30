// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Hobscure/BlueprintGhost"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Color("Main Color", Color) = (1.000000,1.000000,1.000000,1.000000)
	}
		SubShader
		{
			Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
			Blend One One
			ZWrite Off
			Cull Off

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
		};

		struct v2f
		{
			float2 uv : TEXCOORD0;
			float4 vertex : SV_POSITION;
		};

		sampler2D _MainTex;
		float4 _MainTex_ST;

		v2f vert(appdata v)
		{
			v2f o;
			o.vertex = UnityObjectToClipPos(v.vertex);
			o.uv = v.uv;
			return o;
		}


		float2 hash(float2 p)
		{
			p = float2(dot(p, float2(127.1, 311.7)),
				dot(p, float2(269.5, 183.3)));

			return -1.0 + 2.0*frac(sin(p)*43758.5453123);
		}

		float noise(in float2 p)
		{

			float2 i = floor(p);
			float2 f = frac(p);

			float2 u = f*f*(3.0 - 2.0*f);

			return lerp(lerp(dot(hash(i + float2(0.0, 0.0)), f - float2(0.0, 0.0)),
				dot(hash(i + float2(1.0, 0.0)), f - float2(1.0, 0.0)), u.x),
				lerp(dot(hash(i + float2(0.0, 1.0)), f - float2(0.0, 1.0)),
					dot(hash(i + float2(1.0, 1.0)), f - float2(1.0, 1.0)), u.x), u.y);
		}


		float2 stepColor(float2 clr) {
			int steps = 32;
			clr = floor(clr*steps) / (steps + (_Time * 0.001));
			return clr;
		}

		float4 _Color;

		float4 Mult(float4 a, float4 b) {
			float4 mix = a * b;
			return mix;
		}

		float4 Burn(float4 a, float4 b){
			float4 one = float4(1., 1., 1., 1.);
			return  one - (one - b) / a;
		}

	fixed3 frag(v2f i) : SV_Target
	{

		float4 tex = float4(tex2D(_MainTex, i.uv).rgb, 1.);

		float f = 0.0;

		float2x2 m = float2x2(23.6, 23.2, -23.2, 23.6) * (_Time * 0.001) + 9000.;

		f = 0.5000*noise(stepColor(i.uv));
		i.uv = mul(m, stepColor(i.uv));
		f += 0.2500*noise(stepColor(i.uv));
		i.uv = mul(m, stepColor(i.uv));
		f += 0.1250*noise(stepColor(i.uv));
		i.uv = mul(m, stepColor(i.uv));
		f += 0.0625*noise(stepColor(i.uv));
		i.uv = mul(m, stepColor(i.uv));
		f += 0.0225*noise(stepColor(i.uv));
		i.uv = mul(m, stepColor(i.uv));

		float4 noise = max(0, float4(f, f, f, f));
		
		float4 noiseColor = Mult(_Color,noise);
		
		float4 texColor = Burn(tex, _Color * 0.9);

		return lerp(texColor, noiseColor, 0.9f);
	}
		ENDCG
	}
	}
}
