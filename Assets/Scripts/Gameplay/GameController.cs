using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public AudioManager audioManager;

    public MusicCore map;
    public MusicScoring score;
    public MusicJudgement judge;
    public ChoicesManager choicesManager;

    public PlayerController player;
    public PlayerAnimation playerAnimation;

    public int limiter;

    public Text scoreType;

    public float environmentSpeedControl;

    private void Start()
    {
        limiter = 0;
        environmentSpeedControl = 0.035f;

        // Start running in the '90s
        playerAnimation.PlayAnimation(PlayerAnimation.AnimationType.Run);
    }

    //private void Update()
    //{
        //if (Input.GetKeyDown("z") || Input.GetKeyDown("x")) {
        //    audioManager.sfxPlay();
        //    playerAnimation.PlayAnimation(PlayerAnimation.AnimationType.Attack);

        //    environmentSpeedControl = 0f;

        //    // Check judgement
        //    if (limiter > 0)
        //    {
        //        float value = map.CheckJudgement(player.notePos);
        //        scoreType.text = score.HitResult(value, true);
        //        player.Hit();
        //        limiter--;
        //    }
        //}
    //}

    public void OnPlayerHit(int answer)
    {
        audioManager.sfxPlay();
        playerAnimation.PlayAnimation(PlayerAnimation.AnimationType.Attack);

        environmentSpeedControl = 0f;

        if (limiter > 0)
        {
            if (answer == choicesManager.problem.result)
            {
                float value = map.CheckJudgement(player.notePos);
                string result = score.HitResult(value, true);
                scoreType.text = result;
                choicesManager.CheckFor();
                player.Hit();
            }
            else
            {
                float value = map.CheckJudgement(player.notePos);
                scoreType.text = score.HitResult(value, false);
                choicesManager.CheckFor();
                player.Hit();
            }
            limiter--;
        }
    }

    public void StopEnvironment() { environmentSpeedControl = 0f; }
    public void StartEnvironment() { environmentSpeedControl = 0.035f; }
}
