namespace GildedRoseKata.Inventory;

public interface IGoodCategory
{
    public int Quality { get; }
    public int SellIn{ get; }
    public void Update();
}