using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GridObject[] gridObjects;
    public int[] spawnObjectIds;
    public Vector2Int[] spawnTilePositions;
    public Grid grid; // Reference to your grid script

    void Start()
    {
        if (grid == null)
        {
            Debug.LogError("Grid reference not set in ObjectSpawner!");
            return;
        }

        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < spawnObjectIds.Length; i++)
        {
            int objectId = spawnObjectIds[i];
            Vector2Int tilePosition = spawnTilePositions[i];

            GridObject gridObject = System.Array.Find(gridObjects, obj => obj.id == objectId);

            if (gridObject != null)
            {
                SpawnObjectOnTile(gridObject.prefab, tilePosition);
            }
            else
            {
                Debug.LogError("Object with ID " + objectId + " not found!");
            }
        }
    }

    void SpawnObjectOnTile(GameObject prefab, Vector2Int tilePosition)
    {
        Vector3 worldPosition = grid.CellToWorld(new Vector3Int(tilePosition.x, tilePosition.y, 0));
        GameObject spawnedObject = Instantiate(prefab, worldPosition, Quaternion.identity);
        // Optionally, you can parent the spawned object to another GameObject
        spawnedObject.transform.parent = grid.transform;
    }
}
