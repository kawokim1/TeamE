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
    //        Debug.Log("���� ����");
    //        ItemType itemType = inventory.items[i].itemType;
    //        Debug.Log($"������ ����{inventory.items[i].itemType}");
    //        switch (itemType)
    //        {
    //            case ItemType.equipment:
    //                if (!eqslot[i].initItem)
    //                {
    //                    Debug.Log("��� ������ ���� ����");
    //                    eqslot[i].AddItem(inventory.items[i]);
    //                    break;
    //                }
    //                break;
    //            case ItemType.expendables:
    //                if (exslot[i].initItem)
    //                {
    //                    Debug.Log("�Ҹ�ǰ ������ ��ø");
    //                    exslot[i].SetSlotCount(_count);
    //                }
    //                if (!exslot[i].initItem)
    //                {
    //                    Debug.Log("�Ҹ�ǰ ������ ���� ����");
    //                    exslot[i].AddItem(inventory.items[i]);
    //                }
    //                break;
    //        }
    //    }
    //}
    //}
    void ExSlotUIUpdate(Item _item)
    {
        for (int i = 0; i < exslot.Length; i++) //������ ���� 
        {
            if (!exslot[i].initItem)
            {
                for (int j = 0; j < inventory.exItems.Count; j++) //���� �� ������
                {
                    if (inventory.exItems[j].id == _item.id && exslot[j].initItem)
                    {
                        Debug.Log("�Ҹ�ǰ ������ ��ø");
                        exslot[j].SetSlotCount(_count);
                        return;
                    }
                    else if (!exslot[i].initItem && j == inventory.exItems.Count - 1)
                    {
                        Debug.Log("�Ҹ�ǰ ������ ���� ����");
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
                        Debug.Log("��� ������ ���� ����");
                        eqslot[i].AddItem(inventory.eqItems[j]);
                        break;
                    }
                }
                break;
            }
        }
    }
}