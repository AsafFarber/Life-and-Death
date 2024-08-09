using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class VideoPlayerManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private RawImage rawImage;
    [SerializeField] private Count count;
    [SerializeField] private PlayerInput input;
    [SerializeField] private DissolveControl dissolveControl;

    [SerializeField] private UnityEvent OnPlay; // lerp sound fade in/out
    [SerializeField] private UnityEvent OnStop; // lerp sound fade in/out
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = videoPlayer.GetComponent<AudioSource>();
    }
    public void Play(VideoClip clip)
    {
        if(videoPlayer.clip == clip)
        {
            ShowVideo();
            return;
        }
        videoPlayer.clip = clip;
        videoPlayer.Prepare();
        videoPlayer.prepareCompleted += OnVideoPrepared;
    }
    public void Stop()
    {
        videoPlayer.frame = 0;
        rawImage.enabled = false;
        input.enabled = false;
        videoPlayer.Pause();
        if (dissolveControl.GetCurrentLevel() > 1)
            OnStop.Invoke();
    }
    private void OnVideoPrepared(VideoPlayer vp)
    {
        videoPlayer.prepareCompleted -= OnVideoPrepared;
        ShowVideo();
    }
    private void ShowVideo()
    {
        videoPlayer.Play();
        rawImage.enabled = true;
        count.CountUp(0);
        input.enabled = true;
        videoPlayer.SetTargetAudioSource(0, audioSource);
        if(dissolveControl.GetCurrentLevel() > 1)
            OnPlay.Invoke();
    }
}
