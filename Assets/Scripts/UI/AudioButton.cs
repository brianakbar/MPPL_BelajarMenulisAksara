using UnityEngine;
using UnityEngine.UI;
using Aksara.Sound;

namespace Aksara.UI {
    public class AudioButton : MonoBehaviour
    {
        Button button;
        SoundManager soundManager;

        void Awake() {
            soundManager = FindObjectOfType<SoundManager>();
            button = GetComponent<Button>();
        }

        void OnEnable() {
            button.onClick.AddListener(OnClick);
        }

        void OnClick() {
            soundManager.PlayCurrentAksaraSound();
        }
    }
}
