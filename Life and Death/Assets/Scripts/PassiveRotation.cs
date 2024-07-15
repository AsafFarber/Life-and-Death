using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveRotation : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }
}
