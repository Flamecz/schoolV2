using UnityEngine;
using UnityEngine.UI;

public class UiUpdate : MonoBehaviour
{
    public GameObject canvas;
    private Text Resource1, Resource2, Resource3, Resource4, Resource5, Resource6, Resource7;
    public ResourceManager RM;
    private void Start()
    {
        GetData();
    }
    void Update()
    {
        Resource1.text = RM.Data.Wood.ToString();
        Resource2.text = RM.Data.Iron.ToString();
        Resource3.text = RM.Data.Stone.ToString();
        Resource4.text = RM.Data.Sulfur.ToString();
        Resource5.text = RM.Data.Minerals.ToString();
        Resource6.text = RM.Data.Gems.ToString();
        Resource7.text = RM.Data.Gold.ToString();
    }
    private void GetData()
    {
        Resource1 = canvas.transform.Find("Res1").GetComponent<Text>();
        Resource2 = canvas.transform.Find("Res2").GetComponent<Text>();
        Resource3 = canvas.transform.Find("Res3").GetComponent<Text>();
        Resource4 = canvas.transform.Find("Res4").GetComponent<Text>();
        Resource5 = canvas.transform.Find("Res5").GetComponent<Text>();
        Resource6 = canvas.transform.Find("Res6").GetComponent<Text>();
        Resource7 = canvas.transform.Find("Res7").GetComponent<Text>();
    }
}
