﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMBackend;
using Newtonsoft.Json;

public class Test : MonoBehaviour
{
    public Transform[] arts;
    public Text artist, title;
    new AudioSource audio;
    float keyTime;
    bool pause, invokeNext, invokeBack;
    int input;
    Map map;
    string[] paths = {
        "1", // 1.json
        "2"  // 2.json
    };

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        // Debug.Log(paths[0]);

        map = JsonConvert.DeserializeObject<Map>(Resources.Load<TextAsset>(paths[0]).ToString());

        // Debug.Log(Application.streamingAssetsPath + "/" + map.songPath);
        var clip = Resources.Load<AudioClip>("Songs" + "/" + map.songPath);
        audio.clip = clip;
        audio.volume = 0f;
        SetTimeSampleToPreview();
        audio.Play();
        audio.UnPause();
        artist.text = map.artist;
        title.text = map.title;

        // Debug.Log(map.songPath);
        input = 1;

        pause = false;
        invokeNext = invokeBack = false;
    }

    void FixedUpdate()
    {
        // // Debug.Log(audio.time + " / " + length);
    }

    // Update is called once per frame
    void Update()
    {
        if(invokeNext || invokeBack)
        {
            if (audio.volume > 0f)
            {
                audio.volume -= 0.05f;
                // Debug.Log(audio.volume);
                return;
            }
            else
            {
                // Debug.Log("else entered");
                if (invokeNext)
                {
                    ChangeTrack(true);
                }
                if (invokeBack)
                {
                    ChangeTrack(false);
                }
            }
        }

        if (audio.isPlaying && !pause && audio.volume != 1f)
        {
            audio.volume += 0.05f;
            // Debug.Log(audio.volume);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            invokeNext = true;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            invokeBack = true;
        }
    }

    void SetTimeSampleToPreview()
    {
        // get sample time from json
        int previewSample = map.preview;

        audio.timeSamples = previewSample;
    }

    void ChangeTrack(bool next)
    {
        if(next)
        {
            input++;
            for(int i = 0; i < arts.Length; i++)
            {
                arts[i].transform.localPosition = new Vector2(arts[i].transform.localPosition.x - 110, 0);
            }
        }
        else
        {
            input--;
            for (int i = 0; i < arts.Length; i++)
            {
                arts[i].transform.localPosition = new Vector2(arts[i].transform.localPosition.x + 110, 0);
            }
        }
        ReloadTrack();
    }

    void ReloadTrack()
    {
        // Debug.Log("Changing.");
        map = JsonConvert.DeserializeObject<Map>(Resources.Load<TextAsset>(paths[input - 1]).ToString());
        artist.text = map.artist;
        title.text = map.title;

        var clip = Resources.Load<AudioClip>("Songs" + "/" + map.songPath);
        // Debug.Log(map.songPath);
        audio.clip = clip;
        SetTimeSampleToPreview();
        audio.Play();


        invokeNext = invokeBack = false;
    }
}
