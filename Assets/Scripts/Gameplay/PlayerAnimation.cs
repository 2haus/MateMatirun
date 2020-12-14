using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator playerAnim;
    public ParticleSystem particleGenerator;

    public enum AnimationType { Idle, Run, Attack, Hurt };
    AnimationType types;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    public void PlayAnimation(AnimationType type)
    {
        switch(type)
        {
            case AnimationType.Idle:
                playerAnim.SetBool("isPlaying", false);
                break;

            case AnimationType.Run:
                playerAnim.SetBool("isPlaying", true);
                break;

            case AnimationType.Attack:
                playerAnim.SetTrigger("Attack");
                break;

            case AnimationType.Hurt:
                particleGenerator.Play();
                playerAnim.SetTrigger("Hurt");
                break;
        }
    }
}
