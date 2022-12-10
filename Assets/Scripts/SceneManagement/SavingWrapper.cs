using UnityEngine;
using Aksara.Saving;

namespace Aksara.SceneManagement
{
    public class SavingWrapper : MonoBehaviour {
        [SerializeField] string defaultSaveFile = "save";

        SavingSystem savingSystem;

        void Awake() {
            savingSystem = GetComponent<SavingSystem>();
            Load();
        }

        public void Save() {
            savingSystem.Save(defaultSaveFile);
        }

        public void Load() {
            savingSystem.Load(defaultSaveFile);
        }

        public void Delete() {
            savingSystem.Delete(defaultSaveFile);
        }
    }
}