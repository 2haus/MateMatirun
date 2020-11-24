using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongSelectNavigation : MonoBehaviour
{
    public RectTransform screen;
    public RectTransform screenTargetter;
    public RectTransform songHolder;
    public RectTransform songTargetter;
    public RectTransform difficultyScreen;
    public RectTransform difficultyTargetter;

    public Button songSelectBack;
    public Button difficultyBack;

    int active;
    bool animate;
    float time;

    void Start()
    {
        active = 0;
        animate = false;
        time = 0f;

        songSelectBack.onClick.AddListener(BackToMainMenu);
        difficultyBack.onClick.AddListener(BackToSongSelect);
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

    void BackToSongSelect()
    {
        screenTargetter.anchoredPosition = Vector2.zero;
        difficultyTargetter.anchoredPosition = new Vector2(0f, (Screen.height * 720f / Screen.width) - 1f);
        iTween.MoveTo(screen.gameObject, screenTargetter.transform.position, 1.5f);
        iTween.MoveTo(difficultyScreen.gameObject, difficultyTargetter.transform.position, 1.5f);

        animate = true;
    }

    void BackToMainMenu()
    {
        SceneManager.LoadScene("Main");
    }

    void DifficultySelect()
    {
        screenTargetter.anchoredPosition = new Vector2(0f, -(Screen.height * 720f / Screen.width) - 1f);
        difficultyTargetter.anchoredPosition = Vector2.zero;
        iTween.MoveTo(screen.gameObject, screenTargetter.transform.position, 1.5f);
        iTween.MoveTo(difficultyScreen.gameObject, difficultyTargetter.transform.position, 1.5f);

        animate = true;
    }

    public void Select(int index)
    {
        if(!animate)
        {
            if (index == active) DifficultySelect();
            else Snap(index);
        }
    }

    public void Snap(int index)
    {
        songTargetter.anchoredPosition = new Vector2(index * -480f, songTargetter.anchoredPosition.y);
        iTween.MoveTo(songHolder.gameObject, songTargetter.transform.position, 1.5f);
        active = index;
        animate = true;
    }

    public void ToggleAnimate(bool target)
    {
        animate = target;
    }
}
