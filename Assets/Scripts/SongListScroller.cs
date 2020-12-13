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

    int index;

    void Start()
    {
        twoFingered = false;
    }

    void Update()
    {
        if(Input.touchCount >= 2)
        {
            Debug.Log("Two fingers detected!");
            twoFingered = true;
            active = true;
            SnapSong();
        }
        else if (Input.touchCount == 1)
        {
            if(!twoFingered)
            {
                active = true;
                Touch input = Input.GetTouch(0);
                if (input.deltaPosition.x != 0)
                {
                    scrolling = true;
                    foreach (SongSelectionClick temp in click) temp.ToggleClick(false);
                }
                songList.anchoredPosition = new Vector2(songList.anchoredPosition.x + input.deltaPosition.x, songList.anchoredPosition.y);
            }
        }
        else if(Input.touchCount == 0 && active)
        {
            // int index = (int)(Mathf.Abs(songList.anchoredPosition.x) - 240) / 480;
            if(!twoFingered)
            {
                if (!scrolling)
                {
                    Debug.Log($"not scrolling. selecting item {index}");
                    navigation.Select(index);
                }
                else SnapSong();
                scrolling = false;

                active = false;

                foreach (SongSelectionClick temp in click) temp.ToggleClick(true);
            }
            Debug.Log($"twoFingered: {twoFingered}");

            twoFingered = false;
        }
    }

    void SnapSong()
    {
        float x = songList.anchoredPosition.x;

        int target;
        if (x < 0f) target = (int)(Mathf.Abs(x - 285f) / 500f);
        else target = 0;
        if (target < 0) target = 0;
        else if (target > 3) target = 3;
        // Debug.Log($"{x}, {index}");
        navigation.Snap(target);
    }

    public void ButtonTapped(int index)
    {
        this.index = index;
    }

    public void DirectClick(int index)
    {
        navigation.Select(index);
    }
}
