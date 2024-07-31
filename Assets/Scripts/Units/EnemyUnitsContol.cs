using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitsContol : MonoBehaviour
{
    public Unit[] RandomUnits;
    public int[] RandomUnitCount;
    public InvetorySaver enemyUnits;

    public void SetEnemyUnits()
    {
        for (int i = 0; i < RandomUnits.Length; i++)
        {
            enemyUnits.unitList[i] = RandomUnits[i];
            enemyUnits.unitCount[i] = RandomUnitCount[i];
        }
    }
    public void ResetToNullUnits()
    {
        for (int i = 0; i < 7; i++)
        {
            enemyUnits.unitList[i] = null;
            enemyUnits.unitCount[i] = 0;
        }
    }
}
