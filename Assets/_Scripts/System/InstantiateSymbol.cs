using System;
using UnityEngine;

namespace _Scripts.Units
{
   
    public class InstantiateSymbol:MonoBehaviour
    {
        [SerializeField] private GameObject X;
        [SerializeField] private GameObject O;
        private GameObject newSymbol;
        [SerializeField] private AnimationsManager AnimationsManager;
        private void OnEnable()
        {
            Tile.OnClicked += InstantiateAnimation;

        }

        private void OnDisable()
        {
            Tile.OnClicked -= InstantiateAnimation;

        }
        
        private void InstantiateAnimation(GameObject Tile, Symbols symbol)
        {
            if (symbol == Symbols.O)
            {
                newSymbol = Instantiate(O, Tile.transform.position, Quaternion.identity);
            }
            else if (symbol == Symbols.X)
            {
                newSymbol = Instantiate(X, Tile.transform.position, Quaternion.identity);
            }

            AnimationsManager.PutSymbolAnimations(newSymbol);
        }
    }
}