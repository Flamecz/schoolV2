using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddHero : MonoBehaviour
{
    public SavePlayerImages SPI;
    private bool done;
    private void Update()
    {
        if(!done)
        {
            gameObject.GetComponent<Image>().sprite = SPI.player;
        }
    }
}
