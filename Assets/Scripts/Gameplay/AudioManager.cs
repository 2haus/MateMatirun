using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using MMBackend;
using Setting = MMBackend.UserData.Settings;


public class AudioManager : MonoBehaviour
{
    public SettingsStore setting;
    public AudioSource music, sfx;

    public AudioMixerGroup musicMixer, sfxMixer;
    public AudioMixer masterMixer;

    public Setting.SettingsData userSetting;

    public int universalOffset;

    private void Start()
    {
        userSetting = Setting.LoadSettings();
        universalOffset = userSetting.offset;
        music.outputAudioMixerGroup = musicMixer;
        sfx.outputAudioMixerGroup = sfxMixer;
        // Set music and sfx volume according to user setting
    }

    public void Initialized(Map map)
    {
        music.clip = Resources.Load<AudioClip>("Songs/" + map.songPath);
        sfx.clip = Resources.Load<AudioClip>("SFX/playerSlash");
    }

    public void musicPlay() { music.Play(); }
    public void musicPause() { music.Pause(); }
    public void musicStop() { music.Stop(); }
    public void sfxPlay() { sfx.Play(); }
}
