using System;
using _Scripts.Managers.GameStateManager;
using _Scripts.System;
using UnityEngine;

namespace _Scripts.Units
{
    public class CalculateSymbolScore : MonoBehaviour
    {
        private int OSymbolWinScore;
        private int XSymbolWinScore;
        private int drawScore;

        private void OnEnable()
        {
            GameStateManager.OnGameStateChanged += IncreaseSymbolCount;
        }

        private void OnDisable()
        {
            GameStateManager.OnGameStateChanged -= IncreaseSymbolCount;
        }


        [SerializeField] private JsonManager _json;

        public int OsymbolWinScore
        {
            get { return OSymbolWinScore; }
            set { OSymbolWinScore = value; }
        }

        public int XsymbolWinScore
        {
            get { return XSymbolWinScore; }
            set { XSymbolWinScore = value; }
        }

        public int DrawScore
        {
            get { return drawScore; }
            set { drawScore = value; }
        }


        private void IncreaseSymbolCount(GameStates states)
        {
            if (states == GameStates.RoundFinish)
            {
                switch (PlayerInfoManagerSO.instance.playerinfo.winnerSymbol)
                {
                    case Symbols.O:
                        OSymbolWinScore++;
                        break;
                
                    case Symbols.X:
                        XSymbolWinScore++;
                        break;
                
                    case Symbols.None:
                        drawScore++;
                        break;
                }
            }

            JsonSaveLoad();
        }


        private void JsonSaveLoad()
        {
            _json.JsonSave();
            _json.JsonLoad();
        }
    }
}