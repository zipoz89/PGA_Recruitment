using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default Item", menuName = "Items System/Items/Default Item")]
public class DefaultKey : Item
{
    private void Awake() {
        type = ItemType.Default;
    }
}
