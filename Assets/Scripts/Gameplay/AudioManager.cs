using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMBackend;
using Setting = MMBackend.UserData.Settings;


public class AudioManager : MonoBehaviour
{
    public SettingsStore setting;
    public AudioSource music;
    public AudioSource sfx;

    public Setting.SettingsData userSetting;

    public int universalOffset;

    private void Start()
    {
        userSetting = Setting.LoadSettings();
        universalOffset = userSetting.offset;
        // Set music and sfx volume according to user setting
    }

    public void Initialized(Map map)
    {
        music.clip = Resources.Load<AudioClip>("Songs/" + map.songPath);
    }
}
