using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Inventory.Model
{
    [CreateAssetMenu]
    public class SimpleItemSO : ItemSO, IDestroyableItem
    {
        [field: SerializeField]
        public AudioClip actionSFX { get; private set; }
    }
}
