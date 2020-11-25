using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScoring : MonoBehaviour
{
    int i = 0;
    public string HitResult(float timing, bool result)
    {
        if (timing < 0.1f && result)
        {
            i++;
            return $"{i}";
        }
        else
        {
            return "Miss";
        }
    }
}
