using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScoring : MonoBehaviour
{
    public int score;

    private void Start()
    {
        score = 0;
    }
    public string HitResult(float timing, bool result)
    {
        if (timing < 0.1f && result)
        {
            score++;
            return $"{score}";
        }
        else
        {
            return "Miss";
        }
    }

    public int getScore()
    {
        return score;
    }
}
