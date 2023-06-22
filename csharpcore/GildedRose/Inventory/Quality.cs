using System.IO.Compression;

namespace GildedRoseKata.Inventory;

public class Quality
{
    public static implicit operator int(Quality q) => q.Amount;
    
    public int Amount { get; private set; }
    
    public Quality(int amount)
    {
        Amount = amount;
    }

    public void Degrade()
    {
        if (Amount > 0)
        {
            Amount -= 1;
        }
    }

    public void Increase()
    {
        if (Amount < 50)
        {
            Amount += 1;
        }
    }

    public void Reset()
    {
        Amount = 0;
    }

    public bool IsLessThan50()
    {
        return Amount < 50;
    }
}