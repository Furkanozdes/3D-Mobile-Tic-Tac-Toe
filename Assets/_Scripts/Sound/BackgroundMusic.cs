using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : Singleton<BackgroundMusic>
{
    [SerializeField] private AudioSource backgroundMusicAudioSource;
    private void Start()
    {
       base.Awake();
       DontDestroyOnLoad(this);
    }
    public void ClickSoundON()
    {
        backgroundMusicAudioSource.mute = false;
    }

    public void ClickSoundOFF()
    {
        backgroundMusicAudioSource.mute = true;
    }
    
}