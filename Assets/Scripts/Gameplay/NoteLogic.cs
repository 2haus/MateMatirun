using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class NoteLogic : MonoBehaviour
{
    public int noteID;

    public float time;
    Vector2 startPosition;
    Vector2 targetPosition;
    public AudioSource sfx;
    bool once = true;

    private void Start()
    {
        startPosition = transform.position;
        targetPosition = new Vector2(-1, 0);

        StartCoroutine(Lerp());
    }

    private void Update()
    {
        if (transform.position.x <= -1 && once)
        {
            sfx.Play();
            once = false;
        }
    }

    IEnumerator Lerp()
    {
        float timeElapsed = 0;

        while (timeElapsed < time)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, timeElapsed / time);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
        transform.position = targetPosition;
    }
}
