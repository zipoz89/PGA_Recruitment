using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//General class form propmt like objets

public abstract class Prompt : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI label;
    [SerializeField] protected PromptData data;

    protected virtual void Start() {
        if (label != null)
            return;
        label = this.transform.GetChild(0).gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public virtual void DisplayData() {
        label.text = data.label;
    }

    public virtual void SetData(PromptData data) {
        if (label == null) Start();
        this.data = data;

        DisplayData();
    }
}
[System.Serializable]
public struct ButtonData {
    public Button button;
    public TextMeshProUGUI tmp;
}