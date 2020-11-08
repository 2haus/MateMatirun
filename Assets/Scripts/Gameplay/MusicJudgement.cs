using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicJudgement : MonoBehaviour
{
    public int noteID; 

    public int enterNote;
    public int exitNote;

    private void Start()
    {
        noteID = -1;
    }

    private void OnTriggerEnter2D(Collider2D note)
    {
        noteID = note.gameObject.GetComponent<NoteLogic>().noteID;
    }
}
