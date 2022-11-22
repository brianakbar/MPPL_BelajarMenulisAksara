using UnityEngine;
using Aksara.Setting;

namespace Aksara.UI
{
    public class MainMenu : MonoBehaviour {
        [SerializeField] Menu initialMenu = null;

        GameSetting gameSetting;

        void Awake() {
            gameSetting = FindObjectOfType<GameSetting>();
        }

        void Start() {
            if(initialMenu == null) return;

            DisableAllMenu();
            initialMenu.gameObject.SetActive(true);
        }

        public void SetLanguage(LanguageSetting languageToSet) {
            gameSetting.SetLanguage(languageToSet);
        }

        public void SetDifficulty(DifficultySetting difficultyToSet) {
            gameSetting.SetDifficulty(difficultyToSet);
        }

        public void GoToMenu(Menu menuToGo) {
            DisableAllMenu();
            menuToGo.gameObject.SetActive(true);
        }

        void DisableAllMenu() {
            foreach(Menu menu in GetComponentsInChildren<Menu>()) {
                menu.gameObject.SetActive(false);
            }
        }
    }
}
