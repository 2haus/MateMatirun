using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuPlayButton : MonoBehaviour
{
    public Transform[] items; // put all items in the canvas here, later use fixed find method
    bool animate, switching;
    float speed, time;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(EnterSongSelect);
        animate = false;
        speed = 40f;
    }

    void Update()
    {
        if(animate)
        {
            if (!switching) time += Time.deltaTime;

            foreach (Transform item in items)
            {
                item.Translate(Vector2.left * speed * Time.deltaTime);
            }
            speed += 160f;
        }

        if(time >= 0.5f && !switching)
        {
            switching = true;
            animate = false;
            StartCoroutine(LoadSongSelectScene());
        }
    }

    void EnterSongSelect()
    {
        animate = true;
    }

    IEnumerator LoadSongSelectScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SongSelect");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
