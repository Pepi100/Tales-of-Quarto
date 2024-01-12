using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.Model;

[Serializable]
public class InventoryItemSerilization
{
    [SerializeField]
    private int _quantity;
    [SerializeField]
    private int _id;
    [SerializeField]
    private bool _isEmpty;

    public InventoryItemSerilization(InventoryItem item)
    {
        if (item.IsEmpty)
        {
            this._isEmpty = true;
        }
        else
        {
            this._quantity = item.quantity;
            this._id = item.item.ID;
            this._isEmpty = false;
        }
        
    }

    public bool isEmpty()
    {
        return this._isEmpty;
    }

    public int getId()
    {
        return _id;
    }

    public int getQuantity()
    {
        return _quantity;
    }
}

[Serializable]
public class Vector3Serilization
{
    [SerializeField]
    private float _x;
    [SerializeField]
    private float _y;
    [SerializeField]
    private float _z;

    public Vector3Serilization(Vector3 position)
    {
        this._x = position.x;
        this._y = position.y;
        this._z = position.z;
    }

    public Vector3 GetValue()
    {
        return new Vector3(_x, _y, _z);
    }
}