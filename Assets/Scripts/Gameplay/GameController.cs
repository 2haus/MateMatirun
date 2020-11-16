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
    public PlayerController player;

    public int limiter;

    public Text scoreType;

    private void Start()
    {
        limiter = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown("z") || Input.GetKeyDown("x")) {
            sfx.Play();

            // Check judgement
            if (limiter > 0)
            {
                float value = map.CheckJudgement(player.notePos);
                Debug.Log(value);
                scoreType.text = score.HitResult(value);
                player.Hit();
                limiter--;
            }
        }
    }


}
