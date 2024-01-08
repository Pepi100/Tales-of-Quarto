using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class InventorySO : ScriptableObject
    {
        [SerializeField]
        private List<InventoryItem> _inventoryItems;

        [field: SerializeField]
        public int Size { get; private set; } = 10;

        public event Action<Dictionary<int, InventoryItem>> OnInventoryUpdated;

        public void Initialize()
        {
            _inventoryItems = new List<InventoryItem>();
            for (int i = 0; i < Size; i++)
            {
                _inventoryItems.Add(InventoryItem.GetEmptyItem());
            }
        }

        public int AddItem(ItemSO item, int quantity, List<ItemParameter> itemState = null)
        {
            if (!item.IsStackable)
            {
                for (int i = 0; i < _inventoryItems.Count; i++)
                {
                    ///we cant pick up
                    while (quantity > 0 && !IsInventoryFull())
                    {
                        quantity -= AddItemToFirstFreeSlot(item, 1, itemState);
                    }
                    InformAboutChange();
                    return quantity;
                }
            }
            quantity = AddStackableItem(item, quantity);
            InformAboutChange();
            return quantity;
        }

        public void AddItem(InventoryItem item)
        {
            AddItem(item.item, item.quantity);
        }

        public void RemoveItem(int itemIndex, int amount)
        {
            if (_inventoryItems.Count > itemIndex)
            {
                if (_inventoryItems[itemIndex].IsEmpty)
                    return;
                int reminder = _inventoryItems[itemIndex].quantity - amount;
                if (reminder <= 0)
                    _inventoryItems[itemIndex] = InventoryItem.GetEmptyItem();
                else
                    _inventoryItems[itemIndex] = _inventoryItems[itemIndex]
                        .ChangeQuantity(reminder);

                InformAboutChange();
            }
        }

        public Dictionary<int, InventoryItem> GetCurrentInventoryState()
        {
            Dictionary<int, InventoryItem> returnValue =
                new Dictionary<int, InventoryItem>();
            for (int i = 0; i < _inventoryItems.Count; i++)
            {
                if (_inventoryItems[i].IsEmpty)
                    continue;
                returnValue[i] = _inventoryItems[i];
            }
            return returnValue;
        }

        private bool IsInventoryFull() => _inventoryItems.Where(item => item.IsEmpty).Any() == false;

        private int AddStackableItem(ItemSO item, int quantity)
        {
            for (int i = 0; i < _inventoryItems.Count; i++)
            {
                if (_inventoryItems[i].IsEmpty)
                    continue;

                if (_inventoryItems[i].item.ID == item.ID)
                {
                    ///find quantity of object x we can take
                    int amountPossibleToTake =
                        _inventoryItems[i].item.MaxStackSize - _inventoryItems[i].quantity;

                    ///if we'll have more than the maximum
                    if (quantity > amountPossibleToTake)
                    {
                        ///set to max and update
                        _inventoryItems[i] = _inventoryItems[i]
                            .ChangeQuantity(_inventoryItems[i].item.MaxStackSize);
                        quantity -= amountPossibleToTake;
                    }
                    ///if we can take all the objects
                    else
                    {
                        _inventoryItems[i] = _inventoryItems[i]
                            .ChangeQuantity(_inventoryItems[i].quantity + quantity);
                        InformAboutChange();
                        return 0;
                    }
                }
            }
            while (quantity > 0 && IsInventoryFull() == false)
            {
                ///facem clamp intre 0 si max
                int newQuantity = Mathf.Clamp(quantity, 0, item.MaxStackSize);
                quantity -= newQuantity;
                AddItemToFirstFreeSlot(item, newQuantity);
            }
            return quantity;
        }

        public bool CheckStackableItem(ItemSO item, int quantity)
        {
            int stackedQuantity = 0;

            // Iterate through the inventory to find the stacked quantity of the specified item
            foreach (var inventoryItem in _inventoryItems)
            {
                if (!inventoryItem.IsEmpty && inventoryItem.item.ID == item.ID)
                {
                    stackedQuantity += inventoryItem.quantity;
                }
            }

            // Check if the stacked quantity is equal to the target quantity
            return stackedQuantity >= quantity;
        }

        public int RemoveStackableItem(ItemSO item, int quantity)
        {
            for (int i = 0; i < _inventoryItems.Count; i++)
            {
                if (_inventoryItems[i].IsEmpty)
                    continue;

                if (_inventoryItems[i].item.ID == item.ID)
                {
                    Debug.Log(_inventoryItems[i].quantity);
                    Debug.Log(quantity);
                    ///if we'll have more than the maximum
                    if (_inventoryItems[i].quantity > quantity)
                    {
                        ///set to max and update
                        _inventoryItems[i] = _inventoryItems[i]
                            .ChangeQuantity(_inventoryItems[i].quantity - quantity);
                        InformAboutChange();
                        return 0;
                    }
                    ///if we can take all the objects
                    else
                    {
                        quantity = quantity - _inventoryItems[i].quantity;
                        RemoveItem(i, _inventoryItems[i].quantity);

                        Debug.Log(quantity);
                        if (quantity == 0)
                        {
                            InformAboutChange();
                            return 0;
                        }

                    }
                }
            }
            return quantity;
        }

        private int AddItemToFirstFreeSlot(ItemSO item, int quantity, List<ItemParameter> itemState = null)
        {
            InventoryItem newItem = new InventoryItem
            {
                item = item,
                quantity = quantity,
                itemState = new List<ItemParameter>(itemState == null ? item.DefaultParametersList : itemState)
            };

            for (int i = 0; i < _inventoryItems.Count; i++)
            {
                if (_inventoryItems[i].IsEmpty)
                {
                    _inventoryItems[i] = newItem;
                    return quantity;
                }
            }
            return 0;
        }

        public InventoryItem GetItemAt(int itemIndex)
        {
            return _inventoryItems[itemIndex];
        }

        public void SwapItems(int itemIndex1, int itemIndex2)
        {
            InventoryItem item1 = _inventoryItems[itemIndex1];
            _inventoryItems[itemIndex1] = _inventoryItems[itemIndex2];
            _inventoryItems[itemIndex2] = item1;
            InformAboutChange();
        }

        private void InformAboutChange()
        {
            OnInventoryUpdated?.Invoke(GetCurrentInventoryState());
        }

    }

    [Serializable]
    public struct InventoryItem
    {
        public int quantity;
        public ItemSO item;
        public List<ItemParameter> itemState;
        public bool IsEmpty => item == null;

        public InventoryItem ChangeQuantity(int newQuantity)
        {
            return new InventoryItem
            {
                item = this.item,
                quantity = newQuantity,
                itemState = new List<ItemParameter>(this.itemState)
            };
        }

        public static InventoryItem GetEmptyItem()
        {
            return new InventoryItem
            {
                item = null,
                quantity = 0,
                itemState = new List<ItemParameter>()
            };
        }
    }
}