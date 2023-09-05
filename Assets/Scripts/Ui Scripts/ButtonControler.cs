using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonControler : MonoBehaviour
{
    public GameObject Selector;
    public GameObject PrefabTechTree;

    private Button Starter;
    private Vector3 originalPosition;
    private float size;
    private static bool opened;
    void Start()
    {
        Transform button1 = Selector.transform.Find("starter");

        if (button1 != null)
        {
            Starter = button1.GetComponent<Button>();
            Starter.onClick.AddListener(ToggleTree);
        }
        originalPosition = Starter.GetComponent<RectTransform>().anchoredPosition3D;
    }

    private void ToggleTree()
    {
        opened = !opened;

        if (opened)
        {
            size = 30;
            
            Vector3 targetPosition = new Vector3(originalPosition.x + 60f, originalPosition.y, originalPosition.z);
            Starter.GetComponent<RectTransform>().anchoredPosition3D = targetPosition;
            PrefabTechTree.SetActive(true);
            GameObject.Find("starter").GetComponentInChildren<Text>().text = "Exit";

        }
        else
        {
            size = 160;
            Starter.GetComponent<RectTransform>().anchoredPosition3D = originalPosition;
            PrefabTechTree.SetActive(false);
            GameObject.Find("starter").GetComponentInChildren<Text>().text = "Tech Tree";
        }

        ChangeWidth(size);
    }

    private void ChangeWidth(float width)
    {
        RectTransform buttonRectTransform = Starter.GetComponent<RectTransform>();

        Vector2 newsize = buttonRectTransform.sizeDelta;
        newsize.x = width;
        buttonRectTransform.sizeDelta = newsize;
    }
}
