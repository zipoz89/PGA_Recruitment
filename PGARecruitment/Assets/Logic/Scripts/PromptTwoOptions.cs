using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Specialized  class for rompt with two options
public class PromptTwoOptions : Prompt {

    [SerializeField] private ButtonData buttonOne;
    [SerializeField] private ButtonData buttonTwo;


    protected override void Start() {
        base.Start();
        buttonOne.button = this.transform.GetChild(1).gameObject.GetComponent<Button>();
        buttonOne.tmp = this.transform.GetChild(1).gameObject.GetComponentInChildren<TextMeshProUGUI>();
        buttonTwo.button = this.transform.GetChild(2).gameObject.GetComponent<Button>();
        buttonTwo.tmp = this.transform.GetChild(2).gameObject.GetComponentInChildren<TextMeshProUGUI>();
        
    }

    public override void DisplayData() {
        base.DisplayData();
        buttonOne.button.onClick.AddListener(OnClickButtonOne); 
        buttonTwo.button.onClick.AddListener(OnClickButtonTwo);

        buttonOne.tmp.text = data.options[0].optionText;
        buttonTwo.tmp.text = data.options[1].optionText;

    }



    void OnClickButtonOne() {
        Destroy(this.gameObject);
        if (data.options[0].optionEvent != null)
        {
            data.options[0].optionEvent.Raise();
        }
    }
    void OnClickButtonTwo() {
        Destroy(this.gameObject);
        if (data.options[1].optionEvent != null)
        {
            data.options[1].optionEvent.Raise();
        }
    }

    private void Update() {
        
        if (Input.GetKeyDown(KeyCode.Escape)) {
            OnClickButtonTwo();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnClickButtonOne();
        }
    }
}

