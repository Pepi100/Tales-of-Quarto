using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Inventory.Model
{
    

    public class CraftingManager : MonoBehaviour
    {
        [SerializeField]
        private ItemRecipeSO[] recipes;
        [SerializeField]
        private GameObject recipePrefab;
        [SerializeField]
        private Transform recipeParent;


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

        // Update is called once per frame
        void Update()
        {

        }


        private void UpdateRecipeUI()
        {

            
        }



    }
}