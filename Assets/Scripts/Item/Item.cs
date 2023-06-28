using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    expendables,
    equipment
}
public class Item : ScriptableObject
{
    public ItemType itemType;
    public string named = "æ∆¿Ã≈€";
    public Sprite icon = null;
    public int id = 0;
    public virtual void UsedItem()
    {
    }
}