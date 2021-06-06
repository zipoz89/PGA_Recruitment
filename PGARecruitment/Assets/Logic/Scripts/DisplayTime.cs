using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// script to put on and  display time with call from other function 

public class DisplayTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textField;

    private void Start() {
        if (textField == null) textField = this.GetComponent<TextMeshProUGUI>();
    }

    public void DisplayScoreOnTMP(float seconds,int precision) {
        var ss = (seconds % 60).ToString();
        if (seconds < 10) {
            ss = "0" + ss;
        }
        if(ss.Length>= precision+4)
            ss = ss.Substring(0, precision+2);
        var mm = ((int)seconds / 60).ToString();
        if (mm.Length == 1)
            mm = "0" + mm;
        textField.text = mm+ ":"+ ss;
    }

    public void SetColorOfTMP(Color color) {
        textField.color = color;
    }
}
