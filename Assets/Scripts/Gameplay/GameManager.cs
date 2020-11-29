using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public MusicCore map;
    public Button pauseButton;

    void Start(){
        pauseButton.onClick.AddListener(PauseGame);
    }

    public void StartCountdown(int countFromSeconds)
    {
        StartCoroutine(Countdown(countFromSeconds));
    }

    IEnumerator Countdown(int countFromSeconds)
    {
        // Countdown Delay in seconds
        for (int i = countFromSeconds; i > 0; i--)
        {
            Debug.Log(i);
            yield return new WaitForSeconds(1);
        }

        // Start Song
        map.GameStart();
    }

    public void PauseGame(){
        Time.timeScale = 0;
        map.PauseSong();
        SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
    }

    public void PlayGame(){
        Time.timeScale = 1;
        map.PlaySong();
        SceneManager.UnloadSceneAsync("Pause");
    }

    public void RetryGame(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Play");
    }

    public void ExitGame(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }
}


