using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMBackend;
using System.Threading;

public class MusicCore : MonoBehaviour
{
    public GameManager gameManager;
    public AudioManager audioManager;
    public NoteSpawner spawner;

    public ProblemGenerator generator;

    // Song Selection Script call this method with Song class, apply all info to this variable.
    string songArtist;
    string songTitle;
    [SerializeField]
    float songBPM;
    float secPerBeat;

    public float songPosition;
    float dspSongTime;
    float lastDspTime;

    float universalOffset;

    Timing[] judgementTime;

    float timeGap;

    public int pos = 0;
    bool isPlaying = false;

    public void LoadMap(Map map)
    {
        // Assign map data to local variable
        songArtist = map.artist;
        songTitle = map.title;
        songBPM = map.bpm;

        judgementTime = map.timings;

        universalOffset = audioManager.universalOffset;

        // Difficulty set to easy
        generator.Initialization(2);

        audioManager.Initialized(map);
        secPerBeat = 60f / songBPM;

        // Calculate timeGap (speed)
        timeGap = 200f / songBPM;

        // Call delay if only the first judgementTime under 1/2/3 seconds (testing)
        // Call countdown
        // Start delay countdown
        gameManager.StartCountdown(3);
    }

    public void GameStart()
    {
        audioManager.musicPlay();
        universalOffset = 0;
        dspSongTime = (float)AudioSettings.dspTime;
        lastDspTime = dspSongTime;
        isPlaying = true;
    }

    public float CheckJudgement(int note)
    {
        float timePressed = songPosition;
        float compare = Mathf.Abs(timePressed - (float)judgementTime[note].time);
        //Debug.Log(timePressed - (float)judgementTime[note].time);

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
            //if (songPosition >= judgementTime[test].time + (universalOffset/1000) && test < judgementTime.Length - 1)
            //{
            //    //sfx.Play();
            //    test++;
            //}

            // Spawner
            if (songPosition >= judgementTime[pos].time - timeGap + (universalOffset / 1000) && pos < judgementTime.Length - 1)
            {
                if (judgementTime[pos].regenerate)
                {
                    generator.GenerateProblem();
                    generator.GenerateChoices();

                    // DEBUG ONLY
                    string operation = "";
                    switch (generator.operation)
                    {
                        case 0: operation = "+"; break;
                        case 1: operation = "-"; break;
                        case 2: operation = "*"; break;
                    }
                    Debug.Log($"Problems");
                    Debug.Log($"{generator.x} {operation} {generator.y} = ?");
                    for (int i = 0; i < 2; i++)
                    {
                        Debug.Log($"[{i}] {generator.choices[i]}");
                    }
                }
                float time = Mathf.Abs((judgementTime[pos].time - songPosition));
                spawner.Spawn(pos, time);
                pos++;
            }
        }
    }
}
