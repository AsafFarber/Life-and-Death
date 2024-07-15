using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RestartTween : MonoBehaviour
{
    private DOTweenAnimation dotweenAnimation;

    private void Start()
    {
        dotweenAnimation = GetComponent<DOTweenAnimation>();
    }
    public void RestartTweensOnObject()
    {
        Debug.Log(gameObject.name);
        dotweenAnimation.tween.SetDelay(0);
        dotweenAnimation.tween.Restart(false);
    }
}
