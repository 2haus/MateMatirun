using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class NoteSpawner : MonoBehaviour
{
    public GameObject note;

    public void Spawn(int id, float time)
    {
        GameObject spawnedNote = (GameObject)Instantiate(note, transform.position, transform.rotation);
        spawnedNote.GetComponent<NoteLogic>().time = time;
        spawnedNote.GetComponent<NoteLogic>().noteID = id;
    }
}
