using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//stores data and events for prompts

[CreateAssetMenu(fileName ="Prompt Data",menuName ="Data Management/Prompt Data")]
public class PromptData : ScriptableObject
{
    [TextArea(2, 5)]
    public string label;
    public PromptOptions[] options;

}
[System.Serializable]
public struct PromptOptions {
    public string optionText;
    public VoidEvent optionEvent;
}
