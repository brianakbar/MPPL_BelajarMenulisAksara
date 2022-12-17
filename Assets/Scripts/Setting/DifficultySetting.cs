using UnityEngine;
using Aksara.Core;

namespace Aksara.Setting {
    public class DifficultySetting : MonoBehaviour {
        Difficulty difficulty;

        public void SetDifficulty(Difficulty difficulty) {
            this.difficulty = difficulty;
        }

        public Difficulty GetDifficulty() {
            return difficulty;
        }
    }
}
