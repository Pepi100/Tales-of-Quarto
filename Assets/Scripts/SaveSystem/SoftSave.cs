using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.Model;
using Inventory;

public class SoftSave : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private TestSpawner _testSpawner;

    public void SoftSaveData()
    {
        float currentHealth = _player.GetComponent<Health>().getCurrentHealth();
        int currentWeapon = _player.GetComponent<AgentWeapon>().GetItemID();

        List<InventoryItemSerilization> currentInventoryItems = new List<InventoryItemSerilization>();
        List<InventoryItem> inventoryItems = _player.GetComponent<InventoryController>().getData().getInventoryItems();

        foreach (InventoryItem item in inventoryItems)
        {
            currentInventoryItems.Add(new InventoryItemSerilization(item));
        }

        PlayerSoftDataDTO data = new PlayerSoftDataDTO(
            new Vector3Serilization(_player.transform.position),
            _testSpawner.getTreesLocation(),
            _testSpawner.getStonesLocation(),
            currentInventoryItems,
            currentWeapon,
            currentHealth
            );
        PlayerData.instance.softSetAll(data);
    }
}
