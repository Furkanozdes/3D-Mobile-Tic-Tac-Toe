using System;
using System.IO;
using TMPro;
using UnityEngine;

namespace _Scripts.Json
{
    public class UIDisplayJsonFileContent : MonoBehaviour
    {
        public TextMeshProUGUI OWinScore;
        public TextMeshProUGUI XWinScore;
        public TextMeshProUGUI Draws;

        private void Start()
        {
            DisplayJsonValues();
        }

        private void OnEnable()
        {
            ResetScoreInJsonFile.OnScoresReseted += DisplayJsonValues;
        }

        private void OnDisable()
        {
            ResetScoreInJsonFile.OnScoresReseted -= DisplayJsonValues;
        }

        public void DisplayJsonValues()
        {
            string filePath = Application.persistentDataPath + "/User.json";
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                BoardData data = JsonUtility.FromJson<BoardData>(jsonString);

                OWinScore.text = $"O Symbols: {data.oSymbolCount}\n";
                XWinScore.text = $"X Symbols: {data.xSymbolCount}\n";
                Draws.text = $"Draws: {data.drawCount}\n";
            }
            else
            {
                Debug.LogError("JSON file not found at path: " + filePath);
            }
        }
    }
}
