using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PromptManager2Options : MonoBehaviour
{
    //optional
    [SerializeField] private Button optionOneButton;
    [SerializeField] private Button optionTwoButton;
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private TextMeshProUGUI optionOne;
    [SerializeField] private TextMeshProUGUI optionTwo;

    [SerializeField] private string labelText = "label text";
    [SerializeField] private string optionOneText = "yes";
    [SerializeField] private string optionTwoText = "no";

    [SerializeField] private VoidEvent eventOnButtonOne;
    [SerializeField] private VoidEvent eventOnButtonTwo;


    public void SetData(string _label, string _optionOne, string _optionTwo, VoidEvent _eventOnButtonOne, VoidEvent _eventOnButtonTwo) {
        labelText = _label;
        optionOneText = _optionOne;
        optionTwoText = _optionTwo;
        eventOnButtonOne = _eventOnButtonOne;
        eventOnButtonTwo = _eventOnButtonTwo;
    }
    public void SetData(PromptData data) {
        labelText = data.label;
        optionOneText = data.options[0].optionText;
        optionTwoText = data.options[1].optionText;
        eventOnButtonOne = data.options[0].optionEvent;
        eventOnButtonTwo = data.options[1].optionEvent;
    }

    private void Start() {
        label = this.transform.GetChild(0).gameObject.GetComponentInChildren<TextMeshProUGUI>();
        optionOneButton = this.transform.GetChild(1).gameObject.GetComponent<Button>();
        optionOne = this.transform.GetChild(1).gameObject.GetComponentInChildren<TextMeshProUGUI>();
        optionTwoButton = this.transform.GetChild(2).gameObject.GetComponent<Button>();
        optionTwo = this.transform.GetChild(2).gameObject.GetComponentInChildren<TextMeshProUGUI>();

        label.text = labelText;
        optionOne.text = optionOneText;
        optionTwo.text = optionTwoText;

        optionOneButton.onClick.AddListener(OnClickButtonOne);
        optionTwoButton.onClick.AddListener(OnClickButtonTwo);
    }

    void OnClickButtonOne() {
            Destroy(this.gameObject);
        if (eventOnButtonOne != null) { 
            eventOnButtonOne.Raise();
        }
    }
    void OnClickButtonTwo() {
            Destroy(this.gameObject);
        if (eventOnButtonTwo != null) { 
            eventOnButtonTwo.Raise();
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            OnClickButtonTwo();
        }
    }
}
