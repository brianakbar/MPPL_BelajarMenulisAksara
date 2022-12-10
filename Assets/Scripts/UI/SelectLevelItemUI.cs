using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Aksara.Core;
using Aksara.Setting;
using Aksara.SceneManagement;

namespace Aksara.UI
{
    public class SelectLevelItemUI : MonoBehaviour
    {
        [SerializeField] Image aksaraImage;
        [SerializeField] TextMeshProUGUI aksaraName;
        [SerializeField] Image checkmarkImage;
        AksaraCharacter aksara;

        public void Awake() {
            checkmarkImage.enabled = false;
        }

        public void Setup(AksaraCharacter aksara, bool isComplete) {
            if(aksara == null) return;

            this.aksara = aksara;

            aksaraImage.sprite = aksara.MainMenuSprite;
            aksaraName.text = aksara.CharacterName;
            
            if(isComplete) checkmarkImage.enabled = true;
        }

        public void OnClick() {
            FindObjectOfType<GameSetting>().SetAksaraCharacter(aksara);
            FindObjectOfType<SceneLoader>().LoadGame();
        }
    }
}
