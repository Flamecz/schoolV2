using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataForEnemy", menuName = "DataForEnemy")]
public class DataForEnemy : ScriptableObject
{
    public UnitStructure[] unitsData = new UnitStructure[7];
}
