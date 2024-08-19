using System;
using _Scripts.Managers.GameStateManager;
using _Scripts.System;
using UnityEngine;

namespace _Scripts.Units
{
    public class FirstGameChecker: MonoBehaviour
    {
        private void OnEnable()
        {
            GameStateManager.OnGameStateChanged += SetFirstGame;
        }

        private void OnDisable()
        {
            GameStateManager.OnGameStateChanged -= SetFirstGame;
        }

        private  void SetFirstGame(GameStates states)
        {
            if (states == GameStates.RoundFinish)
            {
                PlayerInfoManagerSO.instance.playerinfo.isFirstGame = false;
            }
        }
    }
}