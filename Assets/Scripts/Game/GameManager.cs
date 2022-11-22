using System.Collections;
using UnityEngine;
using Aksara.UI;
using Aksara.Utility;
using Aksara.Setting;
using Aksara.Core;

namespace Aksara.Game {
    public class GameManager : MonoBehaviour {
        [SerializeField] GameUI gameUI = null;
        [SerializeField] DrawableBoxUI drawableBox;

        Texture2D original;
        Texture2D correctAnswer;
        AksaraCharacter aksara;

        ImageCapturer imageCapturer;
        RectTransform answerContainer;
        GameSetting gameSetting;

        void Awake() {
            imageCapturer = FindObjectOfType<ImageCapturer>();
            answerContainer = drawableBox.GetComponent<RectTransform>();
            gameSetting = FindObjectOfType<GameSetting>();
        }

        IEnumerator Start() {
            aksara = gameSetting.GetAksaraCharacter();
            if(aksara != null) {
                gameUI.Setup(aksara);
                drawableBox.Setup(aksara.FillSprite, aksara.OutlineSprite);
            }

            drawableBox.SetAksaraFill(true);
            drawableBox.SetAksaraOutline(false);
            yield return imageCapturer.CaptureTexture(answerContainer, (texture) => {
                correctAnswer = texture;
            });

            drawableBox.SetAksaraFill(false);
            drawableBox.SetAksaraOutline(true);
            yield return imageCapturer.CaptureTexture(answerContainer, (texture) => {
                original = texture;
            });
        }

        public void FinishGame() {
            StartCoroutine(CheckScore());
        }

        IEnumerator CheckScore() {
            yield return imageCapturer.CaptureTexture(answerContainer, (texture) => {
                Texture2D playerAnswer = texture;
                bool isComplete = TextureComparer.CompareTexture(original, correctAnswer, 
                                                                playerAnswer, aksara.Accuracy);
                gameUI.ShowGameFinish(isComplete);
            });
        }
    }
}
