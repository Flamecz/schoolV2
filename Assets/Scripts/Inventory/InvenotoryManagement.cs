using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvenotoryManagement : MonoBehaviour, IPointerClickHandler
{
    public Unit unit;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    //    public DataHolder dataHolder;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            AddItem(unit);
    }
    public bool AddItem(Unit item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem ItemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (ItemInSlot != null &&
                ItemInSlot.item == item &&
                ItemInSlot.count < 9999 &&
                ItemInSlot.item.stackable == true)
            {
                ItemInSlot.count++;
                ItemInSlot.RefreshCount();
                return true;
            }
        }
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem ItemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (ItemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }
    void SpawnNewItem(Unit item, InventorySlot slot)
    {
        GameObject NewItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem InventoryItem = NewItemGo.GetComponent<InventoryItem>();
        InventoryItem.InitialiseItem(item);
    }
    void SplitItem()
    {

    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log("yeppe");  
    }
}