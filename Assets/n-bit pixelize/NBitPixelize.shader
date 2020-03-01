// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Test/NBitPixelize" {

	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}

	SubShader {
		Pass {
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			uniform float pixelRound;
			uniform float colorRound;
			uniform float pixelRatio;
			uniform sampler2D _MainTex;

			float rround (float IN, float r) {
				return mul(round(mul(IN, r)), 1/r);
			}

			float2 rround (float2 IN, float r) {
				return mul(round(mul(IN, r)), 1/r);
			}

			float3 rround (float3 IN, float r) {
				return mul(round(mul(IN, r)), 1/r);
			}

			float4 rround (float4 IN, float r) {
				return mul(round(mul(IN, r)), 1/r);
			}

			v2f_img vert( appdata_img v ) {
			    v2f_img o;
			    o.pos = UnityObjectToClipPos (v.vertex);
			    o.uv = v.texcoord;
			    return o;
			}


			float4 frag(v2f_img i) : COLOR {
				float2 uv = i.uv;
				uv.x = rround(uv.x, pixelRound);
				uv.y = rround(uv.y, pixelRound * pixelRatio);
				return rround(tex2D(_MainTex, uv), colorRound);
			}

			ENDCG
		}
	}
}
