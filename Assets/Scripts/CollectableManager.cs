using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableManager : MonoBehaviour
{
    int collectionCount = 0;
    public TextMeshProUGUI countText;

    public void AddToCollection()
    {
        collectionCount = collectionCount + 1;
        countText.text = collectionCount.ToString();
    }

    public bool RemoveFromCollection(int amount)
    {
        if (collectionCount >= amount)
        {
            collectionCount = collectionCount - amount;
            countText.text = collectionCount.ToString();
            return true;
        }
        else
        {
            return false;
        }
    }
}
