using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Count : MonoBehaviour
{
    [SerializeField] private DissolveControl dissolveControl;

    [SerializeField] private UnityEvent<Color> OnCount;
    [SerializeField] private UnityEvent<float> OnCountF;
    [SerializeField] private UnityEvent OnOne;
    [SerializeField] private UnityEvent OnZero;
    [SerializeField] private UnityEvent<float> OnCountDown;

    private float counter = 1;
    private float addAmount;

    public void CountDown(float delay)
    {
        if (this.enabled == true) return;
        StartCoroutine(CountDownWithDelay(delay));
        OnCountDown.Invoke(dissolveControl.GetCurrentLevel());
    }
    public void CountUp(float delay)
    {
        if (this.enabled == true) return;
        StartCoroutine(CountUpWithDelay(delay));
    }
    IEnumerator CountUpWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        counter = 0;
        addAmount = 1;
        this.enabled = true;
    }
    IEnumerator CountDownWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        counter = 1;
        addAmount = -1;
        this.enabled = true;
    }
    void Update()
    {
        counter += addAmount * Time.deltaTime;
        Color color = new Color(1,1,1, counter);
        OnCount.Invoke(color);
        OnCountF.Invoke(counter);
        if (counter < 0)
        {
            OnZero.Invoke();
            this.enabled = false;
        }
        if (counter > 1)
        {
            OnOne.Invoke();
            this.enabled = false;
        }
    }
}
