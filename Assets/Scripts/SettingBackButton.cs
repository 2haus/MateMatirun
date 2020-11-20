using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingBackButton : MonoBehaviour
{
    public SettingsStore store;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ReturnToMenu);
    }

    void ReturnToMenu()
    {
        store.SaveData();
        SceneManager.LoadScene("Main");
    }
}
