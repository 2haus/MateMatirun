﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongSelectionClick : MonoBehaviour
{
    public RectTransform art;
    Vector3 position;

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
    }
}
