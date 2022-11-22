using UnityEngine;

namespace Aksara.Core {
    public class PersistentObjectSpawner : MonoBehaviour {
        [SerializeField] GameObject persistentObjectsPrefab;

        static bool hasSpawned = false;

        void Awake() {
            if(hasSpawned) return;

            SpawnPersistentObjects();
            hasSpawned = true;
        }

        void SpawnPersistentObjects() {
            GameObject persistentObjects = Instantiate(persistentObjectsPrefab);
            DontDestroyOnLoad(persistentObjects);
        }
    }
}
