using System;
using _Scripts.System;
using TMPro;
using UnityEngine;

namespace _Scripts.Managers.GameSceneManagerUI
{
    //şu an aktif değil
    public class UIPlayerInfoView : MonoBehaviour
    {
       
        [SerializeField] private TextMeshProUGUI player1_text;
        [SerializeField] private TextMeshProUGUI player2_text;
        
        [SerializeField] private TextMeshProUGUI winnertext;
        [SerializeField] private TextMeshProUGUI ordertext;
        [SerializeField] private GameObject playerTurntext;

        public void UpdateScoreTexts()
        {
            player1_text.text = "Player1 Score: " + PlayerInfoManagerSO.instance.playerinfo.player1.score;
            player2_text.text = "Player2 Score: " + PlayerInfoManagerSO.instance.playerinfo.player2.score;
        }

        public void DisplayWinnerPlayer()
        {
            if (PlayerInfoManagerSO.instance.playerinfo.winnerSymbol == PlayerInfoManagerSO.instance.playerinfo.player1.symbol)
            {
                winnertext.text = ("Player 1 won !!!");
            }
            else if (PlayerInfoManagerSO.instance.playerinfo.winnerSymbol == PlayerInfoManagerSO.instance.playerinfo.player2.symbol)
            {
                winnertext.text = ("Player 2 won !!!");
            }
            else if (PlayerInfoManagerSO.instance.playerinfo.winnerSymbol == Symbols.None)
            {
                winnertext.text = ("Draw game !!!");
            }
            
        }

        public void DisplayPlayersTurn(bool playerTurn)
        {
            if (playerTurn == true)
            {
                ordertext.text = "Player1's Turn";
            }
            else if (playerTurn == false)
            {
                ordertext.text = "Player2's Turn";
            }
        }
        public void DisplayPlayersTurnAtStart()
        {
            if (PlayerInfoManagerSO.instance.playerinfo.Player1turn == true)
            {
                ordertext.text = "Player1 Start Game";
            }
            else if (PlayerInfoManagerSO.instance.playerinfo.Player1turn == false)
            {
                ordertext.text = "Player2 Start Game";
            }
        }
        
        public void DeActiveDisplayPlayersTurn()
        {
            playerTurntext.SetActive(false);
        }
    }
}