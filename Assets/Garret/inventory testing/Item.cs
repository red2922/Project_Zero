using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{

    public string itemName;
    public string description;
    public Sprite icon;


    public Item(string name, string desc, Sprite icon) {
        this.itemName = name;
        this.description = desc;
        this.icon = icon;
    }

    //below may not be necessary
    public abstract void UseItem();
}
