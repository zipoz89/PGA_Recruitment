using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGem : ClickableObjectManager {
    [SerializeField] private Item item;
    [SerializeField] private PlayerInventory inventory;


    public override void PromptYes() {
        if (inventory.AddItem(item)) {
            //outline generates error on destory so i had to set it inactive
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }
    public override void PromptNo() {
        SetActive(true);
    }

}
