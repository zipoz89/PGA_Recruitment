using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsOnSceneManager : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private ItemsDataBase database;
    public void AddItemToPlayerInventory(Item item) {
        inventory.addItem(item);
    }

    public void AddKey() {
        AddItemToPlayerInventory(database.items[0]);
    }
}
