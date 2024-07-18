using UnityEngine;

[ExecuteInEditMode]
public class SimpleBlur : MonoBehaviour
{
    public Shader blurShader;
    private Material blurMaterial;

    [Range(0, 10)]
    public int iterations = 3;
    [Range(0.0f, 4.0f)]
    public float blurSpread = 0.6f;

    void Start()
    {
        if (blurShader == null)
        {
            Debug.LogError("Missing shader in " + ToString());
            enabled = false;
            return;
        }

        blurMaterial = new Material(blurShader);
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (blurMaterial == null)
        {
            Graphics.Blit(source, destination);
            return;
        }

        blurMaterial.SetFloat("_BlurSpread", blurSpread);
        Debug.Log("Blur Spread: " + blurSpread);

        int rtW = source.width / 4;
        int rtH = source.height / 4;

        RenderTexture buffer = RenderTexture.GetTemporary(rtW, rtH, 0);
        Graphics.Blit(source, buffer);

        for (int i = 0; i < iterations; i++)
        {
            RenderTexture buffer2 = RenderTexture.GetTemporary(rtW, rtH, 0);
            Graphics.Blit(buffer, buffer2, blurMaterial, 0);
            RenderTexture.ReleaseTemporary(buffer);
            buffer = buffer2;

            buffer2 = RenderTexture.GetTemporary(rtW, rtH, 0);
            Graphics.Blit(buffer, buffer2, blurMaterial, 0);
            RenderTexture.ReleaseTemporary(buffer);
            buffer = buffer2;
        }

        Graphics.Blit(buffer, destination);
        RenderTexture.ReleaseTemporary(buffer);
    }
}
