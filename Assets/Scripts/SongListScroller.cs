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

    int index;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            active = true;
            Touch input = Input.GetTouch(0);
            if (input.deltaPosition.x != 0)
            {
                scrolling = true;
                foreach (SongSelectionClick temp in click) temp.ToggleClick(true);
            }
            songList.anchoredPosition = new Vector2(songList.anchoredPosition.x + input.deltaPosition.x, songList.anchoredPosition.y);
        }
        else if(Input.touchCount == 0 && active)
        {
            // int index = (int)(Mathf.Abs(songList.anchoredPosition.x) - 240) / 480;
            float x = songList.anchoredPosition.x;

            if (!scrolling)
            {
                Debug.Log($"not scrolling. selecting item {index}");
                navigation.Select(index);
            }
            else
            {
                int target;
                if (x < 0f) target = (int)(Mathf.Abs(x - 285f) / 500f);
                else target = 0;
                // Debug.Log($"{x}, {index}");
                navigation.Snap(target);
            }
            scrolling = false;

            active = false;

            foreach (SongSelectionClick temp in click) temp.ToggleClick(true);
        }
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
