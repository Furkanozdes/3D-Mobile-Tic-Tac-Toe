using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Managers.StartSceneUIManagers
{
    public class LeaderBoardUIManagers : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button TurnBackMainMenuButton;

        [Header("Panels")]
        [SerializeField] private GameObject LeaderBoardPanel;
        [SerializeField] private GameObject MainMenuPanel;
        private void Start()
        {
            TurnBackMainMenuButton.onClick.AddListener(TurnBackMainMenu);
        }

        private void TurnBackMainMenu()
        {
            LeaderBoardPanel.SetActive(false);
            MainMenuPanel.SetActive(true);
        }
        
        
    }
}