using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetMovment : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private float speed = 1f;

    void Update()
    {
            // Update the shader's Directional Blur direction
            material.SetFloat("_DirectionalBlurDirection", Time.time * speed);
    }
}
