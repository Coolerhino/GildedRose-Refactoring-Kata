namespace GildedRoseKata.Inventory;

public interface IGoodCategory
{
    public Quality Quality { get; }
    public void Update(int sellIn);
}