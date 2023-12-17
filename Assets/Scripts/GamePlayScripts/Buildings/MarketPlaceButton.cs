using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketPlaceButton : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(Activate);
    }
    void Activate()
    {
        FindObjectOfType<MainCanvasControler>().OpenMarketPlace();
    }

}
