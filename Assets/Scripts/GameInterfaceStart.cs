using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInterfaceStart : MonoBehaviour
{
    const float worldHeight = 5.08f;

    public RectTransform targetter, choicesManager;
    Transform playArea;
    Vector3 mainAreaTarget;

    void Start()
    {
        playArea = GetComponent<Transform>();

        // Debug.Log($"{targetter.position.x}, {targetter.position.y}");
        mainAreaTarget = Camera.main.ScreenToViewportPoint(targetter.position);

        // playArea.position = new Vector2(playArea.position.x, playArea.position.y + (2 * mainAreaTarget.y * worldHeight));
        ShiftUp();
    }

    public void ShiftUp()
    {
        iTween.MoveTo(choicesManager.gameObject, new Vector3(targetter.position.x, targetter.position.y / 2, 0f), 1f);
        iTween.MoveTo(playArea.gameObject, new Vector3(playArea.position.x, playArea.position.y + (2 * mainAreaTarget.y * worldHeight), 0f), 1f);
    }
}
