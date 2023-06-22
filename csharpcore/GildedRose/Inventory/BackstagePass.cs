namespace GildedRoseKata.Inventory;

public class BackstagePass : IGoodCategory
{
    public Quality Quality { get; private set; }

    public int SellIn { get; private set; }
        
    public BackstagePass(int quality, int sellIn)
    {
        Quality = new Quality(quality);
        SellIn = sellIn;
    }

    public void Update()
    {
        Quality.Increase();
        if (Quality.IsLessThan50())
        {
            if (SellIn < 11)
            {
                Quality.Increase();
            }

            if (SellIn < 6)
            {
                Quality.Increase();
            }
        }

        SellIn = SellIn - 1;
        if (SellIn < 0)
        {
            Quality.Reset();
        }
    }
}