using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongSelectEntrance : MonoBehaviour
{
    RectTransform screenPanel;
    float speed;
    bool animate;

    void Start()
    {
        screenPanel = GetComponent<RectTransform>();
        screenPanel.anchoredPosition = new Vector3(720f, 0);
        animate = true;
        speed = 1000f;
    }


    void Update()
    {
        if(animate == true)
        {
            Debug.Log(speed);

            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if(screenPanel.anchoredPosition.x < 360f) // interpolate speed after halfway
            {
                float distance = Mathf.Min(360f, 180f); // interpolate between these distance
                speed = Mathf.Lerp(0f, 1000f, screenPanel.anchoredPosition.x / distance); // 1200 to 0, interpolated by current x and distance between
            }

            if (screenPanel.anchoredPosition.x <= 0)
            {
                animate = false;
                screenPanel.anchoredPosition = new Vector3(0, 0); // just to make sure
            }
        }
    }
}
