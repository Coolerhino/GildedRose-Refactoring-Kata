namespace GildedRoseKata.Inventory;

public class BackstagePass : IGoodCategory
{
    public int Quality { get; private set; }

    public int SellIn { get; private set; }
        
    public BackstagePass(int quality, int sellIn)
    {
        Quality = quality;
        SellIn = sellIn;
    }

    public void Update()
    {
        if (Quality < 50)
        {
            Quality = Quality + 1;
            if (SellIn < 11)
            {
                if (Quality < 50)
                {
                    Quality = Quality + 1;
                }
            }

            if (SellIn < 6)
            {
                if (Quality < 50)
                {
                    Quality = Quality + 1;
                }
            }
        }

        SellIn = SellIn - 1;
        if (SellIn < 0)
        {
            Quality = Quality - Quality;
        }
    }
}