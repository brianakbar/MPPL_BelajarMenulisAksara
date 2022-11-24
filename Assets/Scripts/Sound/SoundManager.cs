using UnityEngine;
using Aksara.Setting;
using Aksara.Core;

namespace Aksara.Sound {
    public class SoundManager : MonoBehaviour
    {
        GameSetting gameSetting;
        AudioSource audioSource;

        void Awake() {
            gameSetting = FindObjectOfType<GameSetting>();
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayCurrentAksaraSound() {
            AksaraCharacter aksara = gameSetting.GetAksaraCharacter();
            audioSource.PlayOneShot(aksara.Sound);
        }
    }
}
