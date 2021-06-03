using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuPrompt : PromptOneOption {

    [SerializeField] private TextMeshProUGUI highScore;
    [SerializeField] private DisplayTime displayTime;

    protected override void Start() {
        
        base.Start();
        SetData(data);
        if (HighScore.GetHighScore() != float.MaxValue)
            displayTime.DisplayScoreOnTMP(HighScore.GetHighScore(), 3);
        else highScore.text = "-Not Yet Achived-";

    }

    public override void SetData(PromptData data) {
        button.text = data.options[0].optionText;
        button.eventOnClick = data.options[0].optionEvent;
        button.tmp.text = button.text;
    }

}
