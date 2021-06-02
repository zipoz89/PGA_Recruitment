using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class Prompt : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI label;
    [SerializeField] protected string labelText = "label text";

    protected virtual void Start() {
        label = this.transform.GetChild(0).gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public abstract void SetData(PromptData data);
}
[System.Serializable]
public struct ButtonData {
    public Button button;
    public TextMeshProUGUI tmp;
    public string text;
    public VoidEvent eventOnClick;
}