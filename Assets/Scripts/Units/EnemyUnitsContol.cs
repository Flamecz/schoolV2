using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitsContol : MonoBehaviour
{
    public Unit[] RandomUnits;
    public int[] RandomUnitCount;
    public InvetorySaver enemyUnits;
    public EnemysToRemove EnemyRemove;
    private bool done;

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
            Debug.Log("yes");
        }
    }
}
