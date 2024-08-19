using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Sound
{
    public class GameSceneButtonSound:MonoBehaviour
    {
        [SerializeField] private Button[] buttons;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip clickSound;
        
        private void Start()
        {
            _audioSource.clip = clickSound;
            foreach (Button button in buttons)
            {
                button.onClick.AddListener(PlaySound);
            }
        }

        private void PlaySound()
        {
             _audioSource.PlayOneShot(clickSound);
        }
    }
}