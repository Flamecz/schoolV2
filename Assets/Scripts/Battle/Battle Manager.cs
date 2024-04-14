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
    public FieldMovement[] activeUnits;

    private int currentTurn = 0;
    private bool isTurnInProgress = false;
    private int change = 0, change1 = 0;

    void Awake()
    {
        for (int i = 0; i < playerUnits.unitList.Length;i++)
        {
            if (playerUnits.unitList[i] != null)
            {
                change++;
            }
        }
        for (int i = 0; i < enemyUnits.unitList.Length; i++)
        {
            if (enemyUnits.unitList[i] != null)
            {
                change1++;
            }
        }
        playerCharacters = new FieldMovement[change];
        enemyCharacters = new FieldMovement[change1];
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
        playerCharacters[i].health = PlayerReturnHP(i, unit);
        playerCharacters[i].count = playerUnits.unitCount[i];
        if (playerCharacters[i].unit.ATKT == Unit.attackType.ranger)
        {
            playerCharacters[i].shots = unit.Shots;
        }
    }
    public void CreateEnemyUnit(int i, Unit unit)
    {
        GameObject go = Instantiate(unitPefab, enemyPosition[i].transform.position, enemyPosition[i].transform.rotation, enemyUnitsParent);
        enemyCharacters[i] = go.GetComponent<FieldMovement>();
        enemyCharacters[i].unit = unit;
        enemyCharacters[i].isEnemy = true;
        enemyCharacters[i].health = EnemyReturnHP(i, unit);
        enemyCharacters[i].count = enemyUnits.unitCount[i];
        if (enemyCharacters[i].unit.ATKT == Unit.attackType.ranger)
        {
            enemyCharacters[i].shots = unit.Shots;
        }
        go.AddComponent<EnemyAi>();
        enemyCharacters[i].enabled = false;
    }
    public void StartTurn()
    {
        if (isTurnInProgress) return;

        isTurnInProgress = true;

        // Check if there are any units left for the current turn
        bool anyUnitsLeft = false;
        activeUnits = currentTurn < playerCharacters.Length ? playerCharacters : enemyCharacters;

        foreach (FieldMovement fm in activeUnits)
        {
            if (fm != null && !fm.isDead)
            {
                anyUnitsLeft = true;
                break;
            }
        }

        foreach (FieldMovement fm in activeUnits)
        {
            if (fm != null) fm.enabled = false;
        }

        // Start the turn with the current value of currentTurn
        if (currentTurn < activeUnits.Length && activeUnits[currentTurn] != null && !activeUnits[currentTurn].isDead)
        {
            activeUnits[currentTurn].enabled = true;
            moveControl.unitPathfinding = activeUnits[currentTurn];
            Debug.Log("Current unit: " + activeUnits[currentTurn].unit + ", Speed: " + activeUnits[currentTurn].unit.speed);
            moveControl.pathfinding.SetSettedValue(activeUnits[currentTurn].unit.speed * 10);
        }
        // Increment currentTurn after starting the turn
        currentTurn++;
        Debug.Log(currentTurn);
    }

    public void EndTurn()
    {
        if (!isTurnInProgress) return;

        isTurnInProgress = false;

        // Update the current turn index to the next unit
        FieldMovement[] activeUnits = currentTurn < playerCharacters.Length ? playerCharacters : enemyCharacters;
        int nextTurnIndex = (currentTurn + 1) % activeUnits.Length;

        if (nextTurnIndex == 0)
        {
            // If the next turn index indicates the start of a new cycle,
            // check if any player or enemy units have moved
            if (CheckAnyUnitMoved(playerCharacters) || CheckAnyUnitMoved(enemyCharacters))
            {
                // If any unit has moved, execute enemy turn
                ExecuteEnemyTurn();
            }
            else
            {
                // If no unit has moved, start the player turn again
                currentTurn = 0;
                StartTurn();
            }
        }
        else
        {
            currentTurn = nextTurnIndex;
            StartTurn();
        }
    }
    private void ExecuteEnemyTurn()
    {
        // Boolovská promìnná pro urèení, zda nìjaká nepøátelská jednotka provedla akci
        bool enemyActionTaken = false;

        // Projdeme všechny nepøátelské jednotky
        foreach (FieldMovement enemyUnit in enemyCharacters)
        {
            if (enemyUnit != null && !enemyUnit.isDead && !enemyActionTaken)
            {
                // Deaktivujeme všechny hráèovy jednotky
                foreach (FieldMovement playerUnit in playerCharacters)
                {
                    if (playerUnit != null)
                    {
                        playerUnit.enabled = false;
                        Debug.Log("Deaktivovat hráèovy jednotky.");
                    }
                }

                // Spustíme tah vybrané nepøátelské jednotky
                enemyUnit.enabled = true;
                enemyUnit.GetComponent<EnemyAi>().ExecuteAITurn();
            }
        }
        // Po dokonèení tahù deaktivujeme všechny nepøátelské jednotky
        foreach (FieldMovement enemyUnit in enemyCharacters)
        {
            if (enemyUnit != null)
            {
                enemyUnit.enabled = false;
            }
        }
        currentTurn = 0;
        StartTurn();
    }

    private bool CheckAnyUnitMoved(FieldMovement[] units)
    {
        foreach (FieldMovement unit in units)
        {
            if (unit != null && !unit.isDead && unit.HasPerformedAction())
            {
                return true;
            }
        }
        return false;
    }

    private float EnemyReturnHP(int index, Unit unit)
    {
        int count = enemyUnits.unitCount[index];
        return unit.health * count;
    }
    private float PlayerReturnHP(int index, Unit unit)
    {
        int count = enemyUnits.unitCount[index];
        return unit.health * count;
    }
}
