using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MMBackend;
using MMBackend.MapEditor;

public class GameManager : MonoBehaviour
{
    public MusicCore map;
    public Button pauseButton;

    public Map song;
    int difficulty;

    [SerializeField]
    string path;

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

    public void StartGame()
    {
        song = SaveLoad.LoadMap(path);
        map.LoadMap(song, difficulty);
    }

    public void SetPath(string target)
    {
        // path = $"Resources/{target}";
        path = target;
    }

    public void SetDifficulty(int difficulty)
    {
        this.difficulty = difficulty;
    }
}


