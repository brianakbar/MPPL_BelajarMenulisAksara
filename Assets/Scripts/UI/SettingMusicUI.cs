using Aksara.Sound;
using UnityEngine;
using UnityEngine.UI;

namespace Aksara.UI
{
    public class SettingMusicUI : MonoBehaviour
    {
        [SerializeField] Slider slider;
        [SerializeField] Toggle toggle;

        MusicManager musicManager;
        
        void Awake() {
            musicManager = FindObjectOfType<MusicManager>();
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
            musicManager.SetMute(!state);
        }

        public void ChangeVolume(float value) {
            musicManager.SetVolume(value);
        }

        void UpdateUI() {
            toggle.isOn = !musicManager.GetMute();
            slider.value = musicManager.GetVolume();
        }
    }
}
