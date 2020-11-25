using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameController control;
    public ChoicesManager choicesManager;

    public int notePos;

    private void Start()
    {
        notePos = 0;
    }

    public void StopEnvironment() { control.StopEnvironment(); }
    public void StartEnvironment() { control.StartEnvironment(); }

    public void Hit()
    {
        notePos++;

        // Delete the note
        GameObject note = GameObject.Find("Note");
        note.GetComponent<NoteLogic>().Kill();
        note.tag = "Untagged";
    }

    void Miss()
    {
        notePos++;
        choicesManager.CheckFor();
        control.scoreType.text = "Miss";
        GameObject note = GameObject.Find("Note");
        note.name = "Note(Missed)";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Note")
        {
            Miss();
            control.limiter--;
        }
    }
}
