using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BackgroundAudio
{
    //private static AudioSource bgMusic;
    private static bool isPlaying = false;

    public static bool audioStatus
    {
        get
        {
            return isPlaying;
        }
        set
        {
            isPlaying = value;
        }
    }
}
