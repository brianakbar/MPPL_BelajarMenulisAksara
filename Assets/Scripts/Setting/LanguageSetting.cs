using UnityEngine;
using Aksara.Core;

namespace Aksara.Setting {
    public class LanguageSetting : MonoBehaviour {
        [SerializeField] Language language;

        public Language GetLanguage() {
            return language;
        }
    }
}