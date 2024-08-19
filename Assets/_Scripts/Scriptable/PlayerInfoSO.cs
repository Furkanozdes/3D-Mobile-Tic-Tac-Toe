using _Scripts.Managers.GameStateManager;
using _Scripts.System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Scriptable
{
    [CreateAssetMenu(fileName = "PlayerInfo", menuName = "SceneInfo")]
    public class PlayerInfoSO: ScriptableObject
    {
        [Header("PlayersInfo")]
        public PlayerSO player1;
        public PlayerSO player2;

        [Header("GameInfo")] 
        public bool isFirstGame;

        public Symbols winnerSymbol;
        public bool Player1turn;
    }
}