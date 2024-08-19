using System;
using UnityEngine;

namespace _Scripts.Managers.GameStateManager
{
    public class GameStateManager : Singleton<GameStateManager>
    {
        public static Action<GameStates> OnGameStateChanged;
        
        private void Start()
        {
            base.Awake();
            OnGameStateChanged?.Invoke(GameStates.DecisionSymbol);
        }
    }

    public enum GameStates
    {
        RayCastActive, // kullanıcının kutucukalra symbol koyabildiği durum
        RayCastDeactive, // kullanıcının kutucuklara symbol koyamadığı durum
        DecisionSymbol, //oyun başında sembol karar verme.
        RoundFinish // winnersymbolün belirlendiği ve ona göre animasyon, ses gibi uıların active edildiği durum
    }
}