using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuSettingButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(EnterSettings);
    }

    void EnterSettings()
    {
        SceneManager.LoadScene("Setting");
    }
}
