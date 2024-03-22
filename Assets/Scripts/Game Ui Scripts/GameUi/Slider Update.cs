using UnityEngine;
using UnityEngine.UI;

public class SliderUpdate : MonoBehaviour
{
    public ResourceManager RM;
    public Slider slider;
    private Button Left, Right;
    private int WoodCost, IronCost, StoneCost, SulfurCost, MineralsCost, GemsCost, GoldCost;
    private int index1, index2;

    void Start()
    {

        Left = gameObject.transform.Find("LeftButton").GetComponent<Button>();
        Right = gameObject.transform.Find("RightButton").GetComponent<Button>();


        Left.onClick.AddListener(delegate { slider.value -= 1; });
        Right.onClick.AddListener(delegate { slider.value += 1; });

        RM = FindObjectOfType<ResourceManager>();
    }
    private void Update()
    {
        BuyableAmount();
        FindObjectOfType<MarketPriceList>().GetAmount((int)slider.value);
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
        if (Inx1 != null)
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
        switch (index1)
        {
            case 0:
                switch (index2)
                {
                    case 0:
                        slider.maxValue = 0;
                        return;
                    case 1:
                        slider.maxValue = RM.Data.Wood / IronCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(IronCost);
                        return;
                    case 2:
                        slider.maxValue = RM.Data.Wood / StoneCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(StoneCost);
                        return;
                    case 3:
                        slider.maxValue = RM.Data.Wood / SulfurCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(SulfurCost);
                        return;
                    case 4:
                        slider.maxValue = RM.Data.Wood / MineralsCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(MineralsCost);
                        return;
                    case 5:
                        slider.maxValue = RM.Data.Wood / GemsCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(GemsCost);
                        return;
                    case 6:
                        slider.maxValue = RM.Data.Wood ;
                        FindObjectOfType<MarketPriceList>().ReturnResource(GoldCost);
                        return;
                }
                return;
            case 1:
                switch (index2)
                {
                    case 0:
                        slider.maxValue = RM.Data.Iron / WoodCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(WoodCost);
                        return;
                    case 1:
                        slider.maxValue = 0;
                        return;
                    case 2:
                        slider.maxValue = RM.Data.Iron / StoneCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(StoneCost);
                        return;
                    case 3:
                        slider.maxValue = RM.Data.Iron / SulfurCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(SulfurCost);
                        return;
                    case 4:
                        slider.maxValue = RM.Data.Iron / MineralsCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(MineralsCost);
                        return;
                    case 5:
                        slider.maxValue = RM.Data.Iron / GemsCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(GemsCost);
                        return;
                    case 6:
                        slider.maxValue = RM.Data.Iron ;
                        FindObjectOfType<MarketPriceList>().ReturnResource(GoldCost);
                        return;
                }
                return;
            case 2:
                switch (index2)
                {
                    case 0:
                        slider.maxValue = RM.Data.Stone / WoodCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(WoodCost);
                        return;
                    case 1:
                        slider.maxValue = RM.Data.Stone / IronCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(IronCost);
                        return;
                    case 2:
                        slider.maxValue = 0;
                        return;
                    case 3:
                        slider.maxValue = RM.Data.Stone / SulfurCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(SulfurCost);
                        return;
                    case 4:
                        slider.maxValue = RM.Data.Stone / MineralsCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(MineralsCost);
                        return;
                    case 5:
                        slider.maxValue = RM.Data.Stone / GemsCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(GemsCost);
                        return;
                    case 6:
                        slider.maxValue = RM.Data.Stone ;
                        FindObjectOfType<MarketPriceList>().ReturnResource(GoldCost);
                        return;
                }
                return;
            case 3:
                switch (index2)
                {
                    case 0:
                        slider.maxValue = RM.Data.Sulfur / WoodCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(WoodCost);
                        return;
                    case 1:
                        slider.maxValue = RM.Data.Sulfur / IronCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(IronCost);
                        return;
                    case 2:
                        slider.maxValue = RM.Data.Sulfur / StoneCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(StoneCost);
                        return;
                    case 3:
                        slider.maxValue = 0;
                        return;
                    case 4:
                        slider.maxValue = RM.Data.Sulfur / MineralsCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(MineralsCost);
                        return;
                    case 5:
                        slider.maxValue = RM.Data.Sulfur / GemsCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(GemsCost);
                        return;
                    case 6:
                        slider.maxValue = RM.Data.Sulfur ;
                        FindObjectOfType<MarketPriceList>().ReturnResource(GoldCost);
                        return;
                }
                return;
            case 4:
                switch (index2)
                {
                    case 0:
                        slider.maxValue = RM.Data.Minerals / WoodCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(WoodCost);
                        return;
                    case 1:
                        slider.maxValue = RM.Data.Minerals / IronCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(IronCost);
                        return;
                    case 2:
                        slider.maxValue = RM.Data.Minerals / StoneCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(StoneCost);
                        return;
                    case 3:
                        slider.maxValue = RM.Data.Minerals / SulfurCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(SulfurCost);
                        return;
                    case 4:
                        slider.maxValue = 0;
                        return;
                    case 5:
                        slider.maxValue = RM.Data.Minerals / GemsCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(GemsCost);
                        return;
                    case 6:
                        slider.maxValue = RM.Data.Minerals ;
                        FindObjectOfType<MarketPriceList>().ReturnResource(GoldCost);
                        return;
                }
                return;
            case 5:
                switch (index2)
                {
                    case 0:
                        slider.maxValue = RM.Data.Gems / WoodCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(WoodCost);
                        return;
                    case 1:
                        slider.maxValue = RM.Data.Gems / IronCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(IronCost);
                        return;
                    case 2:
                        slider.maxValue = RM.Data.Gems / StoneCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(StoneCost);
                        return;
                    case 3:
                        slider.maxValue = RM.Data.Gems / SulfurCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(SulfurCost);
                        return;
                    case 4:
                        slider.maxValue = RM.Data.Gems / MineralsCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(MineralsCost);
                        return;
                    case 5:
                        slider.maxValue = 0;
                        return;
                    case 6:
                        slider.maxValue = RM.Data.Gems ;
                        FindObjectOfType<MarketPriceList>().ReturnResource(GoldCost);
                        return;
                }
                return;
            case 6:
                switch (index2)
                {
                    case 0:
                        slider.maxValue = RM.Data.Gold / WoodCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(WoodCost);
                        return;
                    case 1:
                        slider.maxValue = RM.Data.Gold / IronCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(IronCost);
                        return;
                    case 2:
                        slider.maxValue = RM.Data.Gold / StoneCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(StoneCost);
                        return;
                    case 3:
                        slider.maxValue = RM.Data.Gold / SulfurCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(SulfurCost);
                        return;
                    case 4:
                        slider.maxValue = RM.Data.Gold / MineralsCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(MineralsCost);
                        return;
                    case 5:
                        slider.maxValue = RM.Data.Gold / GemsCost;
                        FindObjectOfType<MarketPriceList>().ReturnResource(GemsCost);
                        return;
                    case 6:
                        slider.maxValue = 0;
                        return;
                }
                return;
        }
    }
}

