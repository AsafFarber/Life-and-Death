using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DissolveControl : MonoBehaviour
{
    [SerializeField] private float intiialValue = -1;
    [SerializeField] private bool initializeOnStart;

    [SerializeField] private Material dissolveMat;
    [SerializeField] private float lerpDuration = 1.0f;
    [SerializeField] private float[] levels = { 0, 0.8f, 1.8f};
    [SerializeField] private UnityEvent[] onLevelLoaded;

    private bool loaded = true;
    private int currentLevel = -1;
    private int lastVideoLevel = 0;

    public int GetCurrentLevel() => currentLevel;
    public int GetLastVideoLevel() => lastVideoLevel;


    private void Start()
    {
        dissolveMat.SetFloat("_Disslove_Amount", intiialValue);
        if (initializeOnStart)
            Initialize();
    }
    public void Initialize()
    {
        currentLevel = 0;
        StartCoroutine(LerpDissloveAmount(levels[0], 0));
    }
    public void LoadLevel(int level)
    {
        lastVideoLevel = level;

        if (currentLevel >= level) return;

        currentLevel = level;
        loaded = false;
    }
    public void EcecuteLevel()
    {
        if (!loaded)
        {
            StartCoroutine(LerpDissloveAmount(levels[currentLevel] , 1));
            loaded = true;
        }
    }
    //IEnumerator LoadNet()
    //{
    //    //yield return new WaitForSeconds(1);
    //}

    private IEnumerator LerpDissloveAmount(float targetValue,  float delay)
    {
        yield return new WaitForSeconds(delay);

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
        onLevelLoaded[currentLevel]?.Invoke();
    }
}
