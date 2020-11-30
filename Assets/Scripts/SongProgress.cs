using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongProgress : MonoBehaviour
{
    public MusicCore map;
    public GameManager manager;
    public AudioManager audioManager;
    public Image progressBar;

    float songLength = 0;

    public void Initialized()
    {
        songLength = audioManager.music.clip.length;
    }

    void FixedUpdate()
    {
        if (map.isPlaying)
        {
            // Calculate fill amount according to song Length
            progressBar.fillAmount = map.GetSongPosition() / songLength;
            if (progressBar.fillAmount == 1)
            {
                map.isPlaying = false;
                manager.SongCompleted();
            }
        }
    }
}
