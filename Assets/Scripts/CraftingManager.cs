using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Inventory.Model
{
    

    public class CraftingManager : MonoBehaviour
    {
        public static CraftingManager Instance {  get; private set; }

        private Dictionary<int, InventoryItem> items = new Dictionary<int, InventoryItem>();

        [SerializeField]
        private ItemRecipeSO[] recipes;
        [SerializeField]
        private GameObject recipePrefab;
        [SerializeField]
        private Transform recipeParent;
        




        private void Awake()
        {

            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

        }

        int found = 0;

        /*public bool CanCraftRecipe(ItemRecipeSO recipeSO)
        {
            items = _inventoryController.GetAllItems();



            foreach (ItemTypeAndCount needed in recipeSO.input)
            {
                foreach (var item in items)
                {
                    if (needed.item == item.Value.item && needed.count >= item.Value.quantity)
                        found++;
                }
            }

            return found >= recipeSO.input.Length;


        }*/




    }
}