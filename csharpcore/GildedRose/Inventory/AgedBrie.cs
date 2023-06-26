namespace GildedRoseKata.Inventory;

public class AgedBrie : IGoodCategory
{
    public Quality Quality { get; private set; }

    public AgedBrie(int quality)
    {
        Quality = new Quality(quality);
    }

    public void Update(int sellIn)
    {
        Quality.Increase();
        
        if (sellIn < 0)
        {
            Quality.Increase();
        }
    }
}