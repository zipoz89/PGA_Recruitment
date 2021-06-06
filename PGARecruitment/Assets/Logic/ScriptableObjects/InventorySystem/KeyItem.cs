using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Key Item", menuName = "Items System/Items/Key Item")]
public class KeyItem : Item
{
    private void Awake() {
        type = ItemType.Key;
    }
}
