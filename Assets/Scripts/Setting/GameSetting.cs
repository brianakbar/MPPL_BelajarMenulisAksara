using System.Collections.Generic;
using UnityEngine;
using Aksara.Core;

namespace Aksara.Setting {
    public class GameSetting : MonoBehaviour {
        [SerializeField] List<LevelSetting> levelSettings;

        Difficulty difficulty;
        Language language;
        AksaraCharacter aksaraCharacter;
        
        public void SetLanguage(LanguageSetting languageToSet) {
            language = languageToSet.GetLanguage();
        }

        public void SetDifficulty(DifficultySetting difficultyToSet) {
            difficulty = difficultyToSet.GetDifficulty();
        }

        public void SetAksaraCharacter(AksaraCharacter aksaraCharacter) {
            this.aksaraCharacter = aksaraCharacter;
        }

        public AksaraCharacter GetAksaraCharacter() {
            return aksaraCharacter;
        }

        public bool LoadNextAksaraCharacter() {
            LevelSetting levelSetting = GetLevelSetting();
            if(levelSetting == null) return false;

            aksaraCharacter = levelSetting.GetNextAksaraCharacter(GetAksaraCharacter());
            if(aksaraCharacter) return true;

            return false;
        }

        public LevelSetting GetLevelSetting() {
            return levelSettings.Find(item => item.Language == language && 
                                        item.Difficulty == difficulty);
        }

        public IEnumerable<AksaraCharacter> GetAksaraCharacters() {
            return GetLevelSetting().AksaraCharacters;
        }
    }
}