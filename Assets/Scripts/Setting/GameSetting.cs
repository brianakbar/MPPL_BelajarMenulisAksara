using System.Collections.Generic;
using UnityEngine;
using Aksara.Core;
using Aksara.Saving;
using System;

namespace Aksara.Setting {
    public class GameSetting : MonoBehaviour, ISaveable {
        [SerializeField] List<LevelSetting> levelSettings;

        Dictionary<LevelSetting, List<AksaraCompleteRecord>> record = new Dictionary<LevelSetting, List<AksaraCompleteRecord>>();

        Difficulty difficulty;
        Language language;
        AksaraCharacter aksaraCharacter;

        class AksaraCompleteRecord {
            public AksaraCharacter aksara;
            public bool isComplete;

            public AksaraCompleteRecord(AksaraCharacter aksaraCharacter) {
                aksara = aksaraCharacter;
            }
        }

        void Awake() {
            BuildRecord();
        }

        public void SetLanguage(LanguageSetting languageToSet) {
            language = languageToSet.GetLanguage();
        }

        public void SetDifficulty(DifficultySetting difficultyToSet) {
            difficulty = difficultyToSet.GetDifficulty();
        }

        public void SetAksaraCharacter(AksaraCharacter aksaraCharacter) {
            this.aksaraCharacter = aksaraCharacter;
        }

        public void SetComplete() {
            SetComplete(GetLevelSetting(), aksaraCharacter);
        }

        public void SetComplete(LevelSetting levelSetting, AksaraCharacter aksara) {
            if(!record.ContainsKey(levelSetting)) { return; }

            var completeRecords = record[levelSetting];
            completeRecords.Find(item => item.aksara == aksara).isComplete = true;
        }

        public bool GetComplete(AksaraCharacter aksara) {
            LevelSetting levelSetting = GetLevelSetting();
            if(!record.ContainsKey(levelSetting)) { return false; }

            var completeRecords = record[levelSetting];
            return completeRecords.Find(item => item.aksara == aksara).isComplete;
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
            return GetLevelSetting(language, difficulty);
        }

        public LevelSetting GetLevelSetting(Language language, Difficulty difficulty) {
            return levelSettings.Find(item => item.Language == language && 
                                        item.Difficulty == difficulty);
        }

        public IEnumerable<AksaraCharacter> GetAksaraCharacters() {
            return GetLevelSetting().AksaraCharacters;
        }

        public IEnumerable<Difficulty> GetAksaraTypes() {
            foreach(LevelSetting setting in levelSettings) {
                if(setting.Language == language) {
                    yield return setting.Difficulty;
                }
            }
        }

        void BuildRecord() {
            foreach (var levelSetting in levelSettings) {
                var completeRecords = new List<AksaraCompleteRecord>();
                foreach (var aksara in levelSetting.AksaraCharacters) {
                    AksaraCompleteRecord completeRecord = new AksaraCompleteRecord(aksara);
                    completeRecords.Add(completeRecord);
                }
                record.Add(levelSetting, completeRecords);
            }
        }

        [System.Serializable]
        class SaveRecord {
            public Difficulty difficulty;
            public Language language;
            public string aksaraName;
        }

        object ISaveable.CaptureState() {
            List<SaveRecord> saveRecords = new List<SaveRecord>();
            foreach(var pair in record) {
                foreach(var completeRecord in pair.Value) {
                    SaveRecord saveRecord = new SaveRecord();
                    saveRecord.difficulty = pair.Key.Difficulty;
                    saveRecord.language = pair.Key.Language;
                    if(!completeRecord.isComplete) continue;
                    
                    saveRecord.aksaraName = completeRecord.aksara.CharacterName;
                    saveRecords.Add(saveRecord);
                }
            }
            return saveRecords;
        }

        void ISaveable.RestoreState(object state) {
            List<SaveRecord> saveRecords = (List<SaveRecord>)state;

            foreach(var saveRecord in saveRecords) {
                var levelSetting = GetLevelSetting(saveRecord.language, saveRecord.difficulty);
                var aksaraCharacter = levelSetting.AksaraCharacters.Find(
                                    item => item.CharacterName == saveRecord.aksaraName);
                SetComplete(levelSetting, aksaraCharacter);
            }
        }
    }
}