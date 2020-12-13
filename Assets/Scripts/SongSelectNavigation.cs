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
        animate = true;
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
                if(songSelect) scroller.ToggleSwipe(true);
                time = 0f;
            }
        }
    }

    void BackToSongSelect()
    {
        if (animate) return;

        Debug.Log("back");

        screenTargetter.anchoredPosition = Vector2.zero;
        difficultyTargetter.anchoredPosition = new Vector2(0f, (Screen.height * 720f / Screen.width) + 10f);

        animateTime = 1.25f;
        iTween.MoveTo(screen.gameObject, screenTargetter.transform.position, animateTime);
        iTween.MoveTo(difficultyScreen.gameObject, difficultyTargetter.transform.position, animateTime);

        temporary.SetMapID(-1);
        scroller.ToggleSwipe(false);
        songSelect = true;
        animate = true;
    }

    void BackToMainMenu()
    {
        if (animate) return;

        SceneManager.LoadScene("Main");
    }

    void DifficultySelect()
    {
        if (animate) return;
        screenTargetter.anchoredPosition = new Vector2(0f, -(Screen.height * 720f / Screen.width) - 1f);
        difficultyTargetter.anchoredPosition = Vector2.zero;

        animateTime = 1.25f;
        iTween.MoveTo(screen.gameObject, screenTargetter.transform.position, animateTime);
        iTween.MoveTo(difficultyScreen.gameObject, difficultyTargetter.transform.position, animateTime);
        animate = true;
        // StartCoroutine(delay(0.75f));
    }

    void StopTween()
    {
        Debug.Log("stopping tween");
        if (iTween.tweens.Count > 0) iTween.Stop();
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
    }

    public void Snap(int index)
    {
        if (animate) return;

        scroller.ToggleSwipe(false);
        songTargetter.anchoredPosition = new Vector2(index * -480f, songTargetter.anchoredPosition.y);
        float delta = Mathf.Abs(songHolder.anchoredPosition.x - songTargetter.anchoredPosition.x);
        Debug.Log($"holder = {songHolder.anchoredPosition.x}, targetter = {songTargetter.anchoredPosition.x}, delta = {delta}");
        if (delta > 225f) animateTime = 1.25f;
        else animateTime = delta / 225f * 1.25f;

        iTween.MoveTo(songHolder.gameObject, songTargetter.transform.position, animateTime);

        if(index != active) audioManager.LoadMap(json[index]);
        active = index;

        animate = true;
    }

    public void Select(int index)
    {
        Debug.Log("Triggered Select");
        if (!animate)
        {
            // StopTween();
            Snap(index);
        }
    }

    public void Selection(int index)
    {
        Debug.Log($"selecting {index}");
        if (index == active)
        {
            // StopTween();
            temporary.SetMapID(index);
            scroller.ToggleSwipe(false);
            songSelect = false;
            DifficultySelect();
        }
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
