Shader "Unlit/Cube4"
{
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            Name "Base"
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = fixed4(1.0,0.5, 0.5, 1);
                return col;
            }
            ENDCG
        }

        Pass
        {
            Name "OUTLINE"
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                float3 norm = mul((float3x3)UNITY_MATRIX_IT_MV, v.normal);
                float2 offset = TransformViewToProjection(norm.xy);

                o.vertex.xy += offset*o.vertex.z * 0.1;
                
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = fixed4(0.0,1.0, 0.0, 1);
                return col;
            }
            ENDCG
        }
                
    }
    
    FallBack "Diffuse"
}
