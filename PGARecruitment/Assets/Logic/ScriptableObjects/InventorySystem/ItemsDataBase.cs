using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items Database", menuName = "Items System/Database/Items Database")]
public class ItemsDataBase : ScriptableObject
{
    public Item BlackItem;
    public Item[] items;
    [ContextMenu("Update ID's")]
    public void UpdateID() {
        BlackItem.ID = -1;
        for (int i = 0; i < items.Length; i++) {
            items[i].ID = i;

        }
    }
}
