using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { 
    Default,
    Key
}


public abstract class Item : ScriptableObject{
    public int ID;
    public string itemName;
    public ItemType type;
}
