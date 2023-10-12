using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : Item
{
    public int damage;

    public WeaponItem(string name, string desc, Sptrite icon, int damage) : base(name, desc, icon) 
    {
        this.damage = damage;
    }

    public override void UseItem()
    {
        //below may not be needed
        Debug.Log($"Using weapon: {itemName}, Damage: {damage}");
    
    }
}
