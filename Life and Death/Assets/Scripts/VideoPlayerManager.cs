using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.InputSystem;

public class VideoPlayerManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private RawImage rawImage;
    [SerializeField] private Count count;
    [SerializeField] private PlayerInput input;

    public void Play(VideoClip clip)
    {
        Debug.Log("Play");
        videoPlayer.clip = clip;
        videoPlayer.Play();
        rawImage.enabled = true;
        count.CountUp(0);
        input.enabled = true;
    }
    public void Stop()
    {
        videoPlayer.frame = 0;
        rawImage.enabled = false;
        input.enabled = false;
        videoPlayer.Stop();
    }
}
