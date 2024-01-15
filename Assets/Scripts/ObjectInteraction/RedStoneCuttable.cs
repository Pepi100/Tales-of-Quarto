using UnityEngine;
using Inventory.Model;
using System.Collections;
using System.Collections.Generic;

namespace Interaction.ToolHit
{
    public class RedStoneCuttable : ToolHit
    {
        [SerializeField]
        private float _health = 1;

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
                CutStone();
            }
        }

        public void CutStone()
        {
            Debug.Log("Boom");
            RedStoneAudioManager.instance.Play();

            _achivController.SetRedRock(true);
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
                    if (t.itemParameter.ParameterName == "SpecialPickaxe")
                    {
                        return 10;
                    }
                }
            }
            Debug.Log("No tool");
            return 0;
        }
    }
}
