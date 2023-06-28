using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ExSlot : SlotData
{
    public override void AddItem(Item newitem)
    {
        base.AddItem(newitem);
    }
    public override void ClearSloat()
    {
        base.ClearSloat();
    }
    public override void SetSlotCount(int _count)
    {
        base.SetSlotCount(_count);
    }
}
