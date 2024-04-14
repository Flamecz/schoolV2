using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public void ExecuteAITurn()
    {
        // Vyber bod A
        FieldMovement selectedUnit = SelectUnit();

        // Vyber bod B
        Vector3 targetPosition = SelectTargetPosition();

        // Nastav c�l vybran� jednotce
        selectedUnit.SetAttackPosition(targetPosition);
    }
    private FieldMovement SelectUnit()
    {
        // Z�sk�n� pole v�ech nep��telsk�ch jednotek
        FieldMovement[] enemyUnits = FindObjectsOfType<FieldMovement>();

        // N�hodn� v�b�r jednotky
        int randomIndex = Random.Range(0, enemyUnits.Length);
        return enemyUnits[randomIndex];
    }

    private Vector3 SelectTargetPosition()
    {
        // Z�sk�n� n�hodn� pozice na map�
        Vector3 targetPosition = GetRandomPositionOnMap();
        return targetPosition;
    }

    private Vector3 GetRandomPositionOnMap()
    {
        // Nahrazen� t�to metody implementac� podle va�ich pravidel pro um�st�n� c�le na map�
        // Zde by m�la b�t logika pro n�hodn� v�b�r pozice na map�
        Vector3 randomPosition = Vector3.zero; // Nahra�te n�hodnou pozic�
        return randomPosition;
    }
}
