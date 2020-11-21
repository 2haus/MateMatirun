using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public AudioManager audioManager;

    public MusicCore map;
    public MusicScoring score;
    public MusicJudgement judge;

    public PlayerController player;
    public PlayerAnimation playerAnimation;

    public int limiter;

    public Text scoreType;

    private void Start()
    {
        limiter = 0;

        // Start running in the '90s
        playerAnimation.PlayAnimation(PlayerAnimation.AnimationType.Run);
    }

    private void Update()
    {
        if (Input.GetKeyDown("z") || Input.GetKeyDown("x")) {
            audioManager.sfxPlay();
            playerAnimation.PlayAnimation(PlayerAnimation.AnimationType.Attack);

            // Check judgement
            if (limiter > 0)
            {
                float value = map.CheckJudgement(player.notePos);
                scoreType.text = score.HitResult(value);
                player.Hit();
                limiter--;
            }
        }
    }


}
