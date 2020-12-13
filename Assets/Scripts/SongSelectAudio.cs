using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using MMBackend;
using MMBackend.MapEditor;

public class SongSelectAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioMixer audioMixer;

    bool fade;
    float target;
    float current;
    int previewPoint;

    void Start()
    {
        audioMixer.SetFloat("Music", -80f); // mute for fading
        fade = true;
        current = 0.01f;
        LoadSettings();
    }

    void Update()
    {
        if(fade)
        {
            current += Time.deltaTime;

            if (current >= target)
            {
                audioMixer.SetFloat("Music", Mathf.Log(target) * 20);
                fade = false;
            }
            else audioMixer.SetFloat("Music", Mathf.Log(current) * 20);
        }

        if (audioSource.time >= audioSource.clip.length) PlayAudio(previewPoint);
    }

    void LoadSettings()
    {
        UserData.Settings.SettingsData settings = UserData.Settings.LoadSettings();

        if (settings.musicVolume == 0) audioSource.mute = true;
        else target = settings.musicVolume;
    }

    public void LoadMap(string path)
    {
        Map map = SaveLoad.LoadMap(path);
        // Debug.Log($"{map.songPath}");

        audioSource.clip = Resources.Load<AudioClip>($"Songs/{map.songPath}");
        previewPoint = map.preview;
        PlayAudio(previewPoint);
    }

    public void PlayAudio(int previewPoint = 0)
    {
        if (previewPoint != 0) audioSource.timeSamples = previewPoint;
        audioSource.Play();
    }

    public void PlayAudio(float startTime = 0f)
    {
        if (startTime != 0f) audioSource.time = startTime;
        audioSource.Play();
    }

    public void PauseAudio()
    {
        audioSource.Pause();
    }
}
