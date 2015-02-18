Shader "MyShaders/IluminationShader" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
      	_RimColor ("Rim Color", Color) = (0.2,0.2,0.2,0.0)
      	_RimPower ("Rim Power", Range(0.5,8.0)) = 3.0
	}
	SubShader {
		Tags { "Queue"="Transparent" "RenderType"="Transparent" }
	 Blend SrcAlpha OneMinusSrcAlpha
		LOD 200
		
		CGPROGRAM
      	#pragma surface surf Lambert

      	float4 _RimColor;
     	float _RimPower;
		sampler2D _MainTex;

		struct Input {
          float2 uv_MainTex;
          float3 viewDir;
      	};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);			
			o.Albedo = c.rgb;
			o.Alpha = c.a;
			half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));
			
			if(c.r > 0.85 && c.g > 0.85 && c.b > 0.85)
          		o.Emission = _RimColor.rgb * pow (rim, _RimPower);

		}
		ENDCG
	} 
	FallBack "Diffuse"
}
