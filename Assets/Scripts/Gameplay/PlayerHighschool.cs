using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHighschool : MonoBehaviour
{
    public Text highScore1, highScore2, highScore3;
    public Text artistText, songText;
    public Text scoreText;
    public int score;

    void Start() {
        GameObject userScoreObj = GameObject.Find("UserScore");
        score = userScoreObj.GetComponent<UserScore>().score;
        artistText.text = userScoreObj.GetComponent<UserScore>().songArtist;
        songText.text = userScoreObj.GetComponent<UserScore>().songTitle;
        Destroy(userScoreObj);
        ApplyScore(score);
    }

    public void ApplyScore(int score){
        scoreText.text = score.ToString();
        HighscoreController.addSkor(score);

        highScore1.text = PlayerPrefs.GetInt("score1").ToString();
        highScore2.text = PlayerPrefs.GetInt("score2").ToString();
        highScore3.text = PlayerPrefs.GetInt("score3").ToString();
    }

}