using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(DisplayTime))]
public class Timer : MonoBehaviour
{
    [SerializeField] private bool isCounting = false;
    [SerializeField] private Color recordTimeColor;
    [SerializeField] private Color noRecordTimeColor;
    [SerializeField] private Image background;
    [SerializeField] private float BGAlpha = 150;
    float elapsedTime = 0;
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
    }

    [ContextMenu("Start Timer")]
    public void StartTimer() {
        startedTimerTime = Time.time;
        isCounting = true;
    }

    [ContextMenu("Stop Timer")]
    public bool StopTimerAndGetScore() {
        isCounting = false;
        Debug.Log( HighScore.SetHighScoreIfPossible(elapsedTime));
        return false;
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
