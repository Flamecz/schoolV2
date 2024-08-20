using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadImage : MonoBehaviour
{
    public SavePlayerImages save;
    private bool done;
    private void Update()
    {
       if(!done)
        {
            gameObject.GetComponent<Image>().sprite = save.player;
            done = true;
        }
    }

}
