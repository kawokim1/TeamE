using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using static UnityEditor.Progress;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<Item> exItems = new List<Item>();
    public List<Item> eqItems = new List<Item>();

    public delegate void OnItemChanged(Item _item);

    public OnItemChanged onExItemChanged;

    public OnItemChanged onEqItemChanged;

    public GameObject inven;

    bool activeInven = false;

    private void Start()
    {
        inven.SetActive(activeInven);
    }
    void Awake()
    {
        instance = this;
    }
    //private void OnInventory(UnityEngine.InputSystem.InputAction.CallbackContext context)
    //{
    //    if (context.performed)
    //    {
    //        activeInven = !activeInven;
    //        inven.SetActive(activeInven);
    //    }
    //}
    public void Add(Item addedItem)
    {
        if (addedItem.itemType == ItemType.expendables)
        {
            exItems.Add(addedItem);
            onExItemChanged?.Invoke(addedItem); 
        }
        else if (addedItem.itemType == ItemType.equipment)
        {
            eqItems.Add(addedItem);
            onEqItemChanged?.Invoke(addedItem);  
        }
    }
    public void UsedItem(Item item)
    {
        item.UsedItem();
        
        if (item != null)
        {
            item.UsedItem();
        }
    }
}