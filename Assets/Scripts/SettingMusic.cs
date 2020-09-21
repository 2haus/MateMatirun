using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMusic : MonoBehaviour
{
    public Button volUp, volDown;
    Text music;
    float volume;
    bool update;

    void Start()
    {
        music = GetComponent<Text>();

        volUp.onClick.AddListener(VolUp);
        volDown.onClick.AddListener(VolDown);

        // get music from playerprefs later
        volume = 1f;
    }

    void Update()
    {
        if(update)
        {
            music.text = (volume * 100).ToString() + "%";
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
