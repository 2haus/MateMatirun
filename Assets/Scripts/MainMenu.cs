using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject bgm;

    void Start()
    {
        if (GameObject.Find("BGM") == null)
        {
            GameObject spawn = Instantiate(bgm);
            spawn.name = "BGM";
        }
    }

}
