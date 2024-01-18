using UnityEngine;
using UnityEngine.UI;

public class SliderUpdate : MonoBehaviour
{
    public GameObject Empty;
    public ResourceManager RM;
    private Slider slider;
    private Button Left, Right;
    private int WoodCost, IronCost, StoneCost, SulfurCost, MineralsCost, GemsCost, GoldCost;
    private int index1, index2;
    
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
        BuyableAmount();
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
    public void SetIndex1(int Inx1)
    {
        if(Inx1 != null)
        {
            index1 = Inx1;
        }
    }
    public void SetIndex2(int Inx2)
    {
        if (Inx2 != null)
        {
            index2 = Inx2;
        }
    }

    private void BuyableAmount()
    {
        switch(index1)
        {
            case 0:
                switch(index2)
                {
                    case 0:
                        slider.maxValue = 0;
                        return;
                    case 1:
                        slider.maxValue = RM.Wood / IronCost;
                        return;
                    case 2:
                        slider.maxValue = RM.Wood / StoneCost;
                        return;
                    case 3:
                        slider.maxValue = RM.Wood / SulfurCost;
                        return;
                    case 4:
                        slider.maxValue = RM.Wood / MineralsCost;
                        return;
                    case 5:
                        slider.maxValue = RM.Wood / GemsCost;
                        return;
                    case 6:
                        slider.maxValue = RM.Wood / GoldCost;
                        return;
                }
                return;
            case 1:
                switch (index2)
                {
                    case 0:
                        slider.maxValue = RM.Iron / WoodCost;
                        return;
                    case 1:
                        slider.maxValue = 0;
                        return;
                    case 2:
                        slider.maxValue = RM.Iron / StoneCost;
                        return;
                    case 3:
                        slider.maxValue = RM.Iron / SulfurCost;
                        return;
                    case 4:
                        slider.maxValue = RM.Iron / MineralsCost;
                        return;
                    case 5:
                        slider.maxValue = RM.Iron / GemsCost;
                        return;
                    case 6:
                        slider.maxValue = RM.Iron / GoldCost;
                        return;
                }
                return;
            case 2:
                switch (index2)
                {
                    case 0:
                        slider.maxValue = RM.Stone / WoodCost;
                        return;
                    case 1:
                        slider.maxValue = RM.Stone / IronCost;
                        return;
                    case 2:
                        slider.maxValue = 0;
                        return;
                    case 3:
                        slider.maxValue = RM.Stone / SulfurCost;
                        return;
                    case 4:
                        slider.maxValue = RM.Stone / MineralsCost;
                        return;
                    case 5:
                        slider.maxValue = RM.Stone / GemsCost;
                        return;
                    case 6:
                        slider.maxValue = RM.Stone / GoldCost;
                        return;
                }
                return;
            case 3:
                switch (index2)
                {
                    case 0:
                        slider.maxValue = RM.Sulfur / IronCost;
                        return;
                    case 1:
                        slider.maxValue = RM.Sulfur / IronCost;
                        return;
                    case 2:
                        slider.maxValue = RM.Sulfur / StoneCost;
                        return;
                    case 3:
                        slider.maxValue = 0;
                        return;
                    case 4:
                        slider.maxValue = RM.Sulfur / MineralsCost;
                        return;
                    case 5:
                        slider.maxValue = RM.Sulfur / GemsCost;
                        return;
                    case 6:
                        slider.maxValue = RM.Sulfur / GoldCost;
                        return;
                }
                return;
            case 4:
                switch (index2)
                {
                    case 0:
                        slider.maxValue = RM.Minerals / WoodCost;
                        return;
                    case 1:
                        slider.maxValue = RM.Minerals / IronCost;
                        return;
                    case 2:
                        slider.maxValue = RM.Minerals / StoneCost;
                        return;
                    case 3:
                        slider.maxValue = RM.Minerals / SulfurCost;
                        return;
                    case 4:
                        slider.maxValue = 0;
                        return;
                    case 5:
                        slider.maxValue = RM.Minerals / GemsCost;
                        return;
                    case 6:
                        slider.maxValue = RM.Minerals / GoldCost;
                        return;
                }
                return;
            case 5:
                switch (index2)
                {
                    case 0:
                        slider.maxValue = RM.Gems / WoodCost;
                        return;
                    case 1:
                        slider.maxValue = RM.Gems / IronCost;
                        return;
                    case 2:
                        slider.maxValue = RM.Gems / StoneCost;
                        return;
                    case 3:
                        slider.maxValue = RM.Gems / SulfurCost;
                        return;
                    case 4:
                        slider.maxValue = RM.Gems / MineralsCost;
                        return;
                    case 5:
                        slider.maxValue = 0;
                        return;
                    case 6:
                        slider.maxValue = RM.Gems / GoldCost;
                        return;
                }
                return;
            case 6:
                switch (index2)
                {
                    case 0:
                        slider.maxValue = RM.Gold / WoodCost;
                        return;
                    case 1:
                        slider.maxValue = RM.Gold / IronCost;
                        return;
                    case 2:
                        slider.maxValue = RM.Gold / StoneCost;
                        return;
                    case 3:
                        slider.maxValue = RM.Gold / SulfurCost;
                        return;
                    case 4:
                        slider.maxValue = RM.Gold / MineralsCost;
                        return;
                    case 5:
                        slider.maxValue = RM.Gold / GemsCost;
                        return;
                    case 6:
                        slider.maxValue = 0;
                        return;
                }
                return;
        }
    }

}

