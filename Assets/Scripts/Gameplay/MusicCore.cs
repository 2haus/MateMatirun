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

    float universalOffset;

    private float[] judgementTime =
    {
        // Animagatari Medium judgementTime
        1.071f,
        1.719f,
        2.368f,
        3.017f,
        3.665f,
        4.314f,
        4.963f,
        5.611f,
        5.936f,
        6.260f,
        6.909f,
        7.557f,
        8.206f,
        8.530f,
        8.855f,
        9.503f,
        10.152f,
        10.801f,
        11.449f,
        12.098f,
        12.746f,
        13.395f,
        14.044f,
        14.692f,
        15.341f,
        15.665f,
        15.990f,
        16.314f,
        16.638f,
        17.287f,
        17.936f,
        18.260f,
        18.584f,
        18.909f,
        19.233f,
        19.882f,
        20.530f,
        21.179f,
        21.503f,
        21.828f,
        23.125f,
        24.098f,
        24.422f,
        25.071f,
        25.719f,
        26.206f,
        26.692f,
        27.017f,
        27.665f,
        28.314f,
        28.963f,
        29.287f,
        29.611f,
        30.098f,
        30.584f,
        30.909f,
        31.395f,
        31.882f,
        32.206f,
        32.855f,
        33.503f,
        34.152f,
        34.801f,
        35.449f,
        36.098f,
        36.422f,
        36.746f,
        37.395f,
        38.044f,
        38.692f,
        39.017f,
        39.341f,
        39.665f,
        45.179f,
        45.828f,
        46.476f,
        46.963f,
        47.449f,
        47.773f,
        48.422f,
        49.071f,
        49.395f,
        49.719f,
        50.044f,
        50.368f,
        51.665f,
        52.963f,
        54.260f,
        54.909f,
        55.557f,
        56.855f,
        60.746f,
        61.071f,
        61.395f,
        61.719f,
        62.044f,
        62.368f,
        62.692f,
        63.017f,
        63.341f,
        63.665f,
        63.990f,
        64.314f,
        64.638f,
        65.125f,
        65.611f,
        65.936f,
        66.584f,
        66.909f,
        67.233f,
        67.719f,
        68.206f,
        68.530f,
        69.179f,
        69.828f,
        70.801f,
        71.125f,
        71.449f,
        71.773f,
        72.098f,
        72.422f,
        72.746f,
        73.071f,
        73.395f,
        73.719f,
        74.044f,
        74.368f,
        74.692f,
        75.017f,
        75.503f,
        75.990f,
        76.314f,
        76.801f,
        77.287f,
        77.611f,
        78.098f,
        78.584f,
        78.909f,
        79.557f,
        80.206f,
        81.179f,
        81.503f,
        82.152f,
        82.801f,
        83.449f,
        83.773f,
        84.134f,
        84.782f,
        85.431f,
        86.079f,
        86.728f
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
        universalOffset = 0;
        dspSongTime = (float)AudioSettings.dspTime;
        lastDspTime = dspSongTime;
        isPlaying = true;
    }

    public float CheckJudgement(int note)
    {
        float timePressed = songPosition;
        float compare = Mathf.Abs(timePressed - (float)judgementTime[note]);
        Debug.Log(timePressed - (float)judgementTime[note]);

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
            if (songPosition >= judgementTime[test] + universalOffset && test < judgementTime.Length - 1)
            {
                //sfx.Play();
                test++;
            }

            // Spawner
            if (songPosition >= judgementTime[pos] - timeGap + universalOffset && pos < judgementTime.Length - 1)
            {
                float time = Mathf.Abs((judgementTime[pos] - songPosition));
                spawner.Spawn(pos, time);
                pos++;
            }
        }
    }
}
