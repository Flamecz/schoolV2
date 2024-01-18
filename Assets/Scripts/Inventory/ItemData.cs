using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemData : MonoBehaviour
{
    public InvenotoryManagement inventoryManager;

    public GameObject itemHolder;
    public Item[] itemToPickUp;



    public void PickupItem()
    {
    /*    int id = itemHolder.GetComponentInChildren<ItemPickedInAir>().item.id;
        bool result = inventoryManager.AddItem(itemToPickUp[id]);
        if (result == true)
        {
           Debug.Log("pickedItem");
           Destroy(itemHolder.transform.GetChild(0).gameObject);
        }
        else
        {
           Debug.Log("Didnt pickedItem");
        }
    */
    }
    public void SummonItem(int index)
    {
        InventorySlot slot = inventoryManager.inventorySlots[index];
        GameObject inventoryItem = slot.GetComponentInChildren<InventoryItem>().gameObject;
   //     Item item = slot.GetComponentInChildren<InventoryItem>().item;

   //     inventoryManager.CreateObjectInHand(item, itemHolder.transform);
        Destroy(inventoryItem);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (itemHolder.transform.childCount == 0)
            {
                if (inventoryManager.inventorySlots[0] != null && inventoryManager.inventorySlots[0].transform.childCount == 0)
                {

                }
                else
                {
                    SummonItem(0);
                }
            }
            else
            {
                PickupItem();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (itemHolder.transform.childCount == 0)
            {
                if (inventoryManager.inventorySlots[1] != null && inventoryManager.inventorySlots[1].transform.childCount == 0)
                {

                }
                else
                {
                    SummonItem(1);
                }
            }
            else
            {
                PickupItem();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (itemHolder.transform.childCount == 0)
            {
                if (inventoryManager.inventorySlots[2] != null && inventoryManager.inventorySlots[2].transform.childCount == 0)
                {

                }
                else
                {
                    SummonItem(2);
                }
            }
            else
            {
                PickupItem();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (itemHolder.transform.childCount == 0)
            {
                if (inventoryManager.inventorySlots[3] != null && inventoryManager.inventorySlots[3].transform.childCount == 0)
                {

                }
                else
                {
                    SummonItem(3);
                }
            }
            else
            {
                PickupItem();
            }
        }
    }
}

