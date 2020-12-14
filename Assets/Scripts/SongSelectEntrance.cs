using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongSelectEntrance : MonoBehaviour
{
    public SongSelectNavigation navigation;
    public SongSelectionClick[] click;
    public SongListScroller scroller;
    public Transform screenTargetter;
    RectTransform screenPanel;
    // float speed;
    float time;
    bool animate;

    void Start()
    {
        screenPanel = GetComponent<RectTransform>();
        screenPanel.anchoredPosition = new Vector3(720f, 0);
        animate = true;

        iTween.MoveTo(gameObject, screenTargetter.transform.position, 2f);
        scroller.ToggleSwipe(false);
        // speed = 1000f;
    }


    void Update()
    {
        if(animate)
        {
            /*
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if(screenPanel.anchoredPosition.x < 360f) // interpolate speed after halfway
            {
                float distance = Mathf.Min(360f, 180f); // interpolate between these distance
                speed = Mathf.Lerp(0f, 1000f, screenPanel.anchoredPosition.x / distance); // 1000 to 0, interpolated by current x and distance between
            }

            if (screenPanel.anchoredPosition.x <= 0)
            {
                animate = false;
                navigation.ToggleAnimate(false);
                screenPanel.anchoredPosition = new Vector3(0, 0); // just to make sure
            }
            */
            time += Time.deltaTime;
            if(time >= 2f)
            {
                animate = false;
                navigation.ToggleAnimate(false);
                scroller.ToggleSwipe(true);
                foreach (SongSelectionClick temp in click)
                {
                    temp.EnableClick();
                    temp.ToggleClick(true);
                }
                time = 0f;
                Destroy(this);
            }
        }
    }
}
