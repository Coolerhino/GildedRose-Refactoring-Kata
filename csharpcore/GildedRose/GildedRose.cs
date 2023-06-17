using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (IsSulfuras(i))
                {
                }
                else if (IsGeneric(i))
                {
                    if (Items[i].Quality > 0)
                    {
                        Items[i].Quality = Items[i].Quality - 1;
                    }

                    Items[i].SellIn = Items[i].SellIn - 1;

                    if (Items[i].SellIn < 0)
                    {
                        if (Items[i].Quality > 0)
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else if (IsAgedBrie(i))
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;
                    }

                    Items[i].SellIn = Items[i].SellIn - 1;
                    if (Items[i].SellIn < 0)
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
                else if (IsBackstagePass(i))
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;
                        if (Items[i].SellIn < 11)
                        {
                            if (Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }

                        if (Items[i].SellIn < 6)
                        {
                            if (Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }
                    }

                    Items[i].SellIn = Items[i].SellIn - 1;
                    if (Items[i].SellIn < 0)
                    {
                        Items[i].Quality = Items[i].Quality - Items[i].Quality;
                    }
                }
            }
        }

        private bool IsGeneric(int i)
        {
            return !(IsSulfuras(i) || IsBackstagePass(i) || IsAgedBrie(i));
        }

        private bool IsSulfuras(int i)
        {
            return Items[i].Name == "Sulfuras, Hand of Ragnaros";
        }

        private bool IsBackstagePass(int i)
        {
            return Items[i].Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private bool IsAgedBrie(int i)
        {
            return Items[i].Name == "Aged Brie";
        }
    }
}