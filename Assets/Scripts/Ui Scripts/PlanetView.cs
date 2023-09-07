using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetView : MonoBehaviour
{
    public GameObject Selector;

    private Sprite Sprite;

    private Button PlanetButton;
    private static bool open;
    private void Start()
    {
        Transform PlanetSelector = Selector.transform.Find("worldView");
        if(PlanetSelector != null)
        {
            PlanetButton = PlanetSelector.GetComponent<Button>();
            PlanetButton.onClick.AddListener(ToggleTree);
            
        }
    }
    private void ToggleTree()
    {
        open = !open;

        if (open)
        {
            Sprite = Resources.Load<Sprite>("Sprites/home");
            PlanetButton.image.sprite = Sprite;
        }
        else
        {
            Sprite = Resources.Load<Sprite>("Sprites/earth");
            PlanetButton.image.sprite = Sprite;
        }


    }
}
