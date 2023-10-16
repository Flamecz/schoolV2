using UnityEngine;
using UnityEngine.UI;

public class UiUpdate : MonoBehaviour
{
    public Text Resource1, Resource2, Resource3, Resource4;
    public ResourceManager RM;
    void Update()
    {
        Resource1.text = "Wood " + RM.Wood.ToString();
        Resource2.text = "Stone " + RM.Stone.ToString();
        Resource3.text = "Minerals " + RM.Minerals.ToString();
        Resource4.text = "Iron " + RM.Iron.ToString();
    }
}
