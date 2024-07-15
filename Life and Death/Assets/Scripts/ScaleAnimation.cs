using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ScaleAnimation : MonoBehaviour
{
    [SerializeField] private UnityEvent OnPlay;

    [SerializeField] private float intialDelay = 0;
    [SerializeField] private Vector3 targetScale;
    [SerializeField] private float duration = 1.2f;
    private float timer = 0;
    private Vector3 initialScale;
    private bool played = false;
    void Update()
    {
        timer += Time.deltaTime;

        if (timer < intialDelay)
        {
            return;
        }
        else if (played == false)
        {
            OnPlay.Invoke();
            played = true;
            timer = 0;
            intialDelay = 0;
        }

        transform.localScale = Vector3.Slerp(Vector3.zero, targetScale, timer / duration);

        if (timer > duration)
        {
            OnPlay.Invoke();
            timer = 0;
            transform.localScale = Vector3.Slerp(Vector3.zero, targetScale, timer / duration);
        }
    }
}
