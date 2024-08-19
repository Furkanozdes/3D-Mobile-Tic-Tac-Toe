using System;   
using UnityEngine;


public class Tile : MonoBehaviour           
{ 
    public static event Action<GameObject,Symbols> OnClicked;
    public Symbols symbol;
    private bool _isTouched = false;

    public bool IsTouched
    {
        get { return _isTouched; }
    }

    public void OnTileClicked(Symbols symbol) 
    {
        if (_isTouched) return;
        
        OnClicked?.Invoke(this.gameObject,symbol);
         _isTouched = true;
    }
    //ınstantiate
    
    
 
}