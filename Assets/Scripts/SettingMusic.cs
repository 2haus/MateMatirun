using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMusic : MonoBehaviour
{
    public SettingsStore store;
    public Button volUp, volDown;
    Text music;
    float volume;

    void Start()
    {
        music = GetComponent<Text>();

        volUp.onClick.AddListener(VolUp);
        volDown.onClick.AddListener(VolDown);

        // get music from playerprefs later
        // volume = 1f;
    }

    void UpdateData()
    {
        music = GetComponent<Text>();

        music.text = (volume * 100).ToString() + "%";
        store.UpdateMusic(volume);
    }

    void VolUp()
    {
        if (volume < 1f)
        {
            volume += 0.25f;
            UpdateData();
        }
    }

    void VolDown()
    {
        if (volume > 0f)
        {
            volume -= 0.25f;
            UpdateData();
        }
    }

    public void SetMusic(float target)
    {
        volume = target;
        UpdateData();
    }
}
