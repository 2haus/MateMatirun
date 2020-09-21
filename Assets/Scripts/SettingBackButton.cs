using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingBackButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ReturnToMenu);
    }

    void ReturnToMenu()
    {
        // save to playerprefs first

        SceneManager.LoadScene("Main");
    }
}
