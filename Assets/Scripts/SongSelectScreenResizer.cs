using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSelectScreenResizer : MonoBehaviour
{
    RectTransform screen;

    void Start()
    {
        screen = GetComponent<RectTransform>();

        screen.sizeDelta = new Vector2(720f, Screen.height * 720f / Screen.width);
    }
}
