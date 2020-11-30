using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FailManager : MonoBehaviour
{
    GameManager Manager;
    public Button retry;
    public Button exit;

    private void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Time.timeScale = 0;
        retry.onClick.AddListener(Manager.RetryGame);
        exit.onClick.AddListener(Manager.ExitGame);
    }
}
