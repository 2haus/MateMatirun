using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScoring : MonoBehaviour
{
    int i = 0;
    public string HitResult(float timing)
    {
        if (timing < 0.05f)
        {
            i++;
            return $"Fantastic ({i}/460)";
        }
        else if (timing < 0.075f)
        {
            i++;
            return $"Great ({i}/460)";
        }
        else if (timing < 0.1f)
        {
            i++;
            return $"Bad ({i}/460)";
        }
        else
        {
            return "Miss";
        }
    }
}
