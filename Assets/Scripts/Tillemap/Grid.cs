using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.Tilemaps;


public class Grid
{
    private int height;
    private int width;
    private int[,] gridArray;
    private float cellSize;

    public Grid(int height, int width, float cellSize)
    {
        this.height = height;
        this.width = width;
        this.cellSize = cellSize;

        gridArray = new int [width,height];

        for (int x = 0; x < gridArray.GetLength(0); x++) {
        for (int y = 0;y<gridArray.GetLength(1);y++)
            {
                Debug.Log(x + " " + y);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x,y + 1),Color.white, 100F);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y),Color.white, 100F);
            }
            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width ,height), Color.white, 100F);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width,height), Color.white, 100F);
        }   
    }
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

}


