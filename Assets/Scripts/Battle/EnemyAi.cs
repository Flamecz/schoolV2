using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public BattleManager battleManager;
    public float movementDelay = 1.0f; // Èasové zpoždìní mezi pohyby jednotek

    private void Awake()
    {
        battleManager = FindObjectOfType<BattleManager>();
    }

    public void ExecuteAITurn()
    {
        MoveTowardsPlayerUnits();
        AttackPlayerUnitsIfInRange();
        battleManager.EndTurn();
    }

    private IEnumerator MoveUnitsWithDelay()
    {
        foreach (FieldMovement enemyUnit in battleManager.enemyCharacters)
        {
            if (enemyUnit != null && !enemyUnit.isDead)
            {
                // Poèkej na èasové zpoždìní pøed každým pohybem jednotky
                yield return new WaitForSeconds(movementDelay);

                // Získej cílovou jednotku pro pohyb
                FieldMovement closestPlayerUnit = FindClosestPlayerUnit(enemyUnit.transform.position);
                if (closestPlayerUnit != null)
                {
                    // Nastav cíl pohybu a proveï pohyb
                    enemyUnit.SetTargetPosition(closestPlayerUnit.transform.position);
                }
            }
        }

        // Po dokonèení pohybù jednotek ukonèi tah
        battleManager.EndTurn();
    }
    private void AttackPlayerUnitsIfInRange()
    {
        foreach (FieldMovement enemyUnit in battleManager.enemyCharacters)
        {
            if (enemyUnit != null && !enemyUnit.isDead)
            {
                // Kontrola, zda jsou hráèovy jednotky v dosahu útoku
                bool playerUnitsInRange = ArePlayerUnitsInRange(enemyUnit);

                if (playerUnitsInRange)
                {
                    // Pokud jsou hráèovy jednotky v dosahu útoku, útoèí na nì
                    AttackPlayer(GetClosestPlayerUnit(enemyUnit.transform.position));
                }
                else
                {
                    // Pokud nejsou hráèovy jednotky v dosahu útoku, hledá nejbližšího hráèova jednotku a pohybuje se k ní
                    MoveTowardsClosestPlayerUnit(enemyUnit);
                }
            }
        }
    }
    private bool ArePlayerUnitsInRange(FieldMovement enemyUnit)
    {
        foreach (FieldMovement playerUnit in battleManager.playerCharacters)
        {
            if (playerUnit != null && !playerUnit.isDead)
            {
                // Získání vzdálenosti mezi nepøátelskou jednotkou a hráèovou jednotkou
                float distance = Vector3.Distance(enemyUnit.transform.position, playerUnit.transform.position);

                // Zde mùžete zadefinovat dosah útoku pro vaše pravidla hry
                float attackRange = 17;

                // Pokud je hráèova jednotka v dosahu útoku, vrátíme true
                if (distance <= attackRange)
                {
                    return true;
                }
            }
        }
        // Pokud žádná hráèova jednotka není v dosahu útoku, vrátíme false
        return false;
    }
    private void MoveTowardsClosestPlayerUnit(FieldMovement enemyUnit)
    {
        FieldMovement closestPlayerUnit = GetClosestPlayerUnit(enemyUnit.transform.position);
        if (closestPlayerUnit != null)
        {
            enemyUnit.SetTargetPosition(closestPlayerUnit.transform.position);
        }
    }
    private FieldMovement GetClosestPlayerUnit(Vector3 position)
    {
        FieldMovement closestUnit = null;
        float closestDistance = Mathf.Infinity;

        foreach (FieldMovement playerUnit in battleManager.playerCharacters)
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
        FieldMovement targetPlayerUnit = GetClosestPlayerUnit(enemyUnit.transform.position);


        if (targetPlayerUnit != null)
        {
            int damage = CalculateDamage(enemyUnit.unit, targetPlayerUnit.unit);

            targetPlayerUnit.health -= damage;

            if (targetPlayerUnit.health <= 0)
            {
                Destroy(targetPlayerUnit.gameObject);
            }
        }
    }

    private int CalculateDamage(Unit attacker, Unit target)
    {
        // Výpoèet poškození na základì síly útoèící jednotky a obrany cílové jednotky
        int damage = Random.Range(attacker.minDamage, attacker.maxDamage);

        // Zajištìní, že poškození bude alespoò 1
        damage = Mathf.Max(damage, 1);

        return damage;
    }


    private void MoveTowardsPlayerUnits()
    {
        foreach (FieldMovement enemyUnit in battleManager.enemyCharacters)
        {
            if (enemyUnit != null && !enemyUnit.isDead)
            {
                FieldMovement closestPlayerUnit = FindClosestPlayerUnit(enemyUnit.transform.position);
                if (closestPlayerUnit != null)
                {
                    // Získání cesty od pozice nepøátelské jednotky k pozici hráèovy jednotky
                    List<Vector3> path = battleManager.moveControl.pathfinding.FindPath(enemyUnit.transform.position, closestPlayerUnit.transform.position);

                    // Pokud existuje cesta, nastavíme cílovou pozici na první bod cesty
                    if (path != null && path.Count > 1)
                    {
                        enemyUnit.SetTargetPosition(path[1]); // Index 0 je pozice jednotky samotné
                    }
                }
            }
        }
    }
    private FieldMovement FindClosestPlayerUnit(Vector3 position)
    {
        FieldMovement closestUnit = null;
        float closestDistance = Mathf.Infinity;

        foreach (FieldMovement playerUnit in battleManager.playerCharacters)
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
}
