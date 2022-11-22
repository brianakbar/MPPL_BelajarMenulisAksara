using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Aksara.UI
{
    public class GameFinishPanelUI : MonoBehaviour
    {
        [SerializeField] Image aksaraImage;
        [SerializeField] TextMeshProUGUI aksaraName;
        [SerializeField] TextMeshProUGUI statusText;
        [SerializeField] string successText;
        [SerializeField] Color successColor;
        [SerializeField] string failText;
        [SerializeField] Color failColor;

        public void Setup(Sprite aksaraSprite, string aksaraName) {
            this.aksaraName.text = aksaraName;

            if(aksaraSprite == null) return;
            aksaraImage.sprite = aksaraSprite;
        }

        public void ShowSuccess() {
            statusText.text = successText;
            statusText.color = successColor;
        }

        public void ShowFail() {
            statusText.text = failText;
            statusText.color = failColor;
        }
    }
}
