using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitsLost", menuName = "UnitsLost")]
public class UnitsLost : ScriptableObject
{
    public Unit[] PlayerUnitsLost = new Unit[7];
    public Unit[] EnemyUnitsLost = new Unit[7];

    public int[] PlayerUnitsStart;
    public int[] EnemyUnitsStart;

    public int[] PlayerUnitsCountLost;
    public int[] EnemyUnitsCountLost;
}
