using UnityEngine;

public class HighscoreController {
    public static void addSkor(int score) {
        int highscore1 = PlayerPrefs.GetInt("score1");
        int highscore2 = PlayerPrefs.GetInt("score2");
        int highscore3 = PlayerPrefs.GetInt("score3");
        
        if (score > highscore1) {
            highscore3 = highscore2;
            highscore2 = highscore1;
            highscore1 = score;
        } else if (score > highscore2) {
            highscore3 = highscore2;
            highscore2 = score;
        } else if (score > highscore3) {
            highscore3 = score;
        }

        PlayerPrefs.SetInt("score1", highscore1);
        PlayerPrefs.SetInt("score2", highscore2);
        PlayerPrefs.SetInt("score3", highscore3);
    }
}
