Shader "Unlit/Outline"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _OutlineWidth ("Outline Width", Range(0, 1)) = 0.1
        _OutlineColor ("Outline Color", Color) = (0.0, 0.0, 0.0, 1.0)
        _FillColor ("Fill Color", Color) = (0.0, 0.0, 0.0, 0.0)
        _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
            
    }
    SubShader
    {
        Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
        LOD 100
//        Cull Off
//        ZWrite Off
//        Blend SrcAlpha OneMinusSrcAlpha 
        Lighting Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            // alphatest:_Cutoff
            // #pragma surface surf Standard alphatest:_Cutoff addshadow
            // make fog work
            // #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID 
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                UNITY_VERTEX_OUTPUT_STEREO 
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _OutlineWidth;
            fixed4 _OutlineColor;
            fixed4 _FillColor;
            fixed4 _Cutoff;

            v2f vert (appdata v)
            {
                v2f o;
                UNITY_SETUP_INSTANCE_ID(v); //Insert
                UNITY_INITIALIZE_OUTPUT(v2f, o); //Insert
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o); //Insert
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed squareGradient = min(min(1-i.uv.x, i.uv.x), min(1-i.uv.y, i.uv.y));
                col = squareGradient < _OutlineWidth ? _OutlineColor : _FillColor;
                // col = fixed4(1,1,0,0);
                // col = i.uv.xxxx;
                // apply fog
                // UNITY_APPLY_FOG(i.fogCoord, col);
                clip(_OutlineWidth-squareGradient);
                return col;
            }
            ENDCG
        }
    }
}
