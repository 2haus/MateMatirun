using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSelectDifficultyPlacement : MonoBehaviour
{
    RectTransform target;

    void Start()
    {
        target = GetComponent<RectTransform>();

        target.anchoredPosition = new Vector2(target.anchoredPosition.x, Screen.height * 720f / Screen.width);
    }
}
