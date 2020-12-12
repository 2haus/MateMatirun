using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingSound : MonoBehaviour
{
    public AudioMixer mixer;
    public SettingsStore store;
    public Button volUp, volDown;
    Text sfx;
    float volume;

    void Start()
    {
        sfx = GetComponent<Text>();

        volUp.onClick.AddListener(VolUp);
        volDown.onClick.AddListener(VolDown);

        // get sfx from playerprefs later
        // volume = 0.75f;
    }

    void UpdateData()
    {
        sfx = GetComponent<Text>();

        sfx.text = (volume * 100).ToString() + "%";
        store.UpdateSound(volume);
        if (volume == 0f) mixer.SetFloat("SFX", -80f);
        else mixer.SetFloat("SFX", Mathf.Log(volume) * 20);
    }

    void VolUp()
    {
        if(volume < 1f)
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

    public void SetSound(float target)
    {
        volume = target;
        UpdateData();
    }
}
