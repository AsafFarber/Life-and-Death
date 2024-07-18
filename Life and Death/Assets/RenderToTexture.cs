using UnityEngine;

public class RenderToTexture : MonoBehaviour
{
    public Camera renderCamera;
    public RenderTexture renderTexture;

    void Start()
    {
        renderCamera.targetTexture = renderTexture;
    }
}