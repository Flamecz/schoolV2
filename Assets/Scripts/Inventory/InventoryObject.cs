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
    public bool IsSameUnit(InventoryObject other)
    {
        return this.unit == other.unit;
    }
    public Unit unit;
    public int count;
}
