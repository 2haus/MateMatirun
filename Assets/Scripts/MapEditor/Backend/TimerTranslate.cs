using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMBackend.MapEditor
{
    /// <summary>
    /// Debug script for Timer object to check its speed (measured in position/sec).
    /// </summary>
    public class TimerTranslate : MonoBehaviour
    {
        public AudioSource audioSource;

        float time = 0f;
        float x = 0f;

        float deltaTime = 0f;
        float deltaPos = 0f;

        void FixedUpdate()
        {
            deltaTime += (audioSource.time - time);
            deltaPos += (transform.position.x - x);

            time = audioSource.time;
            x = transform.position.x;

            if(deltaTime > 1f)
            {
                float delta = deltaPos / deltaTime;
                Debug.Log("Time: " + time + " (delta: " + deltaTime + "),  X: " + x + " (delta: " + deltaPos + "), Avg Speed: " + delta + "/sec");

                deltaPos = deltaTime = 0f;
            }
        }
    }

}