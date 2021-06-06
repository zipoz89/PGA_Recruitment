using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//specialization of ClickableObject class, adds ability to add item to inventory
public class ClickableDoor : ClickableObject {
    [SerializeField] private GameObject noKeyPrompt;
    [SerializeField] private PromptData noKeyPromptData;

    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private Item keyItem;
    [SerializeField] private bool unlocked = false;
    protected override void Start() {
        base.Start();
        inventory = FindObjectOfType<PlayerInventory>();
    }

    private void OpenDoorPrompt() {
        GameObject o = Instantiate(prompt, objestToparentPrompt);
        PromptTwoOptions promptManager = o.GetComponent<PromptTwoOptions>();
        promptManager.SetData(data);

    }

    private void NoKeyPrompt() {
        
        GameObject o = Instantiate(noKeyPrompt, objestToparentPrompt);
        PromptOneOption promptManager = o.GetComponent<PromptOneOption>();
        promptManager.SetData(noKeyPromptData);
    }

    protected override void Clicked() {
        if (objectCllicked != null)
            objectCllicked.Raise();
        if (!unlocked) {
            if (inventory.FindAndConsume(keyItem)) {
                unlocked = true;
                OpenDoorPrompt();
            }
            else
                NoKeyPrompt();
        }
        else
            OpenDoorPrompt();

    }




}
