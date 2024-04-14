using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public BattleManager battleManager;
    public float movementDelay = 1.0f; // �asov� zpo�d�n� mezi pohyby jednotek

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
                // Po�kej na �asov� zpo�d�n� p�ed ka�d�m pohybem jednotky
                yield return new WaitForSeconds(movementDelay);

                // Z�skej c�lovou jednotku pro pohyb
                FieldMovement closestPlayerUnit = FindClosestPlayerUnit(enemyUnit.transform.position);
                if (closestPlayerUnit != null)
                {
                    // Nastav c�l pohybu a prove� pohyb
                    enemyUnit.SetTargetPosition(closestPlayerUnit.transform.position);
                }
            }
        }

        // Po dokon�en� pohyb� jednotek ukon�i tah
        battleManager.EndTurn();
    }
    private void AttackPlayerUnitsIfInRange()
    {
        foreach (FieldMovement enemyUnit in battleManager.enemyCharacters)
        {
            if (enemyUnit != null && !enemyUnit.isDead)
            {
                // Kontrola, zda jsou hr��ovy jednotky v dosahu �toku
                bool playerUnitsInRange = ArePlayerUnitsInRange(enemyUnit);

                if (playerUnitsInRange)
                {
                    // Pokud jsou hr��ovy jednotky v dosahu �toku, �to�� na n�
                    AttackPlayer(GetClosestPlayerUnit(enemyUnit.transform.position));
                }
                else
                {
                    // Pokud nejsou hr��ovy jednotky v dosahu �toku, hled� nejbli���ho hr��ova jednotku a pohybuje se k n�
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
                // Z�sk�n� vzd�lenosti mezi nep��telskou jednotkou a hr��ovou jednotkou
                float distance = Vector3.Distance(enemyUnit.transform.position, playerUnit.transform.position);

                // Zde m��ete zadefinovat dosah �toku pro va�e pravidla hry
                float attackRange = 17;

                // Pokud je hr��ova jednotka v dosahu �toku, vr�t�me true
                if (distance <= attackRange)
                {
                    return true;
                }
            }
        }
        // Pokud ��dn� hr��ova jednotka nen� v dosahu �toku, vr�t�me false
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
        // V�po�et po�kozen� na z�klad� s�ly �to��c� jednotky a obrany c�lov� jednotky
        int damage = Random.Range(attacker.minDamage, attacker.maxDamage);

        // Zaji�t�n�, �e po�kozen� bude alespo� 1
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
                    // Z�sk�n� cesty od pozice nep��telsk� jednotky k pozici hr��ovy jednotky
                    List<Vector3> path = battleManager.moveControl.pathfinding.FindPath(enemyUnit.transform.position, closestPlayerUnit.transform.position);

                    // Pokud existuje cesta, nastav�me c�lovou pozici na prvn� bod cesty
                    if (path != null && path.Count > 1)
                    {
                        enemyUnit.SetTargetPosition(path[1]); // Index 0 je pozice jednotky samotn�
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
