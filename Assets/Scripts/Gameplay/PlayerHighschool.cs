using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHighschool : MonoBehaviour
{
    public Text highScore1, highScore2, highScore3;
    public Text scoreText;
    int score = 0;
    int playerHighScore;

    void Update(){ 
        playerHighScore = score;
        scoreText.text = playerHighScore.ToString();
        HighscoreController.addSkor(score);

        //Show score
        highScore1.text = PlayerPrefs.GetInt("score1").ToString();
        highScore2.text = PlayerPrefs.GetInt("score2").ToString();
        highScore3.text = PlayerPrefs.GetInt("score3").ToString();
    }
}