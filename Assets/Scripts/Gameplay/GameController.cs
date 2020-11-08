using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public AudioSource sfx;
    public MusicCore map;
    public MusicScoring score;
    public MusicJudgement judge;

    public Text scoreType;

    private void Update()
    {
        if (Input.GetKeyDown("z") || Input.GetKeyDown("x")) {
            sfx.Play();

            // Check judgement
            if (judge.noteID != -1)
            {
                float value = map.CheckJudgement(judge.noteID);
                Debug.Log(value);
                scoreType.text = score.HitResult(value);
            }
        }
    }


}
