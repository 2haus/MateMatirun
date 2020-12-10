using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class HighScore {
    [JsonProperty]
    private int[] scores = new int[3];
    public int get(int index) {
        return scores[index];
    }
    public void set(int index, int skor) {
        scores[index] = skor;
    }
    
    public void AddScore(int score) {
        if (score > scores[0]) {
            scores[2] = scores[1];
            scores[1] = scores[0];
            scores[0] = score;
        } else if (score > scores[1]) {
            scores[2] = scores[1];
            scores[1] = score;
        } else if (score > scores[2]) {
            scores[2] = score;
        }
    }
}

public class PlayerHighschool : MonoBehaviour
{
    string[] songs = new string[]{
        "Futatsu kageboushi",
        "Strength",
        "Taifunparedo",
        "Zi lei yishan"
    };

    string[] difficultyToString = new string[] {
        "Easy",
        "Medium",
        "Hard"
    };
    
    public Text highScore1, highScore2, highScore3;
    public Text artistText, songText, difficultyText;
    public Text scoreText;
    public int score;
    private string[] titleAndArtist;
    string debugTitleSong;
    string jsonTest;
    public Button retry, exit;
    int id, difficulty;
    public HighScore scores;
    void Start() {
        retry.onClick.AddListener(Retry);
        exit.onClick.AddListener(Exit);

        if (GameObject.Find("UserScore")) {
            simpanScore();
        }
    }

    public void simpanScore() {
        GameObject userScoreObj = GameObject.Find("UserScore");
        score = userScoreObj.GetComponent<UserScore>().score;
        artistText.text = userScoreObj.GetComponent<UserScore>().songArtist;
        songText.text = userScoreObj.GetComponent<UserScore>().songTitle;
        difficulty = userScoreObj.GetComponent<UserScore>().songDifficulty;
        difficultyText.text = difficultyToString[difficulty];

        debugTitleSong = artistText.text + " " + songText.text;
        Destroy(userScoreObj);

        for(int i = 0; i < songs.Length; i++){
            if(songText.text == songs[i]){
                id = i;
                break;
            }
        }
        if(!PlayerPrefs.HasKey($"{id}_{difficulty}_score")){
            HighScore tempScore = new HighScore();
            PlayerPrefs.SetString($"{id}_{difficulty}_score", JsonConvert.SerializeObject(tempScore));
        }
        scores = JsonConvert.DeserializeObject<HighScore>(PlayerPrefs.GetString($"{id}_{difficulty}_score"));
        ApplyScore(score);
    }

    public void ApplyScore(int score){
        scoreText.text = score.ToString();

        scores.AddScore(score);

        PlayerPrefs.SetString($"{id}_{difficulty}_score", JsonConvert.SerializeObject(scores));

        highScore1.text = scores.get(0).ToString();
        highScore2.text = scores.get(1).ToString();
        highScore3.text = scores.get(2).ToString();
    }

    void Retry()
    {
        SceneManager.LoadScene("Play");
    }

    void Exit()
    {
        SceneManager.LoadScene("Main");
    }
}