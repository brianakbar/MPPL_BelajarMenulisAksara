using UnityEngine;

namespace Aksara.Core {
    [CreateAssetMenu(menuName = "Aksara/Aksara Character", fileName = "New Aksara")]
    public class AksaraCharacter : ScriptableObject {
        [SerializeField] string characterName;
        public string CharacterName { get { return characterName; } }

        [Header("Main Menu")]
        [SerializeField] Sprite mainMenuSprite;
        public Sprite MainMenuSprite { get { return mainMenuSprite; } }

        [Header("Game")]
        [SerializeField] Sprite fillSprite;
        public Sprite FillSprite { get { return fillSprite; } }
        [SerializeField] Sprite outlineSprite;
        public Sprite OutlineSprite { get { return outlineSprite; } }
        [SerializeField] [Range(0f, 1f)] float accuracy = 0.5f;
        public float Accuracy { get { return accuracy; } }
    }
}
