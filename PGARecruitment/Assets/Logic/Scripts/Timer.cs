using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//class is a timer...
[RequireComponent(typeof(DisplayTime))]
public class Timer : MonoBehaviour
{
    [SerializeField] private bool isCounting = false;
    [SerializeField] private Color recordTimeColor;
    [SerializeField] private Color noRecordTimeColor;
    [SerializeField] private Image background;
    [SerializeField] private float BGAlpha = 150;
    public float elapsedTime = 0;
    float record = 0;
    bool flagIsSlowerThanRecord = false;
    float startedTimerTime = 0;
    DisplayTime displayTime;

    private void Start() {
        displayTime = this.GetComponent<DisplayTime>();
        displayTime.SetColorOfTMP(recordTimeColor);
        background.color = new Color(recordTimeColor.r, recordTimeColor.g, recordTimeColor.b, BGAlpha/255);
        record = HighScore.GetHighScore();
        if (record == 0) record = float.MaxValue;

        //StartTimer();
    }

    [ContextMenu("Start Timer")]
    public void StartTimer() {
        startedTimerTime = Time.time;
        isCounting = true;
    }

    [ContextMenu("Reset Highscore")]
    public void ResetRecord() {
        HighScore.SetHighScoreUncoditionly(float.MaxValue);
    }

    [ContextMenu("Stop Timer")]
    public bool StopTimerAndGetIsRecord () {
        isCounting = false;
        
        return HighScore.SetHighScoreIfPossible(elapsedTime);
    }

    [SerializeField] private int precision = 3;
    private void Update() {

        if (isCounting) { 
            elapsedTime = Time.time - startedTimerTime;
            elapsedTime = (float)Math.Round(elapsedTime, precision);
            displayTime.DisplayScoreOnTMP(elapsedTime, precision);
            if (elapsedTime > record && !flagIsSlowerThanRecord) {
                flagIsSlowerThanRecord = true;
                background.color = new Color(noRecordTimeColor.r, noRecordTimeColor.g, noRecordTimeColor.b, BGAlpha / 255); ;
                displayTime.SetColorOfTMP(noRecordTimeColor);
            }
        }

    }

}
