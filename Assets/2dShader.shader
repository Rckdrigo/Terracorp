Shader "MyShaders/2dShader" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "Queue"="Transparent" "RenderType"="Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		Lighting off
		LOD 200
		Pass{
			CGPROGRAM
			
	      	#pragma vertex vert
	      	#pragma fragment frag

	      	float4 _RimColor;
	     	float _RimPower;
			sampler2D _MainTex;

			struct vertexInput {
	          float4 vertex : POSITION;
	          float2 uv : TEXCOORD0;
	      	};
	      	
	      	struct v2f {
	          float4 vertex : SV_POSITION;
	          float2 uv : TEXCOORD0;
	      	};

			v2f vert (vertexInput i){
				v2f o;
				
				o.vertex = mul(UNITY_MATRIX_MVP,i.vertex);
				o.uv = i.uv;
				
				return o;
			}
			
			half4 frag(v2f i) : COLOR{
				half4 c = tex2D(_MainTex,i.uv);
				
				if(c.r > 0.7 && c.g > 0.7 && c.b > 0.7)
					discard;
				if(c.a < 0.9)
					discard;
				
	        	return c;
			}
			ENDCG
		} 
	}
	FallBack "Diffuse"
}
