Shader "Fractal/Mandlebrot"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Area("Area", vector) = (0,0,4,4)
		_Float("Float", Float) = 2.0
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

			float _Float;
			float4 _Area;
            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
				float2 c = _Area.xy + (i.uv-0.5) * _Area.zw; //xyzw
				float2 z;
				float iter;

				for (iter = 0; iter < 1000; iter++) {
					z = float2(z.x*z.x-z.y*z.y, _Float *z.x*z.y) + c;
						if (length(z) > 2) break;
				}
                return iter / 255;
            }
            ENDCG
        }
    }
}
