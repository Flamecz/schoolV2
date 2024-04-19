using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMovement : MonoBehaviour
{
    public bool isDead = false;
    public bool isEnemy;
    public Unit unit;
    public float health;
    public int count;
    private float speed = 40f;

    public bool enemyHasTurn;
    public int shots;
    public bool OnEnemy;
    private int currentPathIndex;
    private List<Vector3> pathVectorList;

    private bool canAttack = true;
    private float attackCooldown = 1f; // Adjust the cooldown duration as needed
    private float lastAttackTime = 0f;
    private void Update()
    {
        HandleMovement();

        if (Input.GetMouseButtonDown(0) && !enemyHasTurn )
        {
                SetAttackPosition(GetMouseWorldPosition());
        }
    }

    private void HandleMovement()
    {
        if (pathVectorList != null &&  !OnEnemy)
        {
            Vector3 targetPosition = pathVectorList[currentPathIndex];
            if (Vector3.Distance(transform.position, targetPosition) > 1f)
            {
                Vector3 moveDir = (targetPosition - transform.position).normalized;

                float distanceBefore = Vector3.Distance(transform.position, targetPosition);
                transform.position = transform.position + moveDir * speed * Time.deltaTime;
            }
            else
            {
                currentPathIndex++;
                if (currentPathIndex >= pathVectorList.Count)
                {
                    StopMoving();
                    EndPlayerTurn();
                }
            }
        }
        else if (pathVectorList != null && OnEnemy)
        {
            Vector3 targetPosition = pathVectorList[currentPathIndex];
            if (Vector3.Distance(transform.position, targetPosition) > 1f)
            {
                Vector3 moveDir = (targetPosition - transform.position).normalized;

                float distanceBefore = Vector3.Distance(transform.position, targetPosition);
                transform.position = transform.position + moveDir * speed * Time.deltaTime;
            }
            else
            {
                currentPathIndex++;
                if (currentPathIndex >= pathVectorList.Count - 1)
                {
                    StopMoving();

                }
            }
        }
    }
    private void EndPlayerTurn()
    {
        // Trigger the EndTurn method of the BattleManager script
        FindObjectOfType<BattleManager>().EndTurn();
    }
    private void StopMoving()
    {
        pathVectorList = null;
        canAttack = true;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        currentPathIndex = 0;
        pathVectorList = PathFinding.Instance.FindPath(GetPosition(), targetPosition);

        if (pathVectorList != null && pathVectorList.Count > 1)
        {
            pathVectorList.RemoveAt(0);
        }
    }
    public void SetAttackPosition(Vector3 targetPosition)
    {
        canAttack = false;
        currentPathIndex = 0;
        pathVectorList = null;

        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

        FieldMovement enemyUnit = FindEnemyUnitAtPosition(targetPosition);
        if (enemyUnit != null)
        {
            Debug.Log("Enemy unit found: " + enemyUnit);

            if (unit.ATKT == Unit.attackType.ranger && shots > 0)
            {
                float minDamage = unit.minDamage;
                float maxDamage = unit.maxDamage;
                enemyUnit.ReceiveDamage(minDamage, maxDamage);
                shots--;
                Debug.Log("Dealt " + unit.damage + " ranged damage to the enemy unit!");
                ResetAttackCooldown();
                EndPlayerTurn();
            }
            else if (unit.ATKT == Unit.attackType.ranger && shots <= 0 && distanceToTarget < 17)
            {
                float minDamage = unit.minDamage;
                float maxDamage = unit.maxDamage;
                enemyUnit.ReceiveDamage(minDamage, maxDamage);
                Debug.Log("Dealt " + unit.damage + " melee damage due to no ammunition!");
                ResetAttackCooldown();
                EndPlayerTurn();
            }
            else if (unit.ATKT == Unit.attackType.melee && distanceToTarget < 17)
            {
                float minDamage = unit.minDamage;
                float maxDamage = unit.maxDamage;
                enemyUnit.ReceiveDamage(minDamage, maxDamage);
                Debug.Log("Dealt " + unit.damage + " melee damage to the enemy unit!");
                ResetAttackCooldown();
                EndPlayerTurn();
            }
            StartCoroutine(ResetAttackCooldown());
        }
        else
        {
            SetTargetPosition(targetPosition);
        }

        // End the player's turn after attacking
    }
    private IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
    private FieldMovement FindEnemyUnitAtPosition(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 0.5f); // Adjust the radius as needed
        Debug.Log("what");
        foreach (Collider collider in colliders)
        {
            FieldMovement enemyUnit = collider.GetComponent<FieldMovement>();
            if (enemyUnit != null && enemyUnit.isEnemy && enemyUnit.unit != null && enemyUnit.unit != unit && enemyUnit.unit.stackable)
            {
                return enemyUnit;
            }
        }
        return null;
    }

    public void ReceiveDamage(float minDamage, float maxDamage)
    {
        float damage = Random.Range(minDamage, maxDamage + 1);
        health -= damage * count;
        howManyAlive();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        // Additional logic when the unit dies, e.g., play death animation, remove from the battle, etc.
        Destroy(gameObject); // Deactivate the game object
    }
    public void howManyAlive()
    {
        count = Mathf.RoundToInt(health / unit.health);
        if (health % unit.health > 1)
        {
            count++;
        }

    }
    public bool HasPerformedAction()
    {
        // Kontrola, zda hráè provedl nìjakou akci
        return pathVectorList != null || Time.time - lastAttackTime < attackCooldown || Input.GetKeyDown(KeyCode.E);
    }
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
