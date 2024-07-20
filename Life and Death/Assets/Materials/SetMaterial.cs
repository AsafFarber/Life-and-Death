using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMaterial : MonoBehaviour
{
    public void SetMat(Material material)
    {
        GetComponent<Image>().material = material;
    }
}
