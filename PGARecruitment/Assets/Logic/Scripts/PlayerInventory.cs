﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//basic inventory class that stores Items in array
//I havent done displaying of items you have becuase i didnt wanted to overdo and at the sime time didnt want to be just a if check though it would be moderetly easy to do it from now

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


    public bool AddItem(Item itemToAdd) {
        for (int i = 0; i < inventory.Length; i++) {
            if (inventory[i] == database.BlackItem) {
                inventory[i] = itemToAdd;

               return true;
            } 
        }
        return false;
    }

    public bool FindAndConsume(Item itemToConsume) {
        for (int i = 0; i < inventory.Length; i++) {
            if (inventory[i] == itemToConsume) {
                inventory[i] = database.BlackItem;
                return true;
            }
        }
        return false;
    }
}
