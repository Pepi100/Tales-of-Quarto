using UnityEngine;
using Inventory.Model;
using System.Collections;
using System.Collections.Generic;

namespace Interaction.ToolHit
{
    public class StoneCuttable : ToolHit
    {
        [SerializeField]
        private GameObject _pickUpDrop;
        [SerializeField]
        private float _health = 10;

        public override void Hit(EquippableItemSO tool)
        {
            ToolAudioManager.instance.Play();

            float strenght = computeDamage(tool);
            _health -= strenght;
            Debug.Log(_health);
            if (_health <= 0)
            {
                Vector3 position = transform.position;
                GameObject go = Instantiate(_pickUpDrop);
                go.transform.position = position;
                CutStone();
            }
        }

        public void CutStone()
        {
            Destroy(gameObject);
        }

        private float computeDamage(EquippableItemSO tool)
        {
            if (tool != null)
            {
                List<ItemParameter> toolParameters = tool.DefaultParametersList;
                foreach (var t in toolParameters)
                {
                    Debug.Log(t.itemParameter.ParameterName);
                    if (t.itemParameter.ParameterName == "PickaxeStrength")
                    {
                        return t.value;
                    }
                }
            }
            Debug.Log("No tool");
            return 1;
        }
    }
}
