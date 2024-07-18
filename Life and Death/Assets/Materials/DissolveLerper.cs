using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveLerper : MonoBehaviour
{
    [SerializeField] private Material dissolveMat;

    private void Start()
    {
        dissolveMat.SetFloat("_Disslove_Amount", -1f);
    }

    void Update()
    {
        
    }
}
