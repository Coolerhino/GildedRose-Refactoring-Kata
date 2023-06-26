namespace GildedRoseKata.Inventory;

public class Generic : IGoodCategory
{
    public Quality Quality { get; private set; }

    public Generic(int quality)
    {
        Quality = new Quality(quality);
    }
    
    public void Update(int sellIn)
    {
        Quality.Degrade();

        if (sellIn < 0)
        {
            Quality.Degrade();
        }
    }
}