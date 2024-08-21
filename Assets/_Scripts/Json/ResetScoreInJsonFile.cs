using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Json
{
    public class ResetScoreInJsonFile: MonoBehaviour
    {
        [Header("Buttons")] [SerializeField] private Button ResetButton;

        public static event Action OnScoresReseted;
        private void Start()
        {
            ResetButton.onClick.AddListener(ResetVariable);
        }
        
        private void ResetVariable()
        {
            string filePath = Application.persistentDataPath + "/User.json";

            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                BoardData data = JsonUtility.FromJson<BoardData>(jsonString);
                
                data.oSymbolCount = 0;
                data.xSymbolCount = 0;
                data.drawCount = 0;
                
                string updatedJsonString = JsonUtility.ToJson(data);
                File.WriteAllText(filePath, updatedJsonString);
                OnScoresReseted?.Invoke();
            }
        }
    }
}