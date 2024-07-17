using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DissolveControl : MonoBehaviour
{
    [SerializeField] private Material dissolveMat;
    [SerializeField] private float lerpDuration = 1.0f;
    [SerializeField] private float[] levels = { 0, 0.8f, 1.8f};
    [SerializeField] private UnityEvent[] levelEvents;

    private bool loaded = true;
    private int currentLevel = 0;
    private void Start()
    {
        dissolveMat.SetFloat("_Disslove_Amount", -1f);
    }
    public void Initialize()
    {
        StartCoroutine(LoadNet());
    }
    public void LoadLevel(int level)
    {
        if (currentLevel >= level) return;

        currentLevel = level;
        loaded = false;
    }
    public void EcecuteLevel()
    {
        if (!loaded)
        {
            StartCoroutine(LerpDissloveAmount(levels[currentLevel]));
            loaded = true;
        }
    }
    IEnumerator LoadNet()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(LerpDissloveAmount(levels[0]));
    }

    private IEnumerator LerpDissloveAmount(float targetValue)
    {
        yield return new WaitForSeconds(1);

        float startValue = dissolveMat.GetFloat("_Disslove_Amount");
        float elapsedTime = 0f;

        while (elapsedTime < lerpDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / lerpDuration;
            float currentValue = Mathf.Lerp(startValue, targetValue, t);
            dissolveMat.SetFloat("_Disslove_Amount", currentValue);
            yield return null;
        }

        dissolveMat.SetFloat("_Disslove_Amount", targetValue);
        levelEvents[currentLevel].Invoke();
    }
}
