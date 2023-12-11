using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openFortressBuilding : MonoBehaviour
{

    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(Activate);
    }
    void Activate()
    {
        FindObjectOfType<MainCanvasControler>().OpenFortressView();
    }
}
