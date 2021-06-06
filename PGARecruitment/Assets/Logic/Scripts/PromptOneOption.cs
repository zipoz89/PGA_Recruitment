using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//Scpecialized class for prompt with one option

public class PromptOneOption : Prompt {

    [SerializeField] private Button confirmButton;


    [SerializeField] protected ButtonData button;


    protected override void Start() {
        base.Start();
        button.button = this.transform.GetChild(1).gameObject.GetComponent<Button>();
        button.tmp = this.transform.GetChild(1).gameObject.GetComponentInChildren<TextMeshProUGUI>();      
    }

    public override void DisplayData()
    {
        base.DisplayData();
        button.tmp.text = data.options[0].optionText;
        button.button.onClick.AddListener(OnClickButton);
    }

    protected virtual void OnClickButton() {
        Destroy(this.gameObject);
        if (data.options[0].optionEvent != null) {
            data.options[0].optionEvent.Raise();
        }
    }

    protected virtual void Update() {

        if ( Input.GetKeyDown(KeyCode.Return)) {
            OnClickButton();
        }
    }

    
}
