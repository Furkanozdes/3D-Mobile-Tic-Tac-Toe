using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Managers.StartSceneUIManagers
{
    public class CreditsPanelUIManager:MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button TurnBackMainMenuButton;
        [SerializeField] private GameObject CreditsCanvas;
        [SerializeField] private GameObject MainMenuPanel;

        private void Start()
        {
            TurnBackMainMenuButton.onClick.AddListener(TurnBackMainMenu);
        }
        private void TurnBackMainMenu()
        {
            CreditsCanvas.SetActive(false);
            MainMenuPanel.SetActive(true);
        }
    }
}