using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Aksara.Core;

namespace Aksara.UI {
    public class GameUI : MonoBehaviour {
        [SerializeField] Image aksaraQuestionImage;
        [SerializeField] TextMeshProUGUI aksaraQuestionName;
        [SerializeField] GameFinishPanelUI gameFinishPanel;

        AksaraCharacter aksara;

        void Start() {
            gameFinishPanel.gameObject.SetActive(false);
        }

        public void Setup(AksaraCharacter aksara) {
            if(aksara == null) return;

            this.aksara = aksara;

            aksaraQuestionImage.sprite = aksara.FillSprite;
            aksaraQuestionName.text = aksara.CharacterName;
        }

        public void ShowGameFinish(bool isComplete) {
            gameFinishPanel.gameObject.SetActive(true);

            if(aksara != null) {
                gameFinishPanel.Setup(aksara.FillSprite, aksara.CharacterName);
            }
            
            if(isComplete) gameFinishPanel.ShowSuccess();
            else gameFinishPanel.ShowFail();
        }
    }
}
