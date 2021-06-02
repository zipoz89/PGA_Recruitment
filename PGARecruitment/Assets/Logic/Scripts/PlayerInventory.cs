using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int inventorySize = 3;
    [SerializeField] private ItemsDataBase database;
    [SerializeField] Item[] inventory;


    void Start()
    {
        ClearInventory();

    }

    public void ClearInventory() {
        inventory = new Item[inventorySize];
        for (int i = 0; i < inventory.Length; i++) {
            inventory[i] = database.BlackItem;
        }
    }


    [ContextMenu("Add key")]
    public bool addItem(Item itemToAdd) {
        //Item itemToAdd = database.items[0];
        
        for (int i = 0; i < inventory.Length; i++) {
            if (inventory[i] == database.BlackItem) {
                inventory[i] = itemToAdd;

               return true;
            } 
        }
        return false;

    }
}
