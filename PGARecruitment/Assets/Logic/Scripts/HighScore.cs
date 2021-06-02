using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighScore
{
    
    public static float GetHighScore() {
        return PlayerPrefs.GetFloat("HighScore");
    }

    public static bool SetHighScoreIfPossible(float score) {
        Debug.Log(PlayerPrefs.GetFloat("HighScore"));
        if (PlayerPrefs.GetFloat("HighScore") < score) { 
            PlayerPrefs.SetFloat("HighScore", score);
            return true;
        }
        return false;

    } 
}
