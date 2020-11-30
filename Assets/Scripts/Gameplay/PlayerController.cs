using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager manager;
    public GameController control;
    public ChoicesManager choicesManager;
    public PlayerAnimation playerAnimation;

    public GameObject heart1, heart2, heart3;

    public int health;

    public int notePos;

    private void Start()
    {
        notePos = 0;
        StartCoroutine(StartGame());
    }

    public void StopEnvironment() { control.StopEnvironment(); }
    public void StartEnvironment() { control.StartEnvironment(); }

    public void Hit()
    {
        //if (health < 3)
        //{
        //    // Heal the player
        //    health++;
        //    checkHealth();
        //}
        notePos++;

        // Delete the note
        GameObject note = GameObject.Find("Note");
        note.GetComponent<NoteLogic>().Kill();
        note.tag = "Untagged";
    }

    void Miss()
    {
        playerAnimation.PlayAnimation(PlayerAnimation.AnimationType.Hurt);
        health--;

        checkHealth();

        notePos++;
        choicesManager.CheckFor();
        control.scoreType.text = "Miss";
        GameObject note = GameObject.Find("Note");
        note.name = "Note(Missed)";
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.5f);
        heart1.SetActive(true);
        health = 1;

        yield return new WaitForSeconds(0.5f);
        heart2.SetActive(true);
        health = 2;

        yield return new WaitForSeconds(0.5f);
        heart3.SetActive(true);
        health = 3;
    }

    void checkHealth()
    {
        switch (health)
        {
            case 0:
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;

            case 1:
                heart1.SetActive(true);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;

            case 2:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(false);
                break;

            case 3:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                break;
        }
        if (health == 0)
        {
            manager.Fail();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Note")
        {
            other.gameObject.GetComponent<NoteLogic>().enemyController.enemyAnimation.SetTrigger("Attack");
            Miss();
            control.limiter--;
        }
    }
}
