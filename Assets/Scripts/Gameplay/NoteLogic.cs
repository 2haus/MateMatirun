using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class NoteLogic : MonoBehaviour
{
    public EnemyController enemyController;

    public int noteID;

    public float time;
    Vector2 startPosition;
    Vector2 targetPosition;

    public bool status;

    private void Start()
    {
        status = true;
        startPosition = transform.position;
        targetPosition = new Vector2(-8.4f, transform.position.y);

        time *= 2;

        StartCoroutine(Lerp());
    }

    void Update()
    {
        if (gameObject.name == "Note(Missed)" && transform.position.x <= -8f)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Lerp()
    {
        float timeElapsed = 0;

        while (timeElapsed < time && status)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, timeElapsed / time);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
        if (status)
        {
            transform.position = targetPosition;
        }
    }

    public void Kill()
    {
        gameObject.tag = "Untagged";
        enemyController.enemyAnimation.SetTrigger("Die");
    }

    public void Destroy() { Destroy(gameObject);  }
}
