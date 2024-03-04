using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public int id;
    public bool HeroSlot;
    public Item item;
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            InventoryItem InvenotryItem = dropped.GetComponent<InventoryItem>();
            InvenotryItem.parentAfterDrag = transform;
        }

    }
}