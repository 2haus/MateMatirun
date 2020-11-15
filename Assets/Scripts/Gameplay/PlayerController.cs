using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameController control;
    public int notePos;

    private void Start()
    {
        notePos = 0;
    }

    public void Hit()
    {
        notePos++;

        // Delete the note
        GameObject note = GameObject.Find("Note");
        Destroy(note);
    }

    void Miss()
    {
        notePos++;
        control.scoreType.text = "Miss";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Note")
        {
            Miss();
            control.limiter--;
            Destroy(other.gameObject);
        }
    }
}
