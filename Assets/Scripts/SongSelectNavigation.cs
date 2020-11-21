using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSelectNavigation : MonoBehaviour
{
    public RectTransform screen;
    public RectTransform screenTargetter;
    public RectTransform songHolder;
    public RectTransform songTargetter;
    public RectTransform difficultyScreen;
    public RectTransform difficultyTargetter;

    int active;
    bool animate;
    float time;

    void Start()
    {
        active = 0;
        animate = false;
        time = 0f;
    }

    void Update()
    {
        if(animate)
        {
            time += Time.deltaTime;
            if(time >= 1.5f)
            {
                animate = false;
                time = 0f;
            }
        }
    }

    void DifficultySelect()
    {
        screenTargetter.anchoredPosition = new Vector2(0f, -1280f);
        difficultyTargetter.anchoredPosition = new Vector2(0f, 0f);
        iTween.MoveTo(screen.gameObject, screenTargetter.transform.position, 1.5f);
        iTween.MoveTo(difficultyScreen.gameObject, difficultyTargetter.transform.position, 1.5f);

        animate = true;
    }

    public void Select(int index)
    {
        if(!animate)
        {
            if (index == active) DifficultySelect();
            else
            {
                songTargetter.anchoredPosition = new Vector2(index * -480f, songTargetter.anchoredPosition.y);
                iTween.MoveTo(songHolder.gameObject, songTargetter.transform.position, 1.5f);
                active = index;
                animate = true;
            }
        }
    }
}
