using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameElementPlacer : MonoBehaviour
{
    public GameObject gameElementPrefab;
    public Grid grid;
    public PlayerData playerData;

    void Start()
    {
        if (playerData != null)
        {
            GameObject gameElement = Instantiate(gameElementPrefab);
            gameElement.transform.position = playerData.position;
            gameElement.transform.rotation = playerData.rotation;
            gameElement.transform.parent = grid.transform;

            GameElement gameElementScript = gameElement.GetComponent<GameElement>();
            gameElementScript.grid = grid;
        }
    }
}



