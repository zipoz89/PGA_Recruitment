using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PromptOneOption : Prompt {
    [SerializeField] private Button confirmButton;


    [SerializeField] protected ButtonData button;

    [SerializeField] protected PromptData data;

    public override void SetData(PromptData data) {
        Start();
        label.text = data.label;
        button.text = data.options[0].optionText;
        button.eventOnClick = data.options[0].optionEvent;
    }

    protected override void Start() {
        base.Start();
        button.button = this.transform.GetChild(1).gameObject.GetComponent<Button>();
        button.tmp = this.transform.GetChild(1).gameObject.GetComponentInChildren<TextMeshProUGUI>();

        button.tmp.text = button.text;
        button.button.onClick.AddListener(OnClickButton);
    }

    void OnClickButton() {
        Destroy(this.gameObject);
        if (button.eventOnClick != null) {
            button.eventOnClick.Raise();
        }
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return)) {
            OnClickButton();
        }
    }
}
