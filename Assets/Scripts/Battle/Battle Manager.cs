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
    private int change = 0;

    void Awake()
    {
        for (int i = 0; i < playerUnits.unitList.Length;i++)
        {
            if (playerUnits.unitList[i] != null)
            {
                change++;
            }
        }
        playerCharacters = new FieldMovement[change];
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

        // Check if there are any player-controlled units left
        bool anyUnitsLeft = false;
        foreach (FieldMovement fm in playerCharacters)
        {
            if (fm != null && !fm.isDead)
            {
                anyUnitsLeft = true;
                break;
            }
        }

        // If no player-controlled units left, end the cycle
        if (!anyUnitsLeft)
        {
            EndCycle();
            return;
        }

        foreach (FieldMovement fm in playerCharacters)
        {
            if (fm != null) fm.enabled = false;
        }

        // Start the turn with the current value of currentTurn
        if (currentTurn < playerCharacters.Length && playerCharacters[currentTurn] != null && !playerCharacters[currentTurn].isDead)
        {
            playerCharacters[currentTurn].enabled = true;
            moveControl.unitPathfinding = playerCharacters[currentTurn];
            Debug.Log("Current unit: " + playerCharacters[currentTurn].unit + ", Speed: " + playerCharacters[currentTurn].unit.speed);
            moveControl.pathfinding.SetSettedValue(playerCharacters[currentTurn].unit.speed * 10);
        }
        // Increment currentTurn after starting the turn
        currentTurn++;
    }
    public void EndTurn()
    {
        if (!isTurnInProgress) return; // Prevent ending a turn that hasn't started

        isTurnInProgress = false;

        // Update the current turn index to the next player-controlled unit
        currentTurn = (currentTurn) % playerCharacters.Length;

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
