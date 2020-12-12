using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using MMBackend;

public class BGMain : MonoBehaviour
{
    public AudioMixer mixer;
    AudioSource bgm;

    void Start()
    {
        bgm = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        LoadSettings();
    }

    void LoadSettings()
    {
        UserData.Settings.SettingsData settings = UserData.Settings.LoadSettings();

        if (settings.musicVolume == 0) mixer.SetFloat("Music", -80f);
        else mixer.SetFloat("Music", Mathf.Log(settings.musicVolume) * 20);
    }
}
