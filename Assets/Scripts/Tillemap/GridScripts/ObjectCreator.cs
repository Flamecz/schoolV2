using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    public GameObject playerPrefab; // Prefab for the player object
    public GameObject obstaclePrefab; // Prefab for the obstacle object
    public Transform gridParent; // Parent object for grid cells
    public GameObject[] tilePrefabs; // Prefabs for each tile type
    public float cellSize = 1f; // Size of each grid cell

    private void Start()
    {
        // Get a map layout from the MapManager
        string[] map = MapManager.Instance.GetMapLayout(0); // Example: Getting the first map layout
        if (map != null)
        {
            // Use the map layout to place objects on the grid
            PlaceObjectsOnGrid(map);
        }
        else
        {
            Debug.LogError("Failed to get map layout from MapManager.");
        }
    }

    private void PlaceObjectsOnGrid(string[] map)
    {
        // Loop through the map array
        for (int y = 0; y < map.Length; y++)
        {
            for (int x = 0; x < map[y].Length; x++)
            {
                Vector3 cellPosition = new Vector3(x * cellSize, 0f, y * cellSize);

                // Get the corresponding tile prefab for the map tile
                GameObject tilePrefab = GetTilePrefab(map[y][x]);

                if (tilePrefab != null)
                {
                    // Instantiate the tile prefab at the cell position
                    Instantiate(tilePrefab, cellPosition, Quaternion.identity, gridParent);
                }
                else
                {
                    Debug.LogWarning("No tile prefab found for tile: " + map[y][x]);
                }
            }
        }
    }

    private GameObject GetTilePrefab(char tileType)
    {
        switch (tileType)
        {
            case 'X': // Obstacle
                return obstaclePrefab;
            case 'P': // Player
                return playerPrefab;
            default: // Empty space
                return null;
        }
    }
}
