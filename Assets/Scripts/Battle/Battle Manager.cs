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
    public BattleFieldPlate moveControl;
    [Header ("Gifs")]

    public GameObject DecisionPrefab;
    public FieldMovement[] playerCharacters;
    public FieldMovement[] enemyCharacters;

    private int currentTurn = 0;
    private bool isTurnInProgress = false;

    void Awake()
    {
        playerCharacters = new FieldMovement[7];
        enemyCharacters = new FieldMovement[7];
        for (int i = 0; i < playerUnits.unitList.Length; i++)
        {
            if(playerUnits.unitList[i] != null)
            {
                CreateAliedUnit(i, playerUnits.unitList[i]);
            }
        }
        for (int i = 0; i < enemyUnits.unitList.Length; i++)
        {
            if (enemyUnits.unitList[i] != null)
            {
                CreateEnemyUnit(i, enemyUnits.unitList[i]); 
            }
        }
        StartTurn();
    }
    private void Update()
    {
        if (enemyUnitsParent.childCount < 1)
        {
            DecisionPrefab.SetActive(true);
            FindObjectOfType<BattleUiManager>().SetWinData();
        }
        if (aliedUnitsParent.childCount < 1 )
        {
            DecisionPrefab.SetActive(true);
            FindObjectOfType<BattleUiManager>().SetLossData();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            EndTurn();
        }
    }
    public void CreateAliedUnit(int i, Unit unit)
    {
        GameObject go = Instantiate(unitPefab, aliedPosition[i].transform.position, aliedPosition[i].transform.rotation, aliedUnitsParent);
        playerCharacters[i] = go.GetComponent<FieldMovement>();
        playerCharacters[i].unit = unit;
    }
    public void CreateEnemyUnit(int i, Unit unit)
    {
        GameObject go = Instantiate(unitPefab, enemyPosition[i].transform.position, enemyPosition[i].transform.rotation, enemyUnitsParent);
        enemyCharacters[i] = go.GetComponent<FieldMovement>();
    }
    public void StartTurn()
    {
        if (isTurnInProgress) return;

        isTurnInProgress = true;

        foreach (FieldMovement fm in playerCharacters)
        {
            if (fm != null) fm.enabled = false;
        }

        if (currentTurn < playerCharacters.Length)
        {
            playerCharacters[currentTurn].enabled = true;
            moveControl.unitPathfinding = playerCharacters[currentTurn];
            Debug.Log("Current unit: " + playerCharacters[currentTurn].unit + ", Speed: " + playerCharacters[currentTurn].unit.speed);
            moveControl.pathfinding.SetSettedValue(playerCharacters[currentTurn].unit.speed * 10);
        }
    }
    public void EndTurn()
    {
        if (!isTurnInProgress) return; // Prevent ending a turn that hasn't started

        isTurnInProgress = false;

        // Update the current turn index to the next player-controlled unit
        currentTurn = (currentTurn + 1) % playerCharacters.Length;

        if(currentTurn < playerCharacters.Length)
        {
            StartTurn();
        }
        else
        {
            EndCycle();
        }
    }
    public void EndCycle()
    {
        currentTurn = 0;
    }
}
