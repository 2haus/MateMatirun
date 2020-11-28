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
        ApplyScore(score);
        ApplyArtistSongText();
    }

    public void ApplyScore(int score){
        scoreText.text = score.ToString();
        HighscoreController.addSkor(score);

        highScore1.text = PlayerPrefs.GetInt("score1").ToString();
        highScore2.text = PlayerPrefs.GetInt("score2").ToString();
        highScore3.text = PlayerPrefs.GetInt("score3").ToString();
    }

    public void ApplyArtistSongText(){
        artistText.text = "artist";
        songText.text = "song";
    }

}