using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    GameManager Manager;
    public Button resumeButton;
    public Button exitButton;

    void Start(){
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        resumeButton.onClick.AddListener(Manager.PlayGame);
        exitButton.onClick.AddListener(Manager.ExitGame);
    }
}
