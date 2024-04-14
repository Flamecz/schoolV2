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

        // Nastav cíl vybrané jednotce
        selectedUnit.SetAttackPosition(targetPosition);
    }
    private FieldMovement SelectUnit()
    {
        // Získání pole všech nepøátelských jednotek
        FieldMovement[] enemyUnits = FindObjectsOfType<FieldMovement>();

        // Náhodný výbìr jednotky
        int randomIndex = Random.Range(0, enemyUnits.Length);
        return enemyUnits[randomIndex];
    }

    private Vector3 SelectTargetPosition()
    {
        // Získání náhodné pozice na mapì
        Vector3 targetPosition = GetRandomPositionOnMap();
        return targetPosition;
    }

    private Vector3 GetRandomPositionOnMap()
    {
        // Nahrazení této metody implementací podle vašich pravidel pro umístìní cíle na mapì
        // Zde by mìla být logika pro náhodný výbìr pozice na mapì
        Vector3 randomPosition = Vector3.zero; // Nahraïte náhodnou pozicí
        return randomPosition;
    }
}
