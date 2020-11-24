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
    float animateTime;
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
        if (animate) return;

        screenTargetter.anchoredPosition = Vector2.zero;
        difficultyTargetter.anchoredPosition = new Vector2(0f, (Screen.height * 720f / Screen.width) - 1f);

        animateTime = 1.5f;
        iTween.MoveTo(screen.gameObject, screenTargetter.transform.position, animateTime);
        iTween.MoveTo(difficultyScreen.gameObject, difficultyTargetter.transform.position, animateTime);

        animate = true;
    }

    void BackToMainMenu()
    {
        if (animate) return;

        SceneManager.LoadScene("Main");
    }

    void DifficultySelect()
    {
        screenTargetter.anchoredPosition = new Vector2(0f, -(Screen.height * 720f / Screen.width) - 1f);
        difficultyTargetter.anchoredPosition = Vector2.zero;

        animateTime = 1.5f;
        iTween.MoveTo(screen.gameObject, screenTargetter.transform.position, animateTime);
        iTween.MoveTo(difficultyScreen.gameObject, difficultyTargetter.transform.position, animateTime);

        animate = true;
    }

    public void Snap(int index)
    {
        songTargetter.anchoredPosition = new Vector2(index * -480f, songTargetter.anchoredPosition.y);
        float delta = Mathf.Abs(screen.anchoredPosition.x - songTargetter.anchoredPosition.x);
        if (delta > 225f) animateTime = 1.25f;
        else animateTime = 1.25f + (delta / 25f);

        iTween.MoveTo(songHolder.gameObject, songTargetter.transform.position, animateTime);
        active = index;
        animate = true;
    }

    public void Select(int index)
    {
        if (!animate)
        {
            if (index == active) DifficultySelect();
            else Snap(index);
        }
    }

    public void ToggleAnimate(bool target)
    {
        animate = target;
    }
}
