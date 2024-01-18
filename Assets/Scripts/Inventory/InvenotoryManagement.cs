using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenotoryManagement : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
//    public DataHolder dataHolder;

    public bool AddItem(Item item)
    {
        for(int i = 0; i < inventorySlots.Length;i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem ItemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if(ItemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }
    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject NewItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem InventoryItem = NewItemGo.GetComponent<InventoryItem>();
//       InventoryItem.InitialiseItem(item);
    }
    /*
public void CreateObjectInHand(Item item, Transform holdingObject)
{
    GameObject instance = Instantiate(item.instance, holdingObject.transform);
//       FindObjectOfType<PickUpScript>().PickUpObject(instance);

}
public void CreateItemInWorld(Item item , Transform position)
{
    Instantiate(item.instance, position);
}

public void SellItems()
{
    for (int i = 0; i < inventorySlots.Length; i++)
    {
        InventorySlot slot = inventorySlots[i];
        InventoryItem ItemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (ItemInSlot != null)
        {
           dataHolder.scrap += ItemInSlot.item.price;
            Destroy(ItemInSlot.gameObject);
        Debug.Log(dataHolder.scrap);
        }
    }
}
*/
}
