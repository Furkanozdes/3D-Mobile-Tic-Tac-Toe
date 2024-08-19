using _Scripts.Managers.GameStateManager;
using _Scripts.System;
using UnityEngine;


public class AnimationSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSource; 
    [SerializeField] private AudioClip symbolInstantiateClip; 
    [SerializeField] private AudioClip DrawAnimationClip; 
    [SerializeField] private AudioClip XWinGameAnimationClip;
    [SerializeField] private AudioClip OWinGameAnimationClip;
    private void OnEnable()
    {
        AnimationsManager.OnSymbolInstantiated += PlaySoundPutOnSymbol;
        GameStateManager.OnGameStateChanged += PlaySoundWinAnimation;
    }

    private void OnDisable()
    {
        AnimationsManager.OnSymbolInstantiated -= PlaySoundPutOnSymbol;
        GameStateManager.OnGameStateChanged -= PlaySoundWinAnimation;
    }

    private void PlaySoundPutOnSymbol()
    {
        AudioSource.clip = symbolInstantiateClip;
        AudioSource.Play();
    }
    private void PlaySoundWinAnimation(GameStates states)
    {
        if (states == GameStates.RoundFinish)
        {
            switch (PlayerInfoManagerSO.instance.playerinfo.winnerSymbol)
            {
                case Symbols.X:
                    AudioSource.clip = XWinGameAnimationClip;
                    break;

                case Symbols.O:
                    AudioSource.clip = OWinGameAnimationClip;
                    break;

                case Symbols.None:
                    AudioSource.clip = DrawAnimationClip;
                    break;

                default:
                    return; 
            }

            AudioSource.Play();
        }
    }

    
}
