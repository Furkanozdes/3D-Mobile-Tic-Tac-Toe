using System;
using System.Collections.Generic;
using _Scripts.Managers.GameStateManager;
using _Scripts.System;
using UnityEngine;

[System.Serializable]
public class Board : MonoBehaviour
{
    [SerializeField] public List<GameObject> tiles;
    bool isDraw = true;

    public static event Action<List<GameObject>> OnGameWonAnimation;

    private Symbols[,] board = new Symbols[3, 3];


    private int[,] winningCombinations = new int[,]
    {
        { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 },
        { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 },
        { 0, 4, 8 }, { 2, 4, 6 }
    };

    private void OnEnable()
    {
        Tile.OnClicked += SetSymbol;
    }

    private void OnDisable()
    {
        Tile.OnClicked -= SetSymbol;
    }


    public void SetSymbol(GameObject tile, Symbols symbol)
    {
        //getcomponent araştır
        int index = tiles.IndexOf(tile);
        board[index / 3, index % 3] = symbol;
        tile.GetComponent<Tile>().symbol = symbol;
        CheckWinner();
    }

    private void CheckWinner()
    {
        isDraw = true;
        for (int i = 0; i < winningCombinations.GetLength(0); i++)
        {
            int a = winningCombinations[i, 0];
            int b = winningCombinations[i, 1];
            int c = winningCombinations[i, 2];

            if (tiles[a].GetComponent<Tile>().symbol != Symbols.None &&
                tiles[a].GetComponent<Tile>().symbol == tiles[b].GetComponent<Tile>().symbol &&
                tiles[a].GetComponent<Tile>().symbol == tiles[c].GetComponent<Tile>().symbol) // kazanma durumu
            {
                List<GameObject> winningTiles = new List<GameObject> { tiles[a], tiles[b], tiles[c] };
                OnGameWonAnimation?.Invoke(winningTiles);
                PlayerInfoManagerSO.instance.playerinfo.winnerSymbol = tiles[a].GetComponent<Tile>().symbol;
                GameStateManager.OnGameStateChanged?.Invoke(GameStates.RoundFinish);
                return;
            }
        }

        foreach (var tile in tiles) // beraberlik kontrol (kazanan yoksa boş yani symbolsüz tile var mı)
        {
            if (tile.GetComponent<Tile>().symbol == Symbols.None)
            {
                isDraw = false;
                break;
            }
        }

        if (isDraw) // beraberlik durumu
        {
            PlayerInfoManagerSO.instance.playerinfo.winnerSymbol = Symbols.None;
            GameStateManager.OnGameStateChanged?.Invoke(GameStates.RoundFinish);
        }
    }
}