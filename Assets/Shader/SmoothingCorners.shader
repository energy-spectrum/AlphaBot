Shader "MaskedTexture"
{   Properties
    { _MainTex("Base (RGB)", 2D) = "white" {}
       _Mask("Culling Mask", 2D) = "white" {}
       _Color("Tint", Color) = (1.000000,1.000000,1.000000,1.000000)
      // _Cutoff("Alpha cutoff", Range(0,1)) = 0.1
    }

SubShader{
 Tags { "QUEUE" = "Transparent" "IGNOREPROJECTOR" = "true" "RenderType" = "Transparent" "CanUseSpriteAtlas" = "true" "PreviewType" = "Plane" }
 //Tags {"Queue" = "Transparent"}
          Lighting Off
          ZWrite Off
          Blend SrcAlpha OneMinusSrcAlpha
          AlphaTest GEqual[_Cutoff]
          Pass
          {
             Material {
                Diffuse[_Color]
                Ambient[_Color]
             }
         

             SetTexture[_Mask] {combine texture}           
             SetTexture[_MainTex] {combine texture, previous}  
         
          }

         

       }
}

//Shader "VertexLit Simple" {
//    Properties{
//        _Color("Main Color", COLOR) = (1,1,1,1)
//    }
//        SubShader{
//            Pass {
//                Material {
//                    Diffuse[_Color]
//                    Ambient[_Color]
//                }
//                Lighting On
//            }
//    }
//}