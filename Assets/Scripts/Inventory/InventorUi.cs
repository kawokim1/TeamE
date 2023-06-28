using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class InventorUi : MonoBehaviour
{
    ExSlot[] exslot; // 0
    EqSlot[] eqslot;
    Inventory inventory;
    public Transform sloatParent1;
    public Transform sloatParent2;
    int _count = 1;

    private void Awake()
    {
        inventory = Inventory.instance;

        exslot = sloatParent1.GetComponentsInChildren<ExSlot>();
        eqslot = sloatParent2.GetComponentsInChildren<EqSlot>();
        //Debug.Log(sloat.Length);
    }
    private void Start()
    {
        inventory.onExItemChanged += ExSlotUIUpdate;
        inventory.onEqItemChanged += EqSlotUIUpdate;
    }
    //void SlotUI()
    //{
    //for (int i =0; i < exslot.Length; i++)
    //{            
    //    if (inventory.items.Count > i)
    //    {
    //        Debug.Log("폴문 접근");
    //        ItemType itemType = inventory.items[i].itemType;
    //        Debug.Log($"아이템 정보{inventory.items[i].itemType}");
    //        switch (itemType)
    //        {
    //            case ItemType.equipment:
    //                if (!eqslot[i].initItem)
    //                {
    //                    Debug.Log("장비 아이템 정보 들어옴");
    //                    eqslot[i].AddItem(inventory.items[i]);
    //                    break;
    //                }
    //                break;
    //            case ItemType.expendables:
    //                if (exslot[i].initItem)
    //                {
    //                    Debug.Log("소모품 아이템 중첩");
    //                    exslot[i].SetSlotCount(_count);
    //                }
    //                if (!exslot[i].initItem)
    //                {
    //                    Debug.Log("소모품 아이템 정보 들어옴");
    //                    exslot[i].AddItem(inventory.items[i]);
    //                }
    //                break;
    //        }
    //    }
    //}
    //}
    void ExSlotUIUpdate(Item _item)
    {
        for (int i = 0; i < exslot.Length; i++) //기존의 슬롯 
        {
            if (!exslot[i].initItem)
            {
                for (int j = 0; j < inventory.exItems.Count; j++) //새로 들어갈 아이템
                {
                    if (inventory.exItems[j].id == _item.id && exslot[j].initItem)
                    {
                        Debug.Log("소모품 아이템 중첩");
                        exslot[j].SetSlotCount(_count);
                        return;
                    }
                    else if (!exslot[i].initItem && j == inventory.exItems.Count - 1)
                    {
                        Debug.Log("소모품 아이템 정보 들어옴");
                        exslot[i].AddItem(inventory.exItems[j]);
                        exslot[i].SetSlotCount(_count);
                        break;
                    }
                }
                break;
            }
        }
    }
    void EqSlotUIUpdate(Item _item)
    {
        for (int i = 0; i < eqslot.Length; i++)
        {
            if (!eqslot[i].initItem)
            {
                for (int j = 0; j < inventory.eqItems.Count; j++)
                {
                    if (!eqslot[i].initItem)
                    {
                        Debug.Log("장비 아이템 정보 들어옴");
                        eqslot[i].AddItem(inventory.eqItems[j]);
                        break;
                    }
                }
                break;
            }
        }
    }
}