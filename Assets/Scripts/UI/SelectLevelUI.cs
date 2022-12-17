using UnityEngine;
using Aksara.Setting;
using Aksara.Core;
using TMPro;
using Aksara.Utility;

namespace Aksara.UI
{
    public class SelectLevelUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI titleText;
        [SerializeField] TextMeshProUGUI difficultyText;
        [SerializeField] SelectLevelItemUI selectLevelItemPrefab = null;
        
        GameSetting gameSetting;

        void Awake() {
            gameSetting = FindObjectOfType<GameSetting>();
        }

        void OnEnable() {
            Redraw();
        }

        void Redraw() {
            foreach(Transform child in transform) {
                Destroy(child.gameObject);
            }

            var levelSetting = gameSetting.GetLevelSetting();
            if(levelSetting == null) return;

            titleText.text = levelSetting.Language.ToString();
            difficultyText.text = StringModifier.AddSpacesToSentence(levelSetting.Difficulty.ToString());

            var aksaraCharacters = gameSetting.GetAksaraCharacters();
            if(aksaraCharacters == null) return;

            foreach(AksaraCharacter aksara in aksaraCharacters) {
                var instance = Instantiate(selectLevelItemPrefab, transform);
                instance.Setup(aksara, gameSetting.GetComplete(aksara));
            }
        }
    }
}
