using System;
using System.Collections;
using UnityEngine;

namespace _Scripts.Managers.GameStateManager
{
    public class GameStateManager : MonoBehaviour
    {
        public static event Action<GameStates> OnGameStateChanged;
        public static GameStateManager instance;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            UpdateGameState(GameStates.DecisionSymbol);
        }

        public void UpdateGameState(GameStates currentState)
        {
            OnGameStateChanged?.Invoke(currentState);
        }
    }

    public enum GameStates
    {
        RayCastActive,      // Kullanıcının kutucuklara sembol koyabildiği durum
        RayCastDeactive,    // Kullanıcının kutucuklara sembol koyamadığı durum
        DecisionSymbol,     // Oyun başında sembol kararı verme
        RoundFinish         // Kazanan sembolün belirlendiği ve buna göre animasyon, ses gibi UI'ların aktif edildiği durum
    }
}