using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetImages : MonoBehaviour
{
    public Image image;
    public Text text;
    public SavePlayerImages savePlayerImages;
    private bool done;

    private void Update()
    {
        if(!done)
        {
            image.sprite = savePlayerImages.cityPicture;
            text.text = savePlayerImages.cityName;
            done = true;
        }
    }

}
    