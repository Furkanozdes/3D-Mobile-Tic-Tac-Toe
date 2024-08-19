using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Scriptable;
using _Scripts.System;
using _Scripts.UI;
using UnityEngine;
using UnityEngine.Serialization;

public class GetTouchInput : MonoBehaviour
{
    private bool isplayer1;
    
    
    public static event Action<bool> OnPlayerTouched;
    
        void Start()
        {
            isplayer1 = PlayerInfoManagerSO.instance.playerinfo.Player1turn;
        }
    
        void Update()
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Tile tile = hit.collider.GetComponent<Tile>();
                    if (tile != null && !tile.IsTouched)
                    {
                        
                        if (isplayer1)
                        {
                            isplayer1 = false; 
                            OnPlayerTouched?.Invoke(isplayer1);
                            tile.OnTileClicked(PlayerInfoManagerSO.instance.playerinfo.player1.symbol);   
                        }
                        else
                        {
                            isplayer1 = true; 
                            OnPlayerTouched?.Invoke(isplayer1);
                            tile.OnTileClicked(PlayerInfoManagerSO.instance.playerinfo.player2.symbol);
                        }
                    }
                }
            }
        }
}

