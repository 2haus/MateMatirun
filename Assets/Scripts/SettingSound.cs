using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSound : MonoBehaviour
{
    public Button volUp, volDown;
    Text sfx;
    float volume;
    bool update;

    void Start()
    {
        sfx = GetComponent<Text>();

        volUp.onClick.AddListener(VolUp);
        volDown.onClick.AddListener(VolDown);

        // get sfx from playerprefs later
        volume = 0.75f;
    }

    void Update()
    {
        if(update)
        {
            sfx.text = (volume * 100).ToString() + "%";
            update = false;
        }
    }

    void VolUp()
    {
        if(volume < 1f)
        {
            volume += 0.25f;
            update = true;
        }
    }

    void VolDown()
    {
        if (volume > 0f)
        {
            volume -= 0.25f;
            update = true;
        }
    }
}
