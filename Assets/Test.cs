using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMBackend;

public class Test : MonoBehaviour
{
    new AudioSource audio;
    float length;
    float keyTime;
    int presses;
    Map map;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

        map = MapOperations.LoadMapFromAssets("Resources/test.json");
        
        Debug.Log(map.songPath);
        var clip = Resources.Load<AudioClip>(map.songPath);
        length = clip.length;
        audio.clip = clip;
        audio.Play();
        presses = 0;
    }

    void FixedUpdate()
    {
        // Debug.Log(audio.time + " / " + length);
    }

    // Update is called once per frame
    void Update()
    {
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
}
