using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongSelectNavigation : MonoBehaviour
{
    string[] json =
    {
        "Notzan - Futatsu Kageboushi",
        "shimtone - Strength",
        "Tatsuzaki Ichi - Typhoon Parade",
        "shimtone - Shirai Issen"
    };

    public SongSelectAudio audioManager;
    public SongListScroller scroller;

    public RectTransform screen;
    public RectTransform screenTargetter;
    public RectTransform songHolder;
    public RectTransform songTargetter;
    public RectTransform difficultyScreen;
    public RectTransform difficultyTargetter;

    public Button songSelectBack;
    public Button difficultyBack;

    SongSelectManager temporary;

    int active;
    bool animate;
    float animateTime;
    float time;
    bool songSelect;

    void Start()
    {
        active = 0;
        animate = false;
        time = 0f;
        songSelect = true;

        temporary = GameObject.Find("SongSelectManager").GetComponent<SongSelectManager>();

        audioManager.LoadMap(json[active]);

        songSelectBack.onClick.AddListener(BackToMainMenu);
        difficultyBack.onClick.AddListener(BackToSongSelect);

        difficultyScreen.anchoredPosition = new Vector2(difficultyScreen.anchoredPosition.x, difficultyScreen.anchoredPosition.y + 10f);
    }

    void Update()
    {
        if(animate)
        {
            time += Time.deltaTime;
            if(time >= animateTime)
            {
                animate = false;
                if (songSelect)
                {
                    scroller.ToggleSwipe(true);
                    scroller.ToggleClick(true);
                }
                // Debug.Log("animation stop");
                time = 0f;
            }
        }
    }

    void BackToSongSelect()
    {
        if (animate) return;

        // Debug.Log("back");
        songHolder.anchoredPosition = new Vector2(active * -480f, 109f);

        screenTargetter.anchoredPosition = Vector2.zero;
        difficultyTargetter.anchoredPosition = new Vector2(0f, (Screen.height * 720f / Screen.width) + 10f);

        animateTime = 1.25f;
        iTween.MoveTo(screen.gameObject, screenTargetter.transform.position, animateTime);
        iTween.MoveTo(difficultyScreen.gameObject, difficultyTargetter.transform.position, animateTime);

        temporary.SetMapID(-1);
        scroller.ToggleSwipe(false);
        songSelect = true;
        animate = true;
        scroller.ToggleClick(false);
        // Debug.Log("start animating");
    }

    void BackToMainMenu()
    {
        if (animate) return;

        SceneManager.LoadScene("Main");
    }

    void DifficultySelect()
    {
        // if (animate)
        // {
        //     // Debug.Log("Canceling animation");
        //     temporary.SetMapID(-1);
        //     scroller.ToggleSwipe(true);
        //     songSelect = true;
        //     return;
        // }

        screenTargetter.anchoredPosition = new Vector2(0f, -(Screen.height * 720f / Screen.width) - 1f);
        difficultyTargetter.anchoredPosition = Vector2.zero;

        animateTime = 1.25f;
        iTween.MoveTo(screen.gameObject, screenTargetter.transform.position, animateTime);
        iTween.MoveTo(difficultyScreen.gameObject, difficultyTargetter.transform.position, animateTime);
        animate = true;
        scroller.ToggleClick(false);
        // Debug.Log("start animating");
        // StartCoroutine(delay(0.75f));
    }

    void StopTween()
    {
        // Debug.Log("stopping tween");
        try
        {
            if (iTween.tweens.Count > 0) iTween.Stop();
        } catch {}
        screen.anchoredPosition = screenTargetter.anchoredPosition;
        difficultyScreen.anchoredPosition = difficultyTargetter.anchoredPosition;
    }

    IEnumerator delay(float second)
    {
        yield return new WaitForSeconds(second);
        screenTargetter.anchoredPosition = new Vector2(0f, -(Screen.height * 720f / Screen.width) - 1f);
        difficultyTargetter.anchoredPosition = Vector2.zero;

        animateTime = 1.25f;
        iTween.MoveTo(screen.gameObject, screenTargetter.transform.position, animateTime);
        iTween.MoveTo(difficultyScreen.gameObject, difficultyTargetter.transform.position, animateTime);
        animate = true;
        scroller.ToggleClick(false);
        // Debug.Log("start animating");
    }

    public void Snap(int index)
    {
        // scroller.ToggleSwipe(false);

        // if (animate)
        // {
        //     temporary.SetMapID(-1);
        //     // scroller.ToggleSwipe(true);
        //     songSelect = true;
        //     return;
        // }

        // scroller.ToggleSwipe(false);
        songTargetter.anchoredPosition = new Vector2(index * -480f, songTargetter.anchoredPosition.y);
        float delta = Mathf.Abs(songHolder.anchoredPosition.x - songTargetter.anchoredPosition.x);
        // Debug.Log($"holder = {songHolder.anchoredPosition.x}, targetter = {songTargetter.anchoredPosition.x}, delta = {delta}");
        if (delta > 225f) animateTime = 1.25f;
        else animateTime = delta / 225f * 1.25f;

        iTween.MoveTo(songHolder.gameObject, songTargetter.transform.position, animateTime);

        if(index != active) audioManager.LoadMap(json[index]);
        active = index;

        animate = true;
        // scroller.ToggleClick(false);
        // Debug.Log("start animating");
    }

    public void Select(int index)
    {

        scroller.ToggleSwipe(false);
        // Debug.Log("Triggered Select");
        if (!animate)
        {
            // StopTween();
            Snap(index);
        }
    }

    public void Selection(int index)
    {
        scroller.ToggleSwipe(false);
        // Debug.Log($"selecting {index}, active = {active}");
        if (index == active)
        {
            if(!animate)
            {
                // StopTween();
                temporary.SetMapID(index);
                songSelect = false;
                animate = true;
                scroller.ToggleClick(false);
                // Debug.Log("Animating difficulty");
                DifficultySelect();
            }
        }
        else Select(index);
    }

    public void ToggleAnimate(bool target)
    {
        animate = target;
    }

    public void DisableDifficultyBack()
    {
        difficultyBack.enabled = false;
    }
}
