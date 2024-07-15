using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DissolveControl : MonoBehaviour
{
    [SerializeField] private Material dissolveMat;
    [SerializeField] private UnityEvent OnEnd;

    private void Start()
    {
        dissolveMat.SetFloat("_Disslove_Amount", 0);
    }
    public void SetValue(float value)
    {
        dissolveMat.SetFloat("_Disslove_Amount", value);
        if (value >= 1)
        {
            OnEnd.Invoke();
        }
    }
}
