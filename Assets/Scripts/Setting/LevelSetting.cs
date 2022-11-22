using System.Collections.Generic;
using UnityEngine;
using Aksara.Core;

namespace Aksara.Setting
{
    [CreateAssetMenu(menuName = "Aksara/Level", fileName = "New Level")]
    public class LevelSetting : ScriptableObject
    {
        [SerializeField] Language language;
        public Language Language { get { return language; } }
        [SerializeField] Sprite languageSprite;
        public Sprite LanguageSprite { get { return languageSprite; } }
        [SerializeField] Difficulty difficulty;
        public Difficulty Difficulty { get { return difficulty; } }
        [SerializeField] List<AksaraCharacter> aksaraCharacters = new List<AksaraCharacter>();
        public List<AksaraCharacter> AksaraCharacters { get { return aksaraCharacters; } }

        public AksaraCharacter GetNextAksaraCharacter(AksaraCharacter currentAksara) {
            if(currentAksara == null) return null;

            int currentAksaraIndex = aksaraCharacters.IndexOf(currentAksara);
            if(aksaraCharacters.Count <= currentAksaraIndex+1) return null;

            return aksaraCharacters[currentAksaraIndex+1];
        }
    }
}