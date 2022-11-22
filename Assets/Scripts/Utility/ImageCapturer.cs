using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace Aksara.Utility {
    public class ImageCapturer : MonoBehaviour {

        public IEnumerator CaptureImage(RectTransform rect, string path = "default.png") {
            if(rect == null) yield break;

            yield return CaptureTexture(rect, (texture) => {
                byte[] image = texture.EncodeToPNG();
                File.WriteAllBytes(Application.dataPath + path, image);
            });
        }

        public IEnumerator CaptureTexture(RectTransform rect, Action<Texture2D> callback) {
            if(rect == null) yield break;
            yield return new WaitForEndOfFrame(); 

            Vector3[] corners = new Vector3[4];
            rect.GetWorldCorners(corners);

            for(int i = 0; i < corners.Length; i++) {
                corners[i] = Camera.main.WorldToScreenPoint(corners[i]);
            }

            float startX = corners[0].x;
            float startY = corners[0].y;

            int width = (int)(corners[3] - corners[0]).x;
            int height = (int)(corners[1] - corners[0]).y;

            Texture2D texture = new Texture2D(width, height, TextureFormat.RGB24, false);
            texture.ReadPixels(new Rect(startX, startY, width, height), 0, 0);
            texture.Apply();

            callback(texture);
        }
    }
}
