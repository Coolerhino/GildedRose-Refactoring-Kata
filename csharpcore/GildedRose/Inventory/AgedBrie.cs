namespace GildedRoseKata.Inventory;

public class AgedBrie : IGoodCategory
{
    public Quality Quality { get; private set; }

    public int SellIn { get; private set; }
        
    public AgedBrie(int quality, int sellIn)
    {
        Quality = new Quality(quality);
        SellIn = sellIn;
    }

    public void Update()
    {
        Quality.Increase();

        SellIn = SellIn - 1;
        if (SellIn < 0)
        {
            Quality.Increase();
        }
    }
}