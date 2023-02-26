Shader "Custom/Transparent Diffuse (Mask cutoff)" {
    Properties{
        _Color("Main Color", Color) = (1,1,1,1)
        _MainTex("Base (RGB) Trans (A)", 2D) = "white" {}
        _Cutoff("Mask cutoff", Range(0,1)) = 0
        _MaskTex("Mask (RGB=unused, A=mask)", 2D) = "white" {}
    }

        SubShader{
            Tags {"IgnoreProjector" = "True"}
            LOD 200

        CGPROGRAM
        #pragma surface surf Lambert alpha

        sampler2D _MainTex;
        sampler2D _MaskTex;
        fixed4 _Color;
        //fixed _Cutoff;

        struct Input {
            float2 uv_MainTex;
        };

        void surf(Input IN, inout SurfaceOutput o) {
            //fixed4 mask = tex2D(_MaskTex, IN.uv_MainTex);
           // clip(mask.a - _Cutoff * 1.004); // 1.004 = 1+(1/255) to make sure also white is clipped

            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Alpha = c.a*3;
        }
        ENDCG
    }

        Fallback "Transparent/Diffuse"
}

