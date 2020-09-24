using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMBackend.MapEditor
{
    public class InputHandler : MonoBehaviour
    {
        public Timer timer;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) TogglePlayPause();
            if (Input.GetKeyDown(KeyCode.T)) timer.GetTiming();
        }

        void TogglePlayPause()
        {
            if (timer.playing == true) timer.Pause();
            else timer.UnPause();
        }
    }
}
