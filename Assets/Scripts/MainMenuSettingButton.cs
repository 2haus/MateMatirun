using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuSettingButton : MonoBehaviour
{
    // public MainMenuAd adGameObject;
    public UnityBannerAd adGameObject;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(EnterSettings);
    }

    void EnterSettings()
    {
        adGameObject.DestroyBanner();
        SceneManager.LoadScene("Setting");
    }
}
