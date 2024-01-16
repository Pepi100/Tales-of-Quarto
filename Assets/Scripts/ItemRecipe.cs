using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Security.Cryptography;

namespace Inventory.Model
{
    


    [System.Serializable]
    public class ItemRecipe : MonoBehaviour
    {
        private bool craftingEnabled = false;
        public ItemRecipeSO recipeSO;
        

        [SerializeField] GameObject itemPrefab;
        
        [SerializeField] GameObject plusSignPrefab;
        [SerializeField] GameObject equalSignPrefab;
        [SerializeField]
        private InventoryController _inventoryController;


        public bool CanCraft()
        {
            bool canCraft = true;

            foreach(ItemTypeAndCount itc in recipeSO.input ) {

                if( ! _inventoryController.getData().CheckStackableItem(itc.item, itc.count) )
                {
                    canCraft = false; 
                    break;
                }
            }

            return canCraft;
        }

        public void OnPointerEnter()
        {
            
        }


        public void OnPointerExit()
        {
            
        }

        public void OnPointerClick()
        {
            Debug.Log("aaaa");

          
                if (CanCraft())
                {
                    foreach (ItemTypeAndCount itc in recipeSO.input)
                    {

                        _inventoryController.getData().RemoveStackableItem(itc.item, itc.count);

                    }

                    foreach (ItemTypeAndCount itc in recipeSO.output)
                    {

                        _inventoryController.getData().AddItem(itc.item, itc.count, itc.item.DefaultParametersList);

                    }



                
            }
            
            
        }

     





        private void Start ()
        {
            UpdateRecipeUI(recipeSO);
        }

        public void UpdateRecipeUI(ItemRecipeSO newRecipeSO)
        {
            recipeSO = newRecipeSO;

            foreach(Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            for (int i = 0; i< recipeSO.input.Length; i++)
            {
                GameObject newItem = Instantiate(itemPrefab, transform);
                Transform itemImage =  newItem.transform.GetChild(0).GetChild(0);
                itemImage.GetComponent<Image>().sprite = recipeSO.input[i].item.ItemImage;
                itemImage.gameObject.SetActive(true);

                Transform itemCount = newItem.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0);
                itemCount.GetComponent<TextMeshProUGUI>().text = recipeSO.input[i].count.ToString();


                if (i< recipeSO.input.Length - 1 )
                {
                    Instantiate(plusSignPrefab, transform);
                }


                

            }

            Instantiate(equalSignPrefab, transform);


            for (int i = 0; i < recipeSO.output.Length; i++)
            {
                GameObject newItem = Instantiate(itemPrefab, transform);

                Transform itemImage = newItem.transform.GetChild(0).GetChild(0);
                itemImage.GetComponent<Image>().sprite = recipeSO.output[i].item.ItemImage;
                itemImage.gameObject.SetActive(true);

                Transform itemCount = newItem.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0);
                itemCount.GetComponent<TextMeshProUGUI>().text = recipeSO.output[i].count.ToString();


                if (i < recipeSO.output.Length - 1)
                {
                    Instantiate(plusSignPrefab, transform);
                }

            }

        }

    }

}
