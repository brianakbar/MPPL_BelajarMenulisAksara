using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Aksara.Saving
{
    public class SavingSystem : MonoBehaviour
    {
        const string saveFileExtension = ".sav";
        const string lastSceneBuildIndexId = "lastSceneBuildIndex";

        public IEnumerator LoadLastScene(string saveFile) {
            Dictionary<string, object> state = LoadFile(saveFile);
            int buildIndex = SceneManager.GetActiveScene().buildIndex;
            if(state.ContainsKey(lastSceneBuildIndexId)) {
                buildIndex = (int)state[lastSceneBuildIndexId];
            }
            yield return SceneManager.LoadSceneAsync(buildIndex);
            RestoreState(state);
        }

        public void Save(string saveFile) {  
            Dictionary<string, object> state = LoadFile(saveFile);
            CaptureState(state);
            SaveFile(saveFile, state);
        }

        public void Load(string saveFile) {
            RestoreState(LoadFile(saveFile));
        }

        public void Delete(string saveFile) {
            File.Delete(GetPathFromSaveFile(saveFile));
        }

        void SaveFile(string saveFile, object state) {
            string path = GetPathFromSaveFile(saveFile);
            using (FileStream stream = File.Open(path, FileMode.Create)) {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, state);
            }
        }

        Dictionary<string, object> LoadFile(string saveFile) {
            string path = GetPathFromSaveFile(saveFile);
            if(!File.Exists(path)) return new Dictionary<string, object>();

            using (FileStream stream = File.Open(path, FileMode.Open)) {
                BinaryFormatter formatter = new BinaryFormatter();
                return (Dictionary<string, object>)formatter.Deserialize(stream);
            }
        }

        void CaptureState(Dictionary<string, object> state) {
            foreach (SaveableEntity saveable in FindObjectsOfType<SaveableEntity>()) {
                state[saveable.GetUniqueIdentifier()] = saveable.CaptureState();
            }
            state[lastSceneBuildIndexId] = SceneManager.GetActiveScene().buildIndex;
        }

        void RestoreState(Dictionary<string, object> state) {
            foreach (SaveableEntity saveable in FindObjectsOfType<SaveableEntity>()) {
                string uid = saveable.GetUniqueIdentifier();
                if (!state.ContainsKey(uid)) continue;
                    
                saveable.RestoreState(state[uid]);
            }
        }

        string GetPathFromSaveFile(string saveFile) {
            return Path.Combine(Application.persistentDataPath, saveFile) + saveFileExtension;
        }
    }
}
