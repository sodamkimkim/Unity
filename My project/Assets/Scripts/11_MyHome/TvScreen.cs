using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TvScreen : MonoBehaviour
{
    private MeshRenderer mr = null;
    private VideoPlayer vp = null;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        vp = GetComponent<VideoPlayer>();
        Off();
        vp.Play();
    }

    public void On()
    {
        mr.enabled = true;
        vp.SetDirectAudioMute(0, false);
    }

    public void Off()
    {
        mr.enabled = false;
        vp.SetDirectAudioMute(0, true);
    }

    public void TogglePause()
    {
        if (!vp.isPaused) vp.Pause();
        else vp.Play();
    }
}
