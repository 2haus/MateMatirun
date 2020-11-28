using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    GameManager Manager;
    public Button retryButton;
    public Button exitButton;

    void Start(){
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        retryButton.onClick.AddListener(Manager.RetryGame);
        exitButton.onClick.AddListener(Manager.ExitGame);
    }
}
