using System;
using System.IO;
using _Scripts.Units;
using UnityEngine;

public class JsonManager : MonoBehaviour
{
    public CalculateSymbolScore CalculateSymbolScore;
    
    private void Start()
    {
        JsonLoad();
    }
    public void JsonSave()
    {
        
        BoardData data = new BoardData
        {
            oSymbolCount = CalculateSymbolScore.OsymbolWinScore,
            xSymbolCount = CalculateSymbolScore.XsymbolWinScore,
            drawCount = CalculateSymbolScore.DrawScore
        };

        string jsonString = JsonUtility.ToJson(data);
        string filePath = Application.persistentDataPath + "/User.json";
        File.WriteAllText(filePath, jsonString);
    }

    public void JsonLoad()
    {
        string filePath = Application.persistentDataPath + "/User.json";
        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            BoardData data = JsonUtility.FromJson<BoardData>(jsonString);

            CalculateSymbolScore.OsymbolWinScore = data.oSymbolCount;
            CalculateSymbolScore.XsymbolWinScore = data.xSymbolCount;
            CalculateSymbolScore.DrawScore = data.drawCount;
        }
    }
}

[Serializable]
public struct BoardData
{
    public int oSymbolCount;
    public int xSymbolCount;
    public int drawCount;
}