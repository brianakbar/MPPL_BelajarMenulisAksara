using Aksara.Sound;
using UnityEngine;
using UnityEngine.UI;

namespace Aksara.UI
{
    public class SettingSoundUI : MonoBehaviour
    {
        [SerializeField] Slider slider;
        [SerializeField] Toggle toggle;

        SoundManager soundManager;
        
        void Awake() {
            soundManager = FindObjectOfType<SoundManager>();
        }

        void OnEnable() {
            UpdateUI();
            slider.onValueChanged.AddListener(ChangeVolume);
            toggle.onValueChanged.AddListener(Mute);
        }

        void OnDisable() {
            slider.onValueChanged.RemoveListener(ChangeVolume);
            toggle.onValueChanged.RemoveListener(Mute);
        }

        public void Mute(bool state) {
            soundManager.SetMute(!state);
        }

        public void ChangeVolume(float value) {
            soundManager.SetVolume(value);
        }

        void UpdateUI() {
            toggle.isOn = !soundManager.GetMute();
            slider.value = soundManager.GetVolume();
        }
    }
}
