using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// specialization of prompt for a menu  
public class MenuPrompt : PromptOneOption {

    [SerializeField] private TextMeshProUGUI highScore;
    [SerializeField] private DisplayTime displayTime;

    protected override void Start() {
        
        base.Start();
        SetData(data);
        SetHighscoreTMP();

    }

    public void SetHighscoreTMP() {
        if (HighScore.GetHighScore() != float.MaxValue && HighScore.GetHighScore() != 0)
            displayTime.DisplayScoreOnTMP(HighScore.GetHighScore(), 3);
        else highScore.text = "-Not Yet Achived-";
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

}
