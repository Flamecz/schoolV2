using UnityEngine;
using UnityEngine.UI;

public class SliderUpdate : MonoBehaviour
{
    public GameObject Empty;
    public ResourceManager RM;
    private Slider slider;
    private Button Left, Right;
    private int WoodCost,StoneCost,IronCost,SulfurCost,MineralsCost,GemsCost,GoldCost;
    void Start()
    {
        slider = gameObject.transform.Find("Slider").GetComponent<Slider>();
        Left = gameObject.transform.Find("LeftButton").GetComponent<Button>();
        Right = gameObject.transform.Find("RightButton").GetComponent<Button>();


        Left.onClick.AddListener(delegate { slider.value -= 1; });
        Right.onClick.AddListener(delegate { slider.value += 1; });
    }
    private void Update()
    {

    }
    public void Importer(int Wood, int Stone, int Iron, int Sulfur, int Minerals, int Gems, int Gold)
    {
        WoodCost = Wood;
        StoneCost = Stone;
        IronCost = Iron;
        SulfurCost = Sulfur;
        MineralsCost = Minerals;
        GemsCost = Gems;
        GoldCost = Gold;
    }
    private void BuyableAmount()
    {
 
    }
}

