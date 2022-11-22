using UnityEngine;

namespace Aksara.Utility {
    public class TextureComparer {
        public static bool CompareTexture(Texture2D original, Texture2D correct, Texture2D test, float accuracy = 0.5f) {
            if(original == null || correct == null || test == null) return false;
            
            Color[] originalPixels = original.GetPixels();
            Color[] correctPixels = correct.GetPixels();
            Color[] testPixels = test.GetPixels();

            if(originalPixels.Length != correctPixels.Length) return false;
            if(originalPixels.Length != testPixels.Length) return false;

            int correctPixel = 0, totalPixel = 0;

            for(int i = 0; i < testPixels.Length; i++) {
                if(originalPixels[i] == correctPixels[i] && correctPixels[i] != testPixels[i]) {
                    totalPixel++;
                }
                else if(originalPixels[i] != correctPixels[i]) {
                    totalPixel++;
                    if(correctPixels[i] == testPixels[i]) correctPixel++;
                }
            }

            return (1.0f*correctPixel/totalPixel) > accuracy;
        }
    }
}
