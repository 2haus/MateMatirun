using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class HighScore{
    public int score;
    public HighScore(int score){
        this.score = score;
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
    public Text highScore1, highScore2, highScore3;
    public Text artistText, songText;
    public Text scoreText;
    public int score;
    private string[] titleAndArtist;
    string debugTitleSong;
    string jsonTest;
    public Button retry, exit;
    int id;
    HighScore[] scores;
    void Start() {
        retry.onClick.AddListener(Retry);
        exit.onClick.AddListener(Exit);

        GameObject userScoreObj = GameObject.Find("UserScore");
        score = userScoreObj.GetComponent<UserScore>().score;
        artistText.text = userScoreObj.GetComponent<UserScore>().songArtist;
        songText.text = userScoreObj.GetComponent<UserScore>().songTitle;

        debugTitleSong = artistText.text + " " + songText.text;
        Destroy(userScoreObj);

        // HighScore[] testDemo = {
        //     new HighScore(5), 
        //     new HighScore(9),
        //     new HighScore(7)
        // };
        // Debug.Log(JsonConvert.SerializeObject(testDemo));
        for(int i = 0; i < songs.Length; i++){
            if(songText.text == songs[i]){
                id = i;
                break;
            }
        }
        if(!PlayerPrefs.HasKey($"{id}_score")){
            HighScore[] tempScore = {
                new HighScore(0),
                new HighScore(0),
                new HighScore(0)
            };
            PlayerPrefs.SetString($"{id}_score", JsonConvert.SerializeObject(tempScore));
        }
        scores = JsonConvert.DeserializeObject<HighScore[]>(PlayerPrefs.GetString($"{id}_score"));
        ApplyScore(score);
    }

    public void ApplyScore(int score){
        scoreText.text = score.ToString();
        Debug.Log(score);
        Debug.Log(scores[0].score);
        // HighscoreController.addSkor(score);
        if(score > scores[0].score){
            scores[2].score = scores[1].score;
            scores[1].score = scores[0].score;
            scores[0].score = score;
        } else if (score > scores[1].score){
            scores[2].score = scores[1].score;
            scores[1].score = score;
        } else if (score > scores[2].score){
            scores[2].score = score;
        }

        PlayerPrefs.SetString($"{id}_score", JsonConvert.SerializeObject(scores));

        highScore1.text = scores[0].score.ToString();
        highScore2.text = scores[1].score.ToString();
        highScore3.text = scores[2].score.ToString();
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