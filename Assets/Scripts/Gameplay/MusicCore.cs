using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMBackend;
using System.Threading;

public class MusicCore : MonoBehaviour
{
    public GameManager manager;
    public NoteSpawner spawner;

    // Song Selection Script call this method with Song class, apply all info to this variable.
    Map map = new Map();
    AudioSource song;
    float songInfo;
    public float songBPM;
    float secPerBeat;

    public float songPosition;
    float dspSongTime;
    float lastDspTime;

    private float[] judgementTime =
    {
        // Animagatari judgementTime
        1.071f,
        1.719f,
        2.044f,
        3.017f,
        3.341f,
        4.314f,
        4.638f,
        5.611f,
        5.936f,
        6.260f,
        6.909f,
        7.557f,
        8.206f,
        8.855f,
        9.179f,
        9.503f,
        9.828f,
        10.152f,
        10.476f,
        10.801f,
        11.125f,
        11.449f
    };

    float timeGap;

    public int pos = 0;
    bool isPlaying = false;

    // DEBUG PURPOSE
    public AudioSource sfx;
    int test = 0;
    int note = 0;

    public void LoadMap()
    {
        song = GetComponent<AudioSource>();
        secPerBeat = 60f / songBPM;

        // Calculate timeGap
        timeGap = songBPM / 100f;

        // Call delay if only the first judgementTime under 1/2/3 seconds (testing)
        // Call countdown
        // Start delay countdown
        manager.StartCountdown(3);
    }

    public void GameStart()
    {
        song.Play();
        dspSongTime = (float)AudioSettings.dspTime;
        lastDspTime = dspSongTime;
        isPlaying = true;
    }

    public float CheckJudgement(int note)
    {
        float timePressed = songPosition;
        float compare = Mathf.Abs(timePressed - (float)judgementTime[note]);

        return compare;
    }

    private void Update()
    {
        // Void Update
        // Call spawner method to spawn notes according to time set in judgementTime data
        // Check judgement score in another script where key pressed is detected
        if (isPlaying)
        {
            // Audio sync
            // If when the next frame grab dspTime same, then grab time from unscaledDeltaTime instead
            if (AudioSettings.dspTime == lastDspTime)
            {
                songPosition += Time.unscaledDeltaTime;
            }
            else
            {
                songPosition = (float)AudioSettings.dspTime - dspSongTime;
            }

            lastDspTime = (float)AudioSettings.dspTime;

            // Debug Test
            if (songPosition >= judgementTime[test] && test < 20)
            {
                sfx.Play();
                test++;
            }

            // Spawner
            if (songPosition >= judgementTime[pos] - timeGap && pos < 20)
            {
                float time = Mathf.Abs((judgementTime[pos] - songPosition));
                spawner.Spawn(pos, time);
                pos++;
            }
        }
    }
}
