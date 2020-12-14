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
    bool twoFingers;

    SongSelectManager temporary;

    void Start()
    {
        position = art.localPosition;
        enableClick = false;
        touched = false;
        twoFingers = false;

        temporary = GameObject.Find("SongSelectManager").GetComponent<SongSelectManager>();
    }

    void Selection()
    {
        // Debug.Log(enableClick);
        if(enableClick)
        {
            // Debug.Log(index);
            scroller.Selection(index);
        }
    }

    public void MoveDown()
    {
        art.localPosition = new Vector3(position.x, position.y - 4f, position.z);

        if (Input.touchCount == 1)
        {
            touched = true;
            scroller.ButtonTapped(index);
        }
        else if(Input.touchCount >= 2)
        {
            twoFingers = true;
        }
    }

    public void MoveUp()
    {
        art.localPosition = new Vector3(position.x, position.y, position.z);

        // if (!touched && !twoFingers)
        // {
        //     Debug.Log("Clicking");
        //     scroller.DirectClick(index);
        // }
        touched = false;
        twoFingers = false;
    }

    public void ToggleClick(bool target)
    {
        enableClick = target;
    }

    public void EnableClick()
    {
        GetComponent<Button>().onClick.AddListener(Selection);
    }
}
