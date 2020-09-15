using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using MMBackend;

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

        map = JsonConvert.DeserializeObject<Map>(Resources.Load<TextAsset>(paths[0]).ToString());

        var clip = Resources.Load<AudioClip>(map.songPath);
        audio.clip = clip;
        audio.volume = 0f;
        SetTimeSampleToPreview();
        audio.Play();
        audio.Pause();
        artist.text = map.artist;
        title.text = map.title;

        Debug.Log(map.songPath);
        input = 1;

        pause = true;
        invokeNext = invokeBack = false;
    }

    void FixedUpdate()
    {
        // Debug.Log(audio.time + " / " + length);
    }

    // Update is called once per frame
    void Update()
    {
        if(invokeNext || invokeBack)
        {
            if (audio.volume > 0f)
            {
                audio.volume -= 0.05f;
                Debug.Log(audio.volume);
                return;
            }
            else
            {
                Debug.Log("else entered");
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
            audio.volume += 0.05f;
            Debug.Log(audio.volume);
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
        Debug.Log("Changing.");
        map = JsonConvert.DeserializeObject<Map>(Resources.Load<TextAsset>(paths[input - 1]).ToString());
        artist.text = map.artist;
        title.text = map.title;

        var clip = Resources.Load<AudioClip>(map.songPath);
        Debug.Log(map.songPath);
        audio.clip = clip;
        SetTimeSampleToPreview();
        audio.Play();


        invokeNext = invokeBack = false;
    }
}
