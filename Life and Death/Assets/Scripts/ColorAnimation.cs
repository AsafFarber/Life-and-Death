using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAnimation : MonoBehaviour
{
    [SerializeField] private float initialDelay = 0;
    [SerializeField] private float delay = 0;

    [SerializeField] private Color targetColor = Color.white;
    [SerializeField] private float duration = 1.2f;

    private float timer = 0;
    private bool played = false;
    private SpriteRenderer spriteRenderer;
    private Color initialColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            initialColor = spriteRenderer.color;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer < initialDelay || timer < delay)
        {
            return;
        }
        else
        {
            if (!played)
            {
                played = true;
                timer = 0;
                initialDelay = 0;
            }
        }
        Debug.Log(timer);
        float t = (timer - delay) / duration;
        spriteRenderer.color = Color.Lerp(initialColor, targetColor, t);

        if (timer > duration)
        {
            spriteRenderer.color = Color.white;
            timer = 0;
        }
    }
}
