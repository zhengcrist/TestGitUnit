using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public PotionSlot_Script[] inventorySlots;
    public GameObject inventoryItemPrefab;

    public void AddItem(Item_Script item)
    {
        // Find the same slot
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            PotionSlot_Script slot = inventorySlots[i];
            InventoryItem_Script itemInSlot = slot.GetComponentInChildren<InventoryItem_Script>();
            if (itemInSlot.item == item) {
                SpawnNewItem(item, slot);
            }
        }
    }

    void SpawnNewItem(Item_Script item, PotionSlot_Script slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem_Script inventoryItem = newItemGo.GetComponent<InventoryItem_Script>();
        inventoryItem.InitialiseItem(item);
    }
}
