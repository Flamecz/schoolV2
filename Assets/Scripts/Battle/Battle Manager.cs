using System;
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
    int futureturn;
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
        FindObjectOfType<SpellCall>().Enemys = new FieldMovement[change1];
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
    public void CreateNewAliedUnit(Unit unit)
    {
        int currentLenght = playerCharacters.Length;
        if (currentLenght < 7)
        {
            FieldMovement[] copy = new FieldMovement[currentLenght];
            Array.Copy(playerCharacters, copy, currentLenght); // Copy elements from the original array
            playerCharacters = new FieldMovement[currentLenght + 1]; // Increase the size
            Array.Copy(copy, playerCharacters, currentLenght);
        }
        GameObject go = Instantiate(unitPefab, aliedPosition[currentLenght].transform.position, aliedPosition[currentLenght].transform.rotation, aliedUnitsParent);
        playerCharacters[currentLenght] = go.GetComponent<FieldMovement>();
        playerCharacters[currentLenght].unit = unit;
        playerCharacters[currentLenght].health = PlayerReturnHP(currentLenght, unit);
        playerCharacters[currentLenght].count = playerUnits.unitCount[currentLenght];

        if (playerCharacters[currentLenght].unit.ATKT == Unit.attackType.ranger)
        {
            playerCharacters[currentLenght].shots = unit.Shots;
        }
    }
    public void CreateEnemyUnit(int i, Unit unit)
    {
        GameObject go = Instantiate(unitPefab, enemyPosition[i].transform.position, enemyPosition[i].transform.rotation, enemyUnitsParent);
        enemyCharacters[i] = go.GetComponent<FieldMovement>();
        FindObjectOfType<SpellCall>().Enemys[i] = go.GetComponent<FieldMovement>();
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

        foreach (FieldMovement fm in playerCharacters)
        {
            if (fm != null)
            { 
                fm.enabled = false;
                fm.transform.Find("BackGround").GetComponent<MeshRenderer>().enabled = false;
            }
            
        }

        // Start the turn with the current value of currentTurn
        if (currentTurn < playerCharacters.Length && playerCharacters[currentTurn] != null && !playerCharacters[currentTurn].isDead)
        {
            playerCharacters[currentTurn].enabled = true;
            playerCharacters[currentTurn].transform.Find("BackGround").GetComponent<MeshRenderer>().enabled = true;
            moveControl.unitPathfinding = playerCharacters[currentTurn];
            Debug.Log("Current unit: " + playerCharacters[currentTurn].unit + ", Speed: " + playerCharacters[currentTurn].unit.speed);    
            moveControl.set = playerCharacters[currentTurn].unit.speed * 10;
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

        if (currentTurn < playerCharacters.Length)
        {
            StartTurn();
        }
        else
        {
            StartCoroutine(ExecuteEnemyTurn());
        }
    }
    public void EndCycle()
    {
        futureturn = 0;
        currentTurn = 0;
    }
    private IEnumerator ExecuteEnemyTurn()
    {
        Debug.Log("fired");
        foreach (FieldMovement fm in playerCharacters)
        {
            if (fm != null)
            {
                fm.transform.Find("BackGround").GetComponent<MeshRenderer>().enabled = false;
            }
        }

        for (int i = 0; i < enemyCharacters.Length; i++)
        {

            enemyCharacters[i].enabled = true;
            enemyCharacters[i].enemyHasTurn = true;
            enemyCharacters[i].transform.Find("BackGround").GetComponent<MeshRenderer>().enabled = true;
            Destroy(enemyCharacters[i].gameObject.GetComponent<BoxCollider>());
            FieldMovement closestPlayerUnit = FindClosestPlayerUnit(enemyCharacters[i].transform.position);
            float distanceBefore = Vector3.Distance(enemyCharacters[i].transform.position, closestPlayerUnit.transform.position);
            Debug.Log(distanceBefore);
            // Move towards the player unit if not already within attack range
            if (distanceBefore > 60f)
            {
                Vector3 startPosition = enemyCharacters[i].transform.position;
                Vector3 targetPosition = startPosition + new Vector3(-30f, 0f, 0f); // Move 30 units to the left

                float journeyLength = Vector3.Distance(startPosition, targetPosition);
                float startTime = Time.time;

                while (true)
                {
                    float distanceCovered = (Time.time - startTime) * 40; // Assuming moveSpeed is defined
                    float journeyFraction = distanceCovered / journeyLength;
                    enemyCharacters[i].transform.position = Vector3.Lerp(startPosition, targetPosition, journeyFraction);

                    if (journeyFraction >= 1f)
                        break;

                    yield return null;
                }
            }
            else if( distanceBefore >= 17 && distanceBefore <= 60f)
            {
                enemyCharacters[i].SetAttackPosition(closestPlayerUnit.transform.position);
                enemyCharacters[i].OnEnemy = true;
            }
            else if (distanceBefore <= 17f)
            {
                // Attack the player unit
                AttackPlayer(enemyCharacters[i]);
                FindObjectOfType<AudioManager>().Play("Hit");

            }
            // Check if the enemy unit is within attack range

            yield return new WaitForSeconds(1f); // Wait for 1 second between each enemy's action
            enemyCharacters[i].enabled = false;
            enemyCharacters[i].gameObject.AddComponent<BoxCollider>();
            enemyCharacters[i].transform.Find("BackGround").GetComponent<MeshRenderer>().enabled = false;
        }

        EndCycle();
        StartTurn();
    }

    private FieldMovement FindClosestPlayerUnit(Vector3 position)
    {
        FieldMovement closestUnit = null;
        float closestDistance = Mathf.Infinity;

        foreach (FieldMovement playerUnit in playerCharacters)
        {
            if (playerUnit != null && !playerUnit.isDead)
            {
                float distance = Vector3.Distance(position, playerUnit.transform.position);
                if (distance < closestDistance)
                {
                    closestUnit = playerUnit;
                    closestDistance = distance;
                }
            }
        }

        return closestUnit;
    }
    private void AttackPlayer(FieldMovement enemyUnit)
    {
        // Získání hráèovy jednotky, na kterou bude nepøátelská jednotka útoèit
        FieldMovement targetPlayerUnit = FindClosestPlayerUnit(enemyUnit.transform.position);

        // Pokud existuje hráèova jednotka k útoku
        if (targetPlayerUnit != null)
        {
            // Vypoèítání poškození
            int damage = CalculateDamage(enemyUnit.unit, enemyUnit.count);

            targetPlayerUnit.health -= damage;

            if (targetPlayerUnit.health <= 0)
            {
                Destroy(targetPlayerUnit.gameObject);
            }
        }
    }

    private int CalculateDamage(Unit attacker, int count)
    {
        // Výpoèet poškození na základì síly útoèící jednotky a obrany cílové jednotky
        int damage = UnityEngine.Random.Range(attacker.minDamage, attacker.maxDamage);

        // Zajištìní, že poškození bude alespoò 1
        damage = damage * count;

        return damage;
    }
    private void MoveTowardsClosestPlayerUnit(FieldMovement enemyUnit)
    {
        FieldMovement closestPlayerUnit = FindClosestPlayerUnit(enemyUnit.transform.position);
        if (closestPlayerUnit != null)
        {
            float distanceToPlayer = Vector3.Distance(enemyUnit.transform.position, closestPlayerUnit.transform.position);
            if (distanceToPlayer <= 17f)
            {
                // If the enemy unit is within 17 units from the player unit, attack and stop moving
                AttackPlayer(enemyUnit);
                return; // Stop moving
            }
            else
            {
                // Move towards the player unit
                enemyUnit.SetTargetPosition(closestPlayerUnit.transform.position);
            }
        }
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
