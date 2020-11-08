using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScoring : MonoBehaviour
{
    public string HitResult(float timing)
    {
        if (timing < 0.05f)
        {
            return "Fantastic";
        }
        else if (timing < 0.075f)
        {
            return "Great";
        }
        else if (timing < 0.1f)
        {
            return "Bad";
        }
        else
        {
            return "Miss";
        }
    }
}
