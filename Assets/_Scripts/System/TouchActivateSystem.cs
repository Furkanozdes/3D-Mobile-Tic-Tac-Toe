using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Managers.GameStateManager;
using _Scripts.System;
using UnityEngine;
using UnityEngine.Serialization;

public class TouchActivateSystem : MonoBehaviour
{
    [FormerlySerializedAs("touchInput")] [SerializeField] private GetTouchInput getTouchInput;
    private void OnEnable()
    {
        GameStateManager.OnGameStateChanged += GameStateConditionCheck;
        
    }

    private void OnDisable()
    {
        GameStateManager.OnGameStateChanged -= GameStateConditionCheck;
    }


    private void GameStateConditionCheck(GameStates states)
    {
        if (states == GameStates.RayCastActive)
        {
            getTouchInput.enabled = true;
        }
        else if (states == GameStates.RayCastDeactive)
        {
            getTouchInput.enabled = false;
        }
        else if (states == GameStates.RoundFinish)
        {
            getTouchInput.enabled = false;
            
        }
    }
    
    
}