using System.Collections.Generic;
using UnityEngine;
using Aksara.Saving;

namespace Aksara.Sound {
    public class MusicManager : MonoBehaviour, ISaveable
    {
        [SerializeField] List<AudioClip> musicList = new List<AudioClip>();

        AudioClip currentMusic = null;
        float initialAudioVolume = 1f;
        bool initialMute = false;

        AudioSource audioSource;

        void Awake() {
            audioSource = GetComponent<AudioSource>();
            audioSource.volume = initialAudioVolume;
            audioSource.mute = initialMute;
        }

        void Update() {
            if(!audioSource.isPlaying) {
                currentMusic = GetRandomMusic();
                PlayMusic(currentMusic);
            }
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

        void PlayMusic(AudioClip music) {
            audioSource.PlayOneShot(music);
        }

        AudioClip GetRandomMusic() {
            List<AudioClip> musicListFiltered = musicList;
            if(currentMusic != null) {
                musicListFiltered.Remove(currentMusic);
            }
            AudioClip[] musicListArray = musicListFiltered.ToArray();
            int randomMusicIndex = Random.Range(0, musicListArray.Length);
            return musicListArray[randomMusicIndex];
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