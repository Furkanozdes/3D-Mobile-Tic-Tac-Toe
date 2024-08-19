using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.System;
using UnityEngine;
using DG.Tweening;

public class AnimationsManager : MonoBehaviour
{
    public static event Action OnSymbolInstantiated;
    
    private void OnEnable()
    {
        Board.OnGameWonAnimation += WinnerAnimations;
    }

    private void OnDisable()
    {
        Board.OnGameWonAnimation -= WinnerAnimations;
    }
    
    public void PutSymbolAnimations(GameObject newSymbol)
    {
        newSymbol.transform.DOShakePosition(1f, 0.25f);
        OnSymbolInstantiated?.Invoke();
    }

    private IEnumerator LineAnimation(LineRenderer lineRenderer, List<GameObject> winningTiles)
    {
        for (int i = 0; i < winningTiles.Count; i++)
        {
            Vector3 offset = new Vector3(0f, 0f, -1f);
            Vector3 position = winningTiles[i].transform.position + offset;

            lineRenderer.positionCount = i + 1;
            lineRenderer.SetPosition(i, position);
            yield return new WaitForSeconds(0.2f);
        }

        AddRoundCaps(lineRenderer, winningTiles);
    }

    private void WinnerAnimations(List<GameObject> winningTiles)
    {
        GameObject lineObject = new GameObject("WinningLine");
        LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();


        lineRenderer.startWidth = 0.4f;
        lineRenderer.endWidth = 0.2f;
        lineRenderer.positionCount = 0;


        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.cyan;


        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        StartCoroutine(LineAnimation(lineRenderer, winningTiles));
    }

    private void AddRoundCaps(LineRenderer lineRenderer, List<GameObject> winningTiles)
    {
        GameObject startCap = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject endCap = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    
        startCap.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        endCap.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    
    
        startCap.transform.position = lineRenderer.GetPosition(0);
        endCap.transform.position = lineRenderer.GetPosition(lineRenderer.positionCount - 1);
    }
}