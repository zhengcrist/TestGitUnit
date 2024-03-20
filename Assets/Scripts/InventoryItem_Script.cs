using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem_Script : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item_Script item;

    [Header("UI")]
    public Image image;

    [HideInInspector] public Transform parentAfterDrag;

    private void Start()
    {
        InitialiseItem(item);
    }

    public void InitialiseItem(Item_Script newItem)
    {
        image.sprite = newItem.image;
    }

    // Drag and drop
    public void OnBeginDrag(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}
