using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class SlotData : MonoBehaviour
{
    public TextMeshProUGUI text_Count;

    private int itemCount;

    Item item;

    public Image iconImg;

    protected Button buttonEvent;

    //�������� �����ϰ� �ִ� �������� �ƴ���
    public bool initItem { get; private set; } = false;
    //public Sprite sprite { get; set; }

    //private void Awake()
    //{
    //    iconImg = GetComponent<Image>();
    //}
    void Awake()
    {
        buttonEvent = GetComponent<Button>();
    }
    public virtual void AddItem(Item newitem)
    {
        item = newitem;
        iconImg.sprite = item.icon;
        iconImg.enabled = true;
        Debug.Log("���� AddItem");
        
        //buttonEvent.onClick.AddListener(newitem.UsedItem);

        initItem = true;
    }
    // �ش� ������ ������ ���� ������Ʈ
    public virtual void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
        ClearSloat();
    }
    public virtual void ClearSloat()
    {
        item = null;
        iconImg.sprite = null;
        itemCount = 0;
        text_Count.gameObject.SetActive(false);
        iconImg.enabled = false;
    }
}