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
        [SerializeField]
        private InventorySO _inventoryData;
        [SerializeField]
        private InventoryController _inventoryController;

        // Start is called before the first frame update
        void Start2()
        {
            foreach (Transform child in recipeParent)
            {
                Destroy(child.gameObject);
            }

            for (int i = 0; i < recipes.Length; i++)
            {

                if (true)
                {

                    GameObject newRecipe = Instantiate(recipePrefab, recipeParent);
                    newRecipe.name = recipes[i].name;

                    ItemRecipe recipeScript = recipeParent.GetChild(i).GetComponent<ItemRecipe>();
                    recipeScript.UpdateRecipeUI(recipes[i]);

                }
            }


            for (int i = 0; i < recipeParent.childCount; i++)
            {
                
                /*ItemRecipeSO recipeSO = null;

                foreach (ItemRecipeSO r in recipes)
                {
                    Debug.Log(recipeParent.GetChild(i).name);
                    if (r.recipeName == recipeParent.GetChild(i).name)
                    {
                        recipeSO = r;
                        break;
                    }
                }*/


            }
        }

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

        public bool CanCraftRecipe(ItemRecipeSO recipeSO)
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


        }




    }
}