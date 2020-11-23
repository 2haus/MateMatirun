using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongListScroller : MonoBehaviour
{
    public RectTransform songList;
    public SongSelectionClick[] click;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch input = Input.GetTouch(0);
            if (input.deltaPosition.x != 0)
            {
                foreach (SongSelectionClick temp in click) temp.ToggleClick(false);
            }
            songList.anchoredPosition = new Vector2(songList.anchoredPosition.x + input.deltaPosition.x, songList.anchoredPosition.y);
        }
        else foreach (SongSelectionClick temp in click) temp.ToggleClick(true);
    }
}
