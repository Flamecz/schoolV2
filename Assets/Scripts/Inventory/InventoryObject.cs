using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : MonoBehaviour
{
    public InventoryObject(Unit unit , int count)
    {
        this.unit = unit;
        this.count = count;
    }
    public Unit unit;
    public int count;
}
