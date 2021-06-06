using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//manages highscorde PlayerPref
public static class HighScore
{
    
    public static float GetHighScore() {
        return PlayerPrefs.GetFloat("HighScore");
    }


    public static bool SetHighScoreIfPossible(float score) {
        if (score<PlayerPrefs.GetFloat("HighScore")) { 
            PlayerPrefs.SetFloat("HighScore", score);
            return true;
        }
        return false;

    }

    public static void SetHighScoreMax() {
        PlayerPrefs.SetFloat("HighScore", float.MaxValue);
    }
    //for dev use only
    public static void SetHighScoreUncoditionly(float score) {
        PlayerPrefs.SetFloat("HighScore", score);
    }
}
