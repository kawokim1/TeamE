using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item item;
    private void OnInteractions(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
         Inventory.instance.Add(item);
         Destroy(gameObject);
    }
}
