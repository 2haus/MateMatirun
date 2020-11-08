using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MusicCore map;

    public void StartCountdown(int countFromSeconds)
    {
        StartCoroutine(Countdown(countFromSeconds));
    }

    IEnumerator Countdown(int countFromSeconds)
    {
        // Countdown Delay in seconds
        for (int i = countFromSeconds; i > 0; i--)
        {
            Debug.Log(i);
            yield return new WaitForSeconds(1);
        }

        // Start Song
        map.GameStart();
    }
}
