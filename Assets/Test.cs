using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMBackend;

public class Test : MonoBehaviour
{
    AudioSource audio;
    float length;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

        float time = 60f / 110f;
        Map map = MapOperations.LoadMapFromAssets("Resources/test.json");
        
        Debug.Log(map.songPath);
        var clip = Resources.Load<AudioClip>(map.songPath);
        length = clip.length;
        audio.clip = clip;
        audio.Play();
    }

    void FixedUpdate()
    {
        // Debug.Log(audio.time + " / " + length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
