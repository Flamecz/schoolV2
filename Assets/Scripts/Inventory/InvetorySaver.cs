using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvetorySaver : ScriptableObject
{
    public InventoryObject[] inventoryObjects = new InventoryObject[6];

    public void Add(InventoryObject obj)
    {
        // Find the first empty slot in the inventoryObjects array
        for (int i = 0; i < inventoryObjects.Length; i++)
        {
            if (inventoryObjects[i] == null)
            {
                // Assign the object to the empty slot
                inventoryObjects[i] = obj;
                Debug.Log("Added " + obj.name + " to inventory slot " + i);
                return;
            }
        }
    }
}