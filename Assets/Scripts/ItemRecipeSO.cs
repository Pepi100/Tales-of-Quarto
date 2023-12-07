using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
[CreateAssetMenu(fileName = "Item Recipe", menuName = "Scriptable Objects/Item Recipe")]*/


namespace Inventory.Model
{
    [CreateAssetMenu]
    public class ItemRecipeSO : ScriptableObject
    {

        public string recipeName;

        public ItemTypeAndCount[] input;
        public ItemTypeAndCount[] output;

    }


    [System.Serializable]
    public class ItemTypeAndCount
    {
        public ItemSO item;
        public int count;


        public ItemTypeAndCount(ItemSO i, int c)
        {
            item = i;
            count = c;
        }

    }

}
