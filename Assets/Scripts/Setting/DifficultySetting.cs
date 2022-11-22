using UnityEngine;
using Aksara.Core;

namespace Aksara.Setting {
    public class DifficultySetting : MonoBehaviour {
        [SerializeField] Difficulty difficulty;

        public Difficulty GetDifficulty() {
            return difficulty;
        }
    }
}
