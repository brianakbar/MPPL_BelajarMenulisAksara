using UnityEngine;
using UnityEngine.SceneManagement;
using Aksara.Setting;
using Aksara.Core;

namespace Aksara.SceneManagement {
    public class SceneLoader : MonoBehaviour {
        SavingWrapper savingWrapper;

        void Awake() {
            savingWrapper = FindObjectOfType<SavingWrapper>();
        }

        public void ReloadScene() {
            LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadHome() {
            LoadScene(0);
        }

        public void LoadGame() {
            LoadScene(1);
        }

        public void LoadNextLevel() {
            if(FindObjectOfType<GameSetting>().LoadNextAksaraCharacter()) LoadGame();
            else LoadHome();
        }

        public void DeleteSaveFile() {
            savingWrapper.Delete();
            Destroy(GameObject.FindWithTag("Persistent Object"));
            FindObjectOfType<PersistentObjectSpawner>().SetHasSpawned(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        void LoadScene(int buildIndex) {
            DontDestroyOnLoad(gameObject);
            savingWrapper.Save();
            SceneManager.LoadScene(buildIndex);
            savingWrapper.Load();
            Destroy(gameObject);
        }
    }
}