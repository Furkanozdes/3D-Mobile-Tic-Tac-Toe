using _Scripts.System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Managers
{
    public class SceneLoadManager : MonoBehaviour
    {
        public void MainMenu()
        {
            SceneManager.LoadSceneAsync("StartScene");
        }

        public void Playagain()
        {
            PlayerInfoManagerSO.instance.playerinfo.Player1turn = !PlayerInfoManagerSO.instance.playerinfo.Player1turn;
            SceneManager.LoadSceneAsync("GameScene");
        }

        public void PlayAgainPauseMenu()
        {
            SceneManager.LoadSceneAsync("GameScene");
        }
    }
}