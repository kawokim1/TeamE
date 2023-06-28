using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Equipment", fileName = "Equipment", order = 1)]
public class Item_Equipment : Item
{
    public float PlusAttack = 0.0f;
    
    public override void UsedItem()
    {
        Debug.Log("공격력 증가");
        GameManager.gm.attack += PlusAttack;
    }
}
