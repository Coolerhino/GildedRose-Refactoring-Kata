namespace GildedRoseKata.Inventory;

public class Sulfuras : IGoodCategory
{
    public Quality Quality { get; private set; }

    public int SellIn { get; private set; }

    public Sulfuras(int quality, int sellIn)
    {
        Quality = new Quality(quality);
        SellIn = sellIn;
    }
        
    public void Update()
    {
    }
}