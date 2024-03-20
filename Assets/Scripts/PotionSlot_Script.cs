using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PotionSlot_Script : MonoBehaviour, IDropHandler
{
    //Drag and drop
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem_Script inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem_Script>();
            inventoryItem.parentAfterDrag = transform;
        }
    }

}
