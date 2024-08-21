using System.Collections;
using System.Collections.Generic;
using _Scripts.Managers.GameSceneManagerUI;
using _Scripts.Managers.GameStateManager;
using _Scripts.System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIPlayerInfoView UIPlayerInfoView;

    private void Start()
    {
        UIPlayerInfoView.DisplayPlayersTurnAtStart();
    }

    private void Update()
    {
        UIPlayerInfoView.UpdateScoreTexts();
    }

    private void OnEnable()
    {
        GameStateManager.OnGameStateChanged += IncreasePlayerScore;
        GetTouchInput.OnPlayerTouched += UIPlayerInfoView.DisplayPlayersTurn;
    }

    private void OnDisable()
    {
        GameStateManager.OnGameStateChanged -= IncreasePlayerScore;
        GetTouchInput.OnPlayerTouched -= UIPlayerInfoView.DisplayPlayersTurn;
    }


    public void SetSymbol(Symbols symbol)
    {
        switch (symbol)
        {
            case Symbols.X:
                PlayerInfoManagerSO.instance.playerinfo.player1.symbol = Symbols.X;
                PlayerInfoManagerSO.instance.playerinfo.player2.symbol = Symbols.O;
                break;

            case Symbols.O:
                PlayerInfoManagerSO.instance.playerinfo.player1.symbol = Symbols.O;
                PlayerInfoManagerSO.instance.playerinfo.player2.symbol = Symbols.X;
                break;
        }
        PlayerInfoManagerSO.instance.playerinfo.isFirstGame = false;
        GameStateManager.instance.UpdateGameState(GameStates.RayCastActive);
    }

    private void IncreasePlayerScore(GameStates states)
    {
        if (states == GameStates.RoundFinish)
        {
            if (PlayerInfoManagerSO.instance.playerinfo.winnerSymbol == PlayerInfoManagerSO.instance.playerinfo.player1.symbol)
            {
                PlayerInfoManagerSO.instance.playerinfo.player1.score++;
            }
            else if (PlayerInfoManagerSO.instance.playerinfo.winnerSymbol == PlayerInfoManagerSO.instance.playerinfo.player2.symbol)
            {
                PlayerInfoManagerSO.instance.playerinfo.player2.score++;
            }
            UIPlayerInfoView.DisplayWinnerPlayer();
            UIPlayerInfoView.DeActiveDisplayPlayersTurn();
        }
    }
}