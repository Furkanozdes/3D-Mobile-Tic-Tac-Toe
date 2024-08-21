using _Scripts.Managers.GameStateManager;
using _Scripts.System;
using UnityEngine;


public class SymbolPanelUIManager : MonoBehaviour
{
    [SerializeField] private UISymbolPanelView UISymbolPanelView;

    private void OnEnable()
    {
        GameStateManager.OnGameStateChanged += CheckSymbolPanel;
    }

    private void OnDisable()
    {
        GameStateManager.OnGameStateChanged -= CheckSymbolPanel;
    }

    public void CheckSymbolPanel(GameStates states)
    {
        if (states == GameStates.DecisionSymbol)
        {
            if (PlayerInfoManagerSO.instance.playerinfo.isFirstGame == true)
            { 
                UISymbolPanelView.OpenPanel();
            }
            else if (PlayerInfoManagerSO.instance.playerinfo.isFirstGame == false)
            {
                UISymbolPanelView.ClosePanel();
                GameStateManager.instance.UpdateGameState(GameStates.RayCastActive);
            }
        }
        else
        {
            UISymbolPanelView.ClosePanel();
        }
    }
}