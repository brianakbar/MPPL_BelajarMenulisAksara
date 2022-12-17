using UnityEngine;
using Aksara.Setting;
using Aksara.Core;

namespace Aksara.Sound {
    public class SoundManager : MonoBehaviour
    {
        GameSetting gameSetting;

        AudioSource audioSource;
        float initialAudioVolume = 1f;
        bool initialMute = false;

        void Awake() {
            gameSetting = FindObjectOfType<GameSetting>();
            audioSource = GetComponent<AudioSource>();
            audioSource.volume = initialAudioVolume;
            audioSource.mute = initialMute;
        }

        public void PlayCurrentAksaraSound() {
            AksaraCharacter aksara = gameSetting.GetAksaraCharacter();
            audioSource.PlayOneShot(aksara.Sound);
        }

        public void SetMute(bool state) {
            audioSource.mute = state;
        }

        public bool GetMute() {
            return audioSource.mute;
        }

        public void SetVolume(float volume) {
            if(audioSource == null) return;

            audioSource.volume = volume;
        }

        public float GetVolume() {
            return audioSource.volume;
        }

        [System.Serializable]
        class SaveRecord {
            public float audioVolume;
            public bool audioMute;
        }

        public object CaptureState() {
            SaveRecord saveRecord = new SaveRecord();
            saveRecord.audioVolume = audioSource.volume;
            saveRecord.audioMute = audioSource.mute;

            return saveRecord;
        }

        public void RestoreState(object state) {
            SaveRecord saveRecord = (SaveRecord)state;

            initialAudioVolume = saveRecord.audioVolume;
            initialMute = saveRecord.audioMute;
        }
    }
}
