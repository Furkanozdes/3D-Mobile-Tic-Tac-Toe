using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UISymbolPanelView : MonoBehaviour   
{
    [SerializeField] private GameObject SymbolChoosePanel;
    [SerializeField] private GameManager GameManager;
    public void CheckSymbol(string symbol)
    {
        if (symbol != null)
        {
            if (symbol == "X")
            {
               GameManager.SetSymbol(Symbols.X);
            }
            else if (symbol == "O")
            {
                GameManager.SetSymbol(Symbols.O);
            }
        }
    }
    public void OpenPanel()
    {
        SymbolChoosePanel.SetActive(true);
    }

    public void ClosePanel()
    {
        SymbolChoosePanel.SetActive(false);
    }
}