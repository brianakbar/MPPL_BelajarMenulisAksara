using Aksara.Core;
using Aksara.Setting;
using Aksara.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Aksara.UI
{
    public class TypeButtonUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI typeText = null;

        Button button;
        MainMenu mainMenu;
        Difficulty difficulty;
        DifficultySetting difficultySetting;
        Menu menuToGo;

        void Awake() {
            mainMenu = FindObjectOfType<MainMenu>();
            button = GetComponent<Button>();
            difficultySetting = GetComponent<DifficultySetting>();
        }

        void OnEnable() {
            button.onClick.AddListener(SetMainMenuDifficulty);
            button.onClick.AddListener(GoToMenu);
        }

        void OnDisable() {
            button.onClick.RemoveListener(SetMainMenuDifficulty);
            button.onClick.RemoveListener(GoToMenu);
        }

        public Difficulty GetAksaraType() {
            return difficulty;
        }

        public void SetAksaraType(Difficulty difficulty) {
            this.difficulty = difficulty;
            this.difficultySetting.SetDifficulty(difficulty);
            typeText.text = StringModifier.AddSpacesToSentence(difficulty.ToString());
        }

        public void SetGoToMenu(Menu menuToGo) {
            this.menuToGo = menuToGo;
        }

        void SetMainMenuDifficulty() {
            mainMenu.SetDifficulty(difficultySetting);
        }

        void GoToMenu() {
            mainMenu.GoToMenu(menuToGo);
        }
    }
}
