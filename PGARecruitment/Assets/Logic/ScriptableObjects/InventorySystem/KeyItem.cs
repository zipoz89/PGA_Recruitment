using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Key Item", menuName = "Items System/Items/Key Item")]
public class KeyItem : Item
{
    //0 = all   >0 = specific door 
    public int[] unlockableIDs;
    private void Awake() {
        type = ItemType.Key;
    }
}
