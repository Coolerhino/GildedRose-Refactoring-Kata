namespace GildedRoseKata.Inventory;

public interface IGoodCategory
{
    public Quality Quality { get; }
    public int SellIn{ get; }
    public void Update();
}