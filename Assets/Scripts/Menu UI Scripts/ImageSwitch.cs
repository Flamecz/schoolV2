using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwitch : MonoBehaviour
{
    public Image image;
    public Sprite[] sprites;
    private int selectedIndex = 2;
    private int defaultIndex = 2;
    public Button leftButton;
    public Button rightButton;
    private float DifModifier;

    void Start()
    {
        ChangeImage(selectedIndex);
        leftButton.onClick.AddListener(() => {
            if (selectedIndex > 0)
            {
                selectedIndex--;
                ChangeImage(selectedIndex);
            }
        });
        rightButton.onClick.AddListener(() => {
            if (selectedIndex < sprites.Length - 1)
            {
                selectedIndex++;
                ChangeImage(selectedIndex);
            }
        });
    }
    public void RestartDif()
    {
        selectedIndex = defaultIndex;
        ChangeImage(selectedIndex);
    }    

    public void ChangeImage(int index)
    {
        if (index >= 0 && index < sprites.Length)
        {
            image.sprite = sprites[index];
        }
        dificultyRating();
    }
    public void dificultyRating()
    {
        switch(selectedIndex)
        {
            case 0:
                DifModifier = 0.8f;
                break;
            case 1:
                DifModifier = 1f;
                break;
            case 2:
                DifModifier = 1.3f;
                break;
            case 3:
                DifModifier = 1.6f;
                break;
            case 4:
                DifModifier = 2f;
                break;
        }
    }
}
