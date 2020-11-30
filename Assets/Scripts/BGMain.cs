using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMain : MonoBehaviour
{
    AudioSource bgm;

    private void Start()
    {
        bgm = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }
}
