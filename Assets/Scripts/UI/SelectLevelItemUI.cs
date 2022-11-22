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
        AksaraCharacter aksara;

        public void Setup(AksaraCharacter aksara) {
            if(aksara == null) return;

            this.aksara = aksara;

            aksaraImage.sprite = aksara.MainMenuSprite;
            aksaraName.text = aksara.CharacterName;
        }

        public void OnClick() {
            FindObjectOfType<GameSetting>().SetAksaraCharacter(aksara);
            FindObjectOfType<SceneLoader>().LoadGame();
        }
    }
}
