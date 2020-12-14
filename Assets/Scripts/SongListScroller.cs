using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongListScroller : MonoBehaviour
{
    public RectTransform songList;
    public SongSelectionClick[] click;
    public SongSelectNavigation navigation;

    bool active;
    bool scrolling;
    bool twoFingered;
    bool swipeable;

    int index;

    void Start()
    {
        twoFingered = false;
        swipeable = false;
    }

    void Update()
    {
        if(swipeable)
        {
            if (Input.touchCount >= 2)
            {
                // Debug.Log("Two fingers detected!");
                twoFingered = true;
                active = true;
                if(scrolling) SnapSong();
            }
            else if (Input.touchCount == 1)
            {
                if (iTween.tweens.Count > 0)
                    iTween.Stop();
                if (!twoFingered)
                {
                    active = true;
                    Touch input = Input.GetTouch(0);
                    if(input.phase == TouchPhase.Moved)
                    {
                        scrolling = true;
                        foreach (SongSelectionClick temp in click) temp.ToggleClick(false);
                    }
                    songList.anchoredPosition = new Vector2(songList.anchoredPosition.x + input.deltaPosition.x, songList.anchoredPosition.y);
                }
            }
            else if (Input.touchCount == 0 && active)
            {
                // Debug.Log($"twoFingered: {twoFingered}");
                // int index = (int)(Mathf.Abs(songList.anchoredPosition.x) - 240) / 480;
                if (!twoFingered)
                {
                    if (!scrolling)
                    {
                        // Debug.Log($"not scrolling. ignoring");
                        // navigation.Select(index);
                    }
                    else SnapSong();
                    scrolling = false;

                    active = false;

                    foreach (SongSelectionClick temp in click) temp.ToggleClick(true);
                }

                twoFingered = false;
                active = false;
            }
        }
    }

    void SnapSong()
    {
        // Debug.Log("snapping");
        float x = songList.anchoredPosition.x;

        int target;
        if (x < 0f) target = (int)(Mathf.Abs(x - 285f) / 500f);
        else target = 0;
        if (target < 0) target = 0;
        else if (target > 3) target = 3;
        // // Debug.Log($"{x}, {index}");
        navigation.Snap(target);
    }

    public void ButtonTapped(int index)
    {
        this.index = index;
    }

    public bool Selection(int index)
    {
        // Debug.Log($"clicked {index}");
        if (scrolling) return false;

        navigation.Selection(index);
        return true;
    }

    public void ToggleSwipe()
    {
        swipeable = !swipeable;
    }

    public void ToggleSwipe(bool target)
    {
        swipeable = target;
    }

    public bool GetSwipeableStatus()
    {
        return swipeable;
    }

    public void ToggleClick(bool target)
    {
        foreach (SongSelectionClick temp in click) temp.ToggleClick(target);
    }
}
