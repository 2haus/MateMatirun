using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMBackend.MapEditor
{
    public enum Event
    {
        Main = 0,
        Save,
        Load,
        MapInfo,
        Unloaded
    }

    /// <summary>
    /// Input Handler component.
    /// </summary>
    public class InputHandler : MonoBehaviour
    {
        [Tooltip("Timer object.")]
        public Timer timer;

        // set event as unloaded on start
        Event current = Event.Unloaded;

        void Update()
        {
            if(current == Event.Main)
            {
                if (Input.GetKeyDown(KeyCode.Space)) TogglePlayPause();
                if (Input.GetKeyDown(KeyCode.T)) timer.GetJudgement();

                if (Input.mouseScrollDelta.y > 0f || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    timer.ScrollBack();
                }
                else if (Input.mouseScrollDelta.y < 0f || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    timer.ScrollForward();
                }
            }
        }

        void TogglePlayPause()
        {
            if (timer.GetPlayingStatus() == true) timer.Pause();
            else timer.UnPause();
        }

        /// <summary>
        /// Set current event.
        /// Mainly used for keyboard input limiting.
        /// </summary>
        /// <param name="target">Target event from Event enum.</param>
        public void SetEvent(Event target)
        {
            current = target;
        }

        /// <summary>
        /// Get current event.
        /// </summary>
        /// <returns>Current Event enum value.</returns>
        public Event GetEvent()
        {
            return current;
        }
}
}
