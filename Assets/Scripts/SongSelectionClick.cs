using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongSelectionClick : MonoBehaviour
{
    public SongListScroller scroller;
    public RectTransform art;
    public int index;
    Vector3 position;

    bool enableClick;
    bool touched;

    void Start()
    {
        position = art.localPosition;
        enableClick = false;
        touched = false;
    }

    public void OnMouseButtonUp()
    {
        Debug.Log("click");
    }

    public void MoveDown()
    {
        art.localPosition = new Vector3(position.x, position.y - 4f, position.z);

        if (Input.touchCount > 0)
        {
            touched = true;
            scroller.ButtonTapped(index);
        }
    }

    public void MoveUp()
    {
        art.localPosition = new Vector3(position.x, position.y, position.z);

        if (!touched) scroller.DirectClick(index);
        touched = false;
    }

    public void ToggleClick(bool target)
    {
        enableClick = target;
    }
}
