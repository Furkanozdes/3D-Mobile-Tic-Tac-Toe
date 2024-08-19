using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Managers.StartSceneUIManagers
{
    public class SettingsUIManager : MonoBehaviour
    {
        [Header("Buttons")] 
        [SerializeField] private Button TurnBacktoMainMenuButton;
        [Space]
        [Header("Panels")] 
        [SerializeField] private GameObject SettingPanel;
        [SerializeField] private GameObject MainMenuPanel;

        private void Start()
        {
            TurnBacktoMainMenuButton.onClick.AddListener(TurnManinMenu);
        }
        private void TurnManinMenu()
        {
            SettingPanel.SetActive(false);
            MainMenuPanel.SetActive(true);
        }
    }
}