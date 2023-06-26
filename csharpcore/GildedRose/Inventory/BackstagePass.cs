namespace GildedRoseKata.Inventory;

public class BackstagePass : IGoodCategory
{
    public Quality Quality { get; private set; }

    public BackstagePass(int quality)
    {
        Quality = new Quality(quality);
    }

    public void Update(int sellIn)
    {
        Quality.Increase();
        
        if (sellIn < 10)
        {
            Quality.Increase();
        }

        if (sellIn < 5)
        {
            Quality.Increase();
        }
        
        if (sellIn < 0)
        {
            Quality.Reset();
        }
    }
}