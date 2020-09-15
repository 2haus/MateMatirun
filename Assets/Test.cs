using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using MMBackend;

public class Test : MonoBehaviour
{
    new AudioSource audio;
    float length;
    float keyTime;
    float fadeTime;
    int presses;
    bool pause;
    Map map;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

        map = JsonConvert.DeserializeObject<Map>(Resources.Load<TextAsset>("test").ToString());
        
        Debug.Log(map.songPath);
        var clip = Resources.Load<AudioClip>(map.songPath);
        length = clip.length;
        audio.clip = clip;
        audio.volume = 0f;
        SetTimeSampleToPreview();
        audio.Play();
        audio.Pause();
        pause = true;
        fadeTime = 0;
        presses = 0;
    }

    void FixedUpdate()
    {
        // Debug.Log(audio.time + " / " + length);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && pause && !audio.isPlaying)
        {
            pause = false;
            audio.UnPause();
        }
        else if (Input.GetKeyDown(KeyCode.H) && !pause && audio.isPlaying)
        {
            pause = true;
        }

        if (audio.isPlaying && !pause && audio.volume != 1f)
        {
            audio.volume += 0.005f;
            Debug.Log(audio.volume);
        }
        else if(audio.isPlaying && pause && audio.volume != 0f)
        {
            audio.volume -= 0.005f;
            Debug.Log(audio.volume);
            if(audio.volume == 0f)
            {
                pause = true;
                audio.Pause();

                // this time, after paused, change sample back
                SetTimeSampleToPreview();
            }
        }


        // Debug.Log(audio.timeSamples);

        // j, j, space, f, finish
        if(Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Space))
        {
            keyTime = audio.time;
            Debug.Log("Pressed on: " + keyTime);

            if(Input.GetKeyDown(KeyCode.F) && map.types[presses] == NoteTypes.BackEnemy)
            {
                presses++;
                Debug.Log("Time: " + map.CompareTime(presses - 1, keyTime));
            }
            else if(Input.GetKeyDown(KeyCode.J) && map.types[presses] == NoteTypes.FrontEnemy)
            {
                presses++;
                Debug.Log("Time: " + map.CompareTime(presses - 1, keyTime));
            }
            else if(Input.GetKeyDown(KeyCode.Space) && map.types[presses] == NoteTypes.Pit)
            {
                presses++;
                Debug.Log("Time: " + map.CompareTime(presses - 1, keyTime));
            }
        }
    }

    void SetTimeSampleToPreview()
    {
        // get sample time from json
        int previewSample = 1029235;

        audio.timeSamples = previewSample;
    }
}
