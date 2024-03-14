using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // Array to store map layouts
    public string[][] mapLayouts;

    // Singleton instance
    public static MapManager Instance { get; private set; }

    private void Awake()
    {
        // Ensure there is only one instance of MapManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Another instance of MapManager already exists. Destroying this one.");
            Destroy(gameObject);
        }

        // Initialize map layouts
        InitializeMapLayouts();
    }

    // Method to initialize map layouts
    private void InitializeMapLayouts()
    {
        mapLayouts = new string[5][];

        // Example map layouts
        mapLayouts[0] = new string[]
        {
            "....................",
            ".....XX...XXXXX.....",
            "....X..X..X....X....",
            "...X...X...X...X....",
            "..X....X....X....X..",
            "..X..............X..",
            "...X............X...",
            "....X..........X....",
            ".....X........X.....",
            "...................."
        };

        mapLayouts[1] = new string[]
        {
            "....................",
            ".......XXXXX........",
            "......X......X......",
            "......X......X......",
            "......X......X......",
            "......X......X......",
            "......X......X......",
            "......X......X......",
            ".......XXXXX........",
            "...................."
        };

        // Add more maps as needed
        // mapLayouts[2] = new string[] {...};

        // You can create more maps similarly
    }

    // Method to get a map layout by index
    public string[] GetMapLayout(int index)
    {
        if (index >= 0 && index < mapLayouts.Length)
        {
            return mapLayouts[index];
        }
        else
        {
            Debug.LogError("Invalid map index: " + index);
            return null;
        }
    }
}
