namespace GildedRoseKata.Inventory;

public class Generic : IGoodCategory
{
    public Quality Quality { get; private set; }

    public int SellIn { get; private set; }
        
    public Generic(int quality, int sellIn)
    {
        Quality = new Quality(quality);
        SellIn = sellIn;
    }
        
    public void Update()
    {
        Quality.Degrade();
        SellIn = SellIn - 1;

        if (SellIn < 0)
        {
            Quality.Degrade();
        }
    }
}