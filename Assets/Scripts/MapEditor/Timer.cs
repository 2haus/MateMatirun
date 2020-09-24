using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMBackend.MapEditor
{
    public class Timer : MonoBehaviour
    {
        public GameObject judgementPrefab;
        public new AudioSource audio;
        Transform timer;

        List<Timing> timing = new List<Timing>();

        [HideInInspector]
        public bool playing;

        // Start is called before the first frame update
        void Start()
        {
            timer = GetComponent<Transform>();

            playing = false;
        }

        // Update is called once per frame
        void Update()
        {
            if(playing)
            {
                timer.Translate(Vector3.right * 0.02f);
            }
        }

        public void GetTiming()
        {
            timing.Add(new Timing(audio.time, timer.position.x));
            Instantiate(judgementPrefab, timer.position, timer.rotation);
        }

        public void Pause()
        {
            playing = false;

            audio.Pause();
        }

        public void UnPause()
        {
            playing = true;

            audio.UnPause();
        }
    }

}