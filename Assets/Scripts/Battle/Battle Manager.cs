using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{

    public Transform[] aliedPosition;

    public Transform[] enemyPosition;

    public Transform aliedUnitsParent;
    public Transform enemyUnitsParent;
    public InvetorySaver playerUnits;
    public InvetorySaver enemyUnits;
    public GameObject unitPefab;
    [Header ("Gifs")]
    private bool decisionOpened;

    public GameObject DecisionPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < playerUnits.unitList.Length; i++)
        {
            if(playerUnits.unitList[i] != null)
            {
                CreateAliedUnit(i);
            }
        }
        for (int i = 0; i < enemyUnits.unitList.Length; i++)
        {
            if (enemyUnits.unitList[i] != null)
            {
                CreateEnemyUnit(i);
            }
        }
    }
    private void Update()
    {
        if (enemyUnitsParent.childCount == 0 && !decisionOpened)
        {
            DecisionPrefab.SetActive(true);
            FindObjectOfType<BattleUiManager>().SetWinData();
        }
        if (aliedUnitsParent.childCount == 0 && !decisionOpened)
        {
            DecisionPrefab.SetActive(true);
            FindObjectOfType<BattleUiManager>().SetLossData();
        }
    }
    public void CreateAliedUnit(int i)
    {
        GameObject go = Instantiate(unitPefab, aliedPosition[i].transform.position, aliedPosition[i].transform.rotation, aliedUnitsParent);
    }
    public void CreateEnemyUnit(int i)
    {
        GameObject go = Instantiate(unitPefab, enemyPosition[i].transform.position, enemyPosition[i].transform.rotation, enemyUnitsParent);
    }

}
