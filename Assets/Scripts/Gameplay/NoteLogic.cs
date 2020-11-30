using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteLogic : MonoBehaviour
{
    public EnemyController enemyController;
    public GameObject bubble;
    public Canvas bubbleText;
    public Camera mainCamera;

    public Text question;

    public int noteID;

    public float time;
    Vector2 startPosition;
    Vector2 targetPosition;

    public bool status;

    private void Start()
    {
        // Set main camera and apply to canvas
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        bubbleText.GetComponent<Canvas>().worldCamera = mainCamera;

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
        // Destroy bubble sprite and text first
        Destroy(bubble);
        Destroy(question);
        gameObject.tag = "Untagged";
        enemyController.enemyAnimation.SetTrigger("Die");
        enemyController.slimeSlash.Play();
    }

    public void Destroy() { Destroy(gameObject);  }
}
