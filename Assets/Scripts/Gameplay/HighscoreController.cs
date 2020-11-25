using UnityEngine;

public class HighscoreController {
    public static void addSkor(int skor) {
        int highscore1 = PlayerPrefs.GetInt("score1");
        int highscore2 = PlayerPrefs.GetInt("score2");
        int highscore3 = PlayerPrefs.GetInt("score3");
        
        if (skor > highscore1) {
            highscore3 = highscore2;
            highscore2 = highscore1;
            highscore1 = skor;
        } else if (skor > highscore2) {
            highscore3 = highscore2;
            highscore2 = skor;
        } else if (skor > highscore3) {
            highscore3 = skor;
        }

        PlayerPrefs.SetInt("score1", highscore1);
        PlayerPrefs.SetInt("score2", highscore2);
        PlayerPrefs.SetInt("score3", highscore3);
    }
}
