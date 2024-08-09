using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Lerper : MonoBehaviour
{
    [SerializeField] private float lerpInDuration = 1;
    [SerializeField] private float lerpOutDuration = 1;
    [SerializeField] UnityEvent<float> OnLerpValueChange;
    private float lerpValue = 0;
    private float timer = 0;
    public void ZeroToValue(float value)
    {
        StartCoroutine(DoLerp(0, value, lerpInDuration));

    }
    public void ValueToZero(float value)
    {
        StartCoroutine(DoLerp(value, 0, lerpOutDuration));
    }
    private IEnumerator DoLerp(float startValue, float endValue, float lerpDuration)
    {
        //yield return new WaitForSeconds(delay);
        timer = 0;
        while (timer < lerpDuration)
        {
            timer += Time.deltaTime;
            float t = timer / lerpDuration;
            float lerpValue = Mathf.Lerp(startValue, endValue, t);
            OnLerpValueChange.Invoke(lerpValue);
            yield return null;
        }

        lerpValue = endValue;
        OnLerpValueChange.Invoke(lerpValue);
    }
}
