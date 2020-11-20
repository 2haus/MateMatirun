using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Settings = MMBackend.UserData.Settings;

public class SettingsStore : MonoBehaviour
{
    public SettingMusic music;
    public SettingSound sound;
    public SettingOffset offset;

    Settings.SettingsData settings;

    void Start()
    {
        settings = Settings.LoadSettings();

        music.SetMusic(settings.musicVolume);
        sound.SetSound(settings.sfxVolume);
        offset.SetOffset(settings.offset);
    }

    public void UpdateMusic(float target)
    {
        settings.musicVolume = target;
    }

    public void UpdateSound(float target)
    {
        settings.sfxVolume = target;
    }

    public void UpdateOffset(int target)
    {
        settings.offset = target;
    }

    public void SaveData()
    {
        Settings.SaveSettings(settings);
    }
}
