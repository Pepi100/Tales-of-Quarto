using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using Inventory.UI;
using Inventory.Model;

namespace Inventory
{


    public class InventoryController : MonoBehaviour
    {

        public static InventoryController Instance {  get; private set; }
        public List<ItemTypeAndCount> items = new List<ItemTypeAndCount>();

        [SerializeField]
        private UIInventoryPage _inventoryUI;
        [SerializeField]
        private InventorySO _inventoryData;
        [SerializeField]
        private AudioClip _dropClip;

        [SerializeField]
        private AudioSource _audioSource;
        [SerializeField]
        private GameObject craftingParent;


        bool isCraftingOpened;

        private void Awake()
        {

            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

        }


        public Dictionary<int, InventoryItem> GetAllItems()
        {


            return _inventoryData.GetCurrentInventoryState();
            
        }


        public List<InventoryItem> initialItems = new List<InventoryItem>();

        private void Start()
        {
            PrepareUI();
            PrepareInventoryData();
        }

        public void OpenInventory(InputAction.CallbackContext context)
        {

            if( context.control.displayName == "E")
            {
                if (_inventoryUI.isActiveAndEnabled == false)
                {
                    _inventoryUI.Show();
                    foreach (var item in _inventoryData.GetCurrentInventoryState())
                    {
                        _inventoryUI.UpdateData(item.Key,
                            item.Value.item.ItemImage,
                            item.Value.quantity);
                    }
                }
                else
                {
                    _inventoryUI.Hide();
                }

            }

            

        }

        private void HandleDescriptionRequest(int itemIndex)
        {
            InventoryItem inventoryItem = _inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
            {
                _inventoryUI.ResetSelection();
                return;
            }

            ItemSO item = inventoryItem.item;
            string description = PrepareDescription(inventoryItem);
            _inventoryUI.UpdateDescription(itemIndex, item.ItemImage, item.Name, description);
        }

        private string PrepareDescription(InventoryItem inventoryItem)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(inventoryItem.item.Description);
            sb.AppendLine();
            for (int i = 0; i < inventoryItem.itemState.Count; i++)
            {
                sb.Append($"{inventoryItem.itemState[i].itemParameter.ParameterName} " +
                    $": {inventoryItem.itemState[i].value} / " +
                    $"{inventoryItem.item.DefaultParametersList[i].value}");
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private void HandleSwapItems(int itemIndex1, int itemIndex2)
        {
            _inventoryData.SwapItems(itemIndex1, itemIndex2);   
        }

        private void HandleDragging(int itemIndex)
        {
            InventoryItem inventoryItem = _inventoryData.GetItemAt(itemIndex);
            if(inventoryItem.IsEmpty)
            {
                return;
            }
            _inventoryUI.CreateDraggingItem(inventoryItem.item.ItemImage,
                                            inventoryItem.quantity);
        }

        private void HandleItemActionRequest(int itemIndex)
        {
            InventoryItem inventoryItem = _inventoryData.GetItemAt(itemIndex);
            if(inventoryItem.IsEmpty)
                return;

            IItemAction itemAction = inventoryItem.item as IItemAction;
            if(itemAction != null)
            {
                _inventoryUI.ShowItemAction(itemIndex);
                _inventoryUI.AddAction(itemAction.ActionName, () => PerformAction(itemIndex));
            }

            IDestroyableItem destroyableItem = inventoryItem.item as IDestroyableItem;
            if(destroyableItem != null)
            {
                _inventoryUI.AddAction("Drop", () => DropItem(itemIndex, inventoryItem.quantity));
            }   
        }

        private void DropItem(int itemIndex, int quantity)
        {
            _inventoryData.RemoveItem(itemIndex, quantity);
            _inventoryUI.ResetSelection();
            _audioSource.PlayOneShot(_dropClip);
        }

        public void PerformAction(int itemIndex)
        {
            InventoryItem inventoryItem = _inventoryData.GetItemAt(itemIndex);
            if(inventoryItem.IsEmpty)
                return;

            IDestroyableItem destroyableItem = inventoryItem.item as IDestroyableItem;
            if(destroyableItem != null)
            {
                _inventoryData.RemoveItem(itemIndex, 1);
            }

            IItemAction itemAction = inventoryItem.item as IItemAction;
            if(itemAction != null)
            {
                itemAction.PerformAction(gameObject, inventoryItem.itemState);
                _audioSource.PlayOneShot(itemAction.actionSFX);
                if(_inventoryData.GetItemAt(itemIndex).IsEmpty)
                    _inventoryUI.ResetSelection();
            }  
        }

        private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
        {
            _inventoryUI.ResetAllItems();
            foreach (var item in inventoryState)
            {
                _inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage,
                    item.Value.quantity);
            }
        }

        private void PrepareUI()
        {
            _inventoryUI.InitializeInventoryUI(_inventoryData.Size);
            _inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
            _inventoryUI.OnSwapItems += HandleSwapItems;
            _inventoryUI.OnStartDragging += HandleDragging;
            _inventoryUI.OnItemActionRequested += HandleItemActionRequest;
        }
        private void PrepareInventoryData()
        {
            _inventoryData.Initialize();
            _inventoryData.OnInventoryUpdated += UpdateInventoryUI;
            foreach (InventoryItem item in initialItems)
            {
                if (item.IsEmpty)
                    continue;
                _inventoryData.AddItem(item);
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                isCraftingOpened = !isCraftingOpened; 
            }


            craftingParent.gameObject.SetActive(isCraftingOpened);

           /* if (isCraftingOpened)
            {
                CraftingManager.UpdateRecipeUI();
            }*/

        }

              
    }
}