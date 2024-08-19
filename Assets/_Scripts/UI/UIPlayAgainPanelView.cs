using System;
using _Scripts.Managers.GameStateManager;
using _Scripts.System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.UI
{
    public class UIPlayAgainPanelView : MonoBehaviour
    {
        [SerializeField] private GameObject PlayAgainPanel;
        public static event Action OnPlayAgainPanelActive;


        private void OnEnable()
        {
            GameStateManager.OnGameStateChanged += ShowPlayAgainButtonActive;
        }

        private void OnDisable()
        {
            GameStateManager.OnGameStateChanged -= ShowPlayAgainButtonActive;
        }

        private void ShowPlayAgainButtonActive(GameStates states)
        {
            PlayAgainPanel.SetActive(states == GameStates.RoundFinish);
            if (states == GameStates.RoundFinish)
            {
                OnPlayAgainPanelActive?.Invoke();
            }
        }
        
    }
}