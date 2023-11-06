using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.Model;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField]
    private InventorySO _inventoryData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        if (item != null)
        {
            int reminder = _inventoryData.AddItem(item.InventoryItem, item.Quantity);
            if (reminder == 0)
                item.DestroyItem();
            else
                item.Quantity = reminder;
        }
    }
}
