#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections.Generic;
using Inventory.Model;


[CreateAssetMenu(fileName = "ItemDatabase", menuName = "ScriptableObjects/ItemDatabase", order = 1)]
public class ItemDatabase : ScriptableObject
{
    private Dictionary<int, ItemSO> _items;
    public List<ItemSO> itemList;

    public void InitializeDictioanry()
    {
        _items = new Dictionary<int, ItemSO>();

        foreach (ItemSO item in itemList)
        {
            Debug.LogWarning($"Inserted item id {item.ID}.");
            if (item == null)
                continue;

            if (_items.ContainsKey(item.ID))
            {
                Debug.LogWarning($"Item with ID {item.ID} already exists in the database. Skipping...");
            }
            else
            {
                _items.Add(item.ID, item);
            }
        }
    }

    public ItemSO GetItem(int itemID)
    {
        ItemSO item;
        if (_items.TryGetValue(itemID, out item))
        {
            return item;
        }
        else
        {
            Debug.LogError($"Item with ID {itemID} not found in the database.");
            return null; // or throw an exception, depending on your use case
        }
    }
}