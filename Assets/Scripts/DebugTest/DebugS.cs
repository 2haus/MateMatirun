using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class DebugS : MonoBehaviour
{
    public Stopwatch timer = new Stopwatch();

    public void StartTimer()
    {
        timer.Start();
    }

    public void StopTimer()
    {
        timer.Stop();

        float ts = timer.ElapsedMilliseconds;
        Debug.Log(ts / 1000);
        timer.Reset();
    }
}
