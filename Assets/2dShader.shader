Shader "MyShaders/2dShader" {
	Properties {
		_MainTex ("Base (RGB) (A)", 2D) = "white" {}
		_LavaTex ("Lava (RGB)", 2D) = "white"{}
		_LavaColor("Lava Color", color) = (1,1,1,1)
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

	      	half4 _LavaColor;
			sampler2D _MainTex;
			sampler2D _LavaTex;

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
				
				//if(c.r < 0.3 && c.g < 0.3 && c.b < 0.3)
				//		c =  tex2D(_LavaTex,i.uv)* _LavaColor;
				if(c.a < 0.9)
					discard;
				
	        	return c;
			}
			ENDCG
		} 
	}
	FallBack "Diffuse"
}
