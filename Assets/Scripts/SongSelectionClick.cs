using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongSelectionClick : MonoBehaviour
{
    public SongSelectNavigation navigation;
    public RectTransform art;
    public int index;
    Vector3 position;

    bool enableClick;

    void Start()
    {
        position = art.localPosition;
    }


    public void MoveDown()
    {
        art.localPosition = new Vector3(position.x, position.y - 4f, position.z);
    }

    public void MoveUp()
    {
        art.localPosition = new Vector3(position.x, position.y, position.z);

        if(enableClick) navigation.Select(index);
    }

    public void ToggleClick(bool target)
    {
        enableClick = target;
    }
}
