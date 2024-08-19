using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Managers.GameStateManager;
using _Scripts.System;
using _Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPausePanelView : MonoBehaviour
{
  [SerializeField] private GameObject pausePanel;
  [SerializeField] private GameObject PauseButton;

  private void OnEnable()
  {
    UIPlayAgainPanelView.OnPlayAgainPanelActive += ClosePauseButton;
  }

  private void OnDisable()
  {
    UIPlayAgainPanelView.OnPlayAgainPanelActive -= ClosePauseButton;
  }

  public void  PauseGameButton()
  {
      pausePanel.SetActive(true);
      GameStateManager.OnGameStateChanged?.Invoke(GameStates.RayCastDeactive);
  }

  public void ResumeGameButton()
  {
    pausePanel.SetActive(false);
    GameStateManager.OnGameStateChanged?.Invoke(GameStates.RayCastActive);
  }

  public void ExitGame()
  {
    Application.Quit();
  }
  
  private void ClosePauseButton()
  {
    PauseButton.SetActive(false);
  }

  
}
