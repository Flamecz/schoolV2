using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UnitList")]
public class InvetorySaver : ScriptableObject
{
    public Unit[] unitList = new Unit[7];
    public int[] unitCount = new int[7];
}