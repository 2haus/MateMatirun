using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using MMBackend;

public class NoteSpawner : MonoBehaviour
{
    public ChoicesManager choicesManager;

    public GameObject note;

    public void Spawn(int id, float time, bool regen)
    {
        GameObject spawnedNote = Instantiate(note, transform.position, transform.rotation);
        spawnedNote.gameObject.name = "Note";
        spawnedNote.GetComponent<NoteLogic>().time = time;
        spawnedNote.GetComponent<NoteLogic>().noteID = id;

        if (regen)
        {
            Question problem = new Question(4);
            problem = choicesManager.GetQuestion();
            // Assign question
            string operation = "";
            switch (problem.operation)
            {
                case 0:
                    operation = "+";
                    break;

                case 1:
                    operation = "-";
                    break;

                case 2:
                    operation = "*";
                    break;
            }
            spawnedNote.GetComponent<NoteLogic>().bubble.SetActive(true);
            spawnedNote.GetComponent<NoteLogic>().question.text = $"{problem.x}{operation}{problem.y}";
        }
        else
        {
            spawnedNote.GetComponent<NoteLogic>().question.text = "";
        }
    }
}
