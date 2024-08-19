using _Scripts.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Sound
{
    public class StartSceneButtonSound : MonoBehaviour
    {
        [SerializeField] private Button[] buttons;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip clickSound;

        [Header("SettingsButton")] 
        
        [SerializeField] private Button SoundOn;
        [SerializeField] private Button SoundOff;
        [SerializeField] private Button SFXOn;
        [SerializeField] private Button SFXOff;

        [SerializeField] private AudioSource backgroundMusicAudioSource;
        [SerializeField] private AudioSource sfxSoundAudioSource;
        
        private void Start()
        {
            Debug.Log("starttrigger");
            _audioSource.clip = clickSound;
            foreach (Button button in buttons)
            {
                button.onClick.AddListener(PlaySound);
            }
            SoundOn.onClick.AddListener(BackgroundSoundON);
            SoundOff.onClick.AddListener(BackgroundSoundOFF);
            SFXOn.onClick.AddListener(SFXOnButton);
            SFXOff.onClick.AddListener(SFXOFFButton);
        }


        private void BackgroundSoundON()
        {
            BackgroundMusic.instance.ClickSoundON();
        }

        private void BackgroundSoundOFF()
        {
            BackgroundMusic.instance.ClickSoundOFF();
        }

        private void SFXOnButton()
        {
            sfxSoundAudioSource.mute = false;
        }

        private void SFXOFFButton()
        {
            sfxSoundAudioSource.mute = true;
        }


        private void PlaySound()
        {
            _audioSource.PlayOneShot(clickSound);
        }
    }
}