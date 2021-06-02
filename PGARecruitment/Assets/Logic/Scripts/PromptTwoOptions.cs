using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PromptTwoOptions : Prompt {

    [SerializeField] private ButtonData buttonOne;
    [SerializeField] private ButtonData buttonTwo;

    public void SetData(string _label, string _optionOne, string _optionTwo, VoidEvent _eventOnButtonOne, VoidEvent _eventOnButtonTwo) {
        labelText = _label;
        buttonOne.text = _optionOne;
        buttonTwo.text = _optionTwo;
        buttonOne.eventOnClick = _eventOnButtonOne;
        buttonTwo.eventOnClick = _eventOnButtonTwo;
    }
    public override void SetData(PromptData data) {
        labelText = data.label;
        buttonOne.text = data.options[0].optionText;
        buttonTwo.text = data.options[1].optionText;
        buttonOne.eventOnClick = data.options[0].optionEvent;
        buttonTwo.eventOnClick = data.options[1].optionEvent;
    }

    protected override void Start() {
        base.Start();
        buttonOne.button = this.transform.GetChild(1).gameObject.GetComponent<Button>();
        buttonOne.tmp = this.transform.GetChild(1).gameObject.GetComponentInChildren<TextMeshProUGUI>();
        buttonTwo.button = this.transform.GetChild(2).gameObject.GetComponent<Button>();
        buttonTwo.tmp = this.transform.GetChild(2).gameObject.GetComponentInChildren<TextMeshProUGUI>();


        buttonOne.tmp.text = buttonOne.text;
        buttonTwo.tmp.text = buttonTwo.text;

        buttonOne.button.onClick.AddListener(OnClickButtonOne);
        buttonTwo.button.onClick.AddListener(OnClickButtonTwo);
    }

    void OnClickButtonOne() {
        Destroy(this.gameObject);
        if (buttonOne.eventOnClick != null) {
            buttonOne.eventOnClick.Raise();
        }
    }
    void OnClickButtonTwo() {
        Destroy(this.gameObject);
        if (buttonTwo.eventOnClick != null) {
            buttonTwo.eventOnClick.Raise();
        }
    }

    private void Update() {
        
        if (Input.GetKeyDown(KeyCode.Escape)) {
            OnClickButtonTwo();
        }
    }
}

