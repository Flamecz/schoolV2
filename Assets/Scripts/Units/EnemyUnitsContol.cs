using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitsContol : MonoBehaviour
{
    public DataForEnemy unitStructs;
    public Unit[] RandomUnits;
    public int[] RandomUnitCount;
    public InvetorySaver enemyUnits;
    public EnemysToRemove EnemyRemove;
    public int delete;
    public WhatDelete whatDelete;
    private bool done;

    private void Start()
    {
        RandomUnits = new Unit[7];
        RandomUnitCount = new int[7];
        SetUnits();
    }
    public void SetUnits()
    {
        for (int i = 0; i < unitStructs.unitsData.Length; i++)
        {
            RandomUnits[i] = unitStructs.unitsData[i].unit;
            RandomUnitCount[i] = unitStructs.unitsData[i].count;
        }
    }
    public void SetEnemyUnits()
    {
        for (int i = 0; i < RandomUnits.Length; i++)
        {
            enemyUnits.unitList[i] = RandomUnits[i];
            enemyUnits.unitCount[i] = RandomUnitCount[i];
        }
        whatDelete.delete = delete;
    }
    public void ResetToNullUnits()
    {
        for (int i = 0; i < 7; i++)
        {
            enemyUnits.unitList[i] = null;
            enemyUnits.unitCount[i] = 0;
        }
    }
    private void Update()
    {
        if(EnemyRemove.Dead)
        {
            PathFinding pathfinding = FindObjectOfType<Testing>().pathfinding;
            pathfinding.GetGrid().GetXY(gameObject.transform.position, out int x, out int y);
            pathfinding.GetNode(x, y).SetIsWalkable(true);
            Destroy(gameObject);
        }
        if(!EnemyRemove.Dead && !done)
        {
            PathFinding pathfinding = FindObjectOfType<Testing>().pathfinding;
            pathfinding.GetGrid().GetXY(gameObject.transform.position, out int x, out int y);
            pathfinding.GetNode(x, y).SetIsWalkable(false);
            done = true;
        }
    }
}
