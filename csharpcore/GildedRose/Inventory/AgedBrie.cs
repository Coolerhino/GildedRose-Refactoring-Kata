namespace GildedRoseKata.Inventory;

public class AgedBrie : IGoodCategory
{
    public static IGoodCategory Build(int quality, int sellIn)
    {
        if (sellIn < 0)
        {
            return new Expired(quality);
        }
        else
        {
            return new AgedBrie(quality);
        }
    }
    private class Expired : IGoodCategory
    {
        public Quality Quality { get; private set; }
        public void Update(int _)
        {
            Quality.Increase();
            Quality.Increase();
        }

        public Expired(int quality)
        {
            Quality = new Quality(quality);
        }
    }
    
    public Quality Quality { get; private set; }

    public AgedBrie(int quality)
    {
        Quality = new Quality(quality);
    }

    public void Update(int sellIn)
    {
        Quality.Increase();
    }
}