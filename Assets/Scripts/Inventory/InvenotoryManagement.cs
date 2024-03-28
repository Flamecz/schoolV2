using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvenotoryManagement : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    //    public DataHolder dataHolder;
    public InvetorySaver invetorySaver;
    private void Start()
    {
        CheckAtStart();
    }
    public void CheckAtStart()
    {
        for (int i = 0; i < invetorySaver.unitList.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem ItemInSlot = slot.GetComponentInChildren<InventoryItem>();
            Debug.Log("Check 1");
            if (ItemInSlot == null)
            {
                Debug.Log("Check 2");
                if (invetorySaver.unitList[i] != null)
                {
                    Debug.Log("Check 3");
                    SpawnNewItem(invetorySaver.unitList[i], slot, invetorySaver.unitCount[i]);
                }

            }
        }
        Debug.Log("Nothing Found");

    }
    public bool AddItem(Unit item,int count)
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
                CheckForUpdatedInvetory(i, item, count);
                return true;
            }
        }
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem ItemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (ItemInSlot == null)
            {
                SpawnNewItem(item, slot,count);
                CheckForUpdatedInvetory(i, item, count);
                return true;
            }
        }
        return false;
    }
    public bool splitItems(Unit item, int splitCount)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem ItemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (ItemInSlot == null)
            {
                SpawnNewItem(item, slot, splitCount);
                return true;
            }
        }
        return false;
    }
    public bool mergeItems(Unit item, int count,InventoryItem targetItem)
    {
        if (targetItem != null &&
              targetItem.item == item &&
              targetItem.count + count <= 9999 &&
              targetItem.item.stackable)
        {
            targetItem.count += count;
            targetItem.RefreshCount();
            return true;
        }
        else if (targetItem == null)
        {
            InventoryItem leftItem = FindItemToLeft(targetItem.transform);
            if (leftItem != null && leftItem.item == item && leftItem.count + count <= 9999 && leftItem.item.stackable)
            {
                leftItem.count += count;
                leftItem.RefreshCount();
                return true;
            }
            InventoryItem rightItem = FindItemToRight(targetItem.transform);
            if (rightItem != null && rightItem.item == item && rightItem.count + count <= 9999 && rightItem.item.stackable)
            {
                rightItem.count += count;
                rightItem.RefreshCount();
                return true;
            }
        }

        return false;
    }
    public void CheckForUpdatedInvetory(int index,Unit item, int count)
    {
        invetorySaver.unitList[index] = item;
        invetorySaver.unitCount[index] += count;
    }

    private InventoryItem FindItemToLeft(Transform startTransform)
    {
        Collider2D hit = Physics2D.OverlapCircle(startTransform.position, 1f, LayerMask.GetMask("InventoryItem"));
        return hit != null ? hit.GetComponent<InventoryItem>() : null;
    }

    private InventoryItem FindItemToRight(Transform startTransform)
    {
        Collider2D hit = Physics2D.OverlapCircle(startTransform.position, 1f, LayerMask.GetMask("InventoryItem"));
        return hit != null ? hit.GetComponent<InventoryItem>() : null;
    }

    void SpawnNewItem(Unit item, InventorySlot slot)
    {
        GameObject NewItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem InventoryItem = NewItemGo.GetComponent<InventoryItem>();
        InventoryItem.InitialiseItem(item);
    }
    void SpawnNewItem(Unit item, InventorySlot slot,int count)
    {
        GameObject NewItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem InventoryItem = NewItemGo.GetComponent<InventoryItem>();
        InventoryItem.count = count;
        InventoryItem.InitialiseItem(item);
    }
}