using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

[CreateAssetMenu(menuName = "Inventory/Expendables", fileName = "Expendables", order = 2)]
public class Item_Expendables : Item
{
    public float healingCount = 0.0f;
    public override void UsedItem()
    {
        Debug.Log("È¸º¹µÊ");
        GameManager.gm.HP += healingCount;
    }
}