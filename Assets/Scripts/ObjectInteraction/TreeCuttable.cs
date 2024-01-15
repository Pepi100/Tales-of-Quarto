using UnityEngine;
using Inventory.Model;
using System.Collections;
using System.Collections.Generic;

namespace Interaction.ToolHit
{
    public class TreeCuttable : ToolHit
    {
        [SerializeField]
        private GameObject _pickUpDrop;
        [SerializeField]
        private float _health = 10;
        private AchievementController _achivController;

        public void Start()
        {
            _achivController = GameObject.FindWithTag("AchievementController").GetComponent<AchievementController>();
        }

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
                CutTree();
            }
        }

        public void CutTree()
        {
            _achivController.SetTreeCut(true);
            Destroy(gameObject);
        }

        private float computeDamage(EquippableItemSO tool)
        {
            if (tool != null)
            {
                List<ItemParameter> toolParameters = tool.DefaultParametersList;
                foreach (var t in toolParameters)
                {
                    if (t.itemParameter.ParameterName == "AxeStrength")
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
