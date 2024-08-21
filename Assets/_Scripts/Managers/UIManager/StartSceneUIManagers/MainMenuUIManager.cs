using System;
using _Scripts.Managers.GameStateManager;
using _Scripts.System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts.Managers.StartSceneUIManagers
{
    public class MainMenuUIManager : MonoBehaviour
    {
        [Header("MainMenu Button")] [SerializeField]
        private Button LeaderBoardButton;

        [SerializeField] private Button StartButton;
        [SerializeField] private Button SettingsButton;
        [SerializeField] private Button ExitButton;
        [SerializeField] private Button CreditsButton;

        [Space] [Header("Panels")] [SerializeField]
        private GameObject MainPanel;

        [SerializeField] private GameObject SettingPanel;
        [SerializeField] private GameObject LeaderBoardPanel;
        [SerializeField] private GameObject CreditsPanel;

        private void Start()
        {
            StartButton.onClick.AddListener(LoadGameScene);
            SettingsButton.onClick.AddListener(LoadSettingPanel);
            LeaderBoardButton.onClick.AddListener(LoadLeaderBoardPanel);
            ExitButton.onClick.AddListener(ExitGame);
            CreditsButton.onClick.AddListener(LoadCreditsPanel);
        }

        private void LoadGameScene()
        {
            ScenePrepration();
            SceneManager.LoadSceneAsync("GameScene");
        }

        private void ScenePrepration()
        {
            PlayerInfoManagerSO.instance.playerinfo.isFirstGame = true;
            PlayerInfoManagerSO.instance.playerinfo.Player1turn = true;
            PlayerInfoManagerSO.instance.playerinfo.player1.score = 0;
            PlayerInfoManagerSO.instance.playerinfo.player2.score = 0;
        }

        private void LoadSettingPanel()
        {
            SettingPanel.SetActive(true);
            MainPanel.SetActive(false);
        }

        private void LoadLeaderBoardPanel()
        {
            LeaderBoardPanel.SetActive(true);
            MainPanel.SetActive(false);
        }

        private void ExitGame()
        {
            Application.Quit();
        }

        private void LoadCreditsPanel()
        {
            CreditsPanel.SetActive(true);
            MainPanel.SetActive(false);
        }
    }
}