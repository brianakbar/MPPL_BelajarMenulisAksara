using UnityEngine;
using UnityEngine.SceneManagement;
using Aksara.Setting;

namespace Aksara.SceneManagement {
    public class SceneLoader : MonoBehaviour {
        public void ReloadScene() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadHome() {
            SceneManager.LoadScene(0);
        }

        public void LoadGame() {
            SceneManager.LoadScene(1);
        }

        public void LoadNextLevel() {
            if(FindObjectOfType<GameSetting>().LoadNextAksaraCharacter()) LoadGame();
            else LoadHome();
        }
    }
}