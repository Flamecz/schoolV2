using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class placeNameAndSprite : MonoBehaviour
{
    public SavePlayerImages SPI;
    public Text playerName,enemyName;
    public Image playerImage, enemyImage;
    private bool done;
    void Update()
    {
        if (!done)
        {
            playerName.text = SPI.playerName;
            enemyName.text = SPI.enemyName;
            playerImage.sprite = SPI.player;
            enemyImage.sprite = SPI.enemy;
        }
    }
}

