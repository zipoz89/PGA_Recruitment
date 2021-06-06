using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// specialized Propmpt class for end screen sumamry window
public class EndScreenPrompt : PromptTwoOptions 
{
    [SerializeField] private Color noRecord;
    [SerializeField] private Color record;
    [SerializeField] private Timer timer;
    [SerializeField] private DisplayTime finalScore;
    [SerializeField] private DisplayTime highScore;
    protected override void Start()
    {
        base.Start();
        SetData(data);  
    }

    public void DisplayAdditionalData() {
        
        if (timer.StopTimerAndGetIsRecord())
        {
            finalScore.DisplayScoreOnTMP(timer.elapsedTime, 3);
            finalScore.SetColorOfTMP(record);
        }
        else {
            finalScore.DisplayScoreOnTMP(timer.elapsedTime, 3);
            finalScore.SetColorOfTMP(noRecord);
        }
        highScore.DisplayScoreOnTMP(HighScore.GetHighScore(),3);
    }



}
