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
                        DecreaseQuality(i);
                    }

                    Items[i].SellIn = Items[i].SellIn - 1;
                }
                else if (IsAgedBrie(i))
                {
                    if (QualityLessThan50(i))
                    {
                        IncreaseQuality(i);
                    }

                    Items[i].SellIn = Items[i].SellIn - 1;
                }
                else if (IsBackstagePass(i))
                {
                    HandleBackstagePass(i);
                }

                if (IsAgedBrie(i))
                {
                    if (Items[i].SellIn < 0)
                    {
                        if (QualityLessThan50(i))
                        {
                            IncreaseQuality(i);
                        }
                    }
                }
                else if (IsBackstagePass(i))
                {
                    if (Items[i].SellIn < 0)
                    {
                        Items[i].Quality = Items[i].Quality - Items[i].Quality;
                    }
                }
                else if (IsSulfuras(i))
                {
                }
                else if (IsGeneric(i))
                {
                    if (Items[i].SellIn < 0)
                    {
                        if (Items[i].Quality > 0)
                        {
                            DecreaseQuality(i);
                        }
                    }
                }
            }
        }

        private void HandleBackstagePass(int i)
        {
            if (QualityLessThan50(i))
            {
                IncreaseQuality(i);
                if (Items[i].SellIn < 11)
                {
                    if (QualityLessThan50(i))
                    {
                        IncreaseQuality(i);
                    }
                }

                if (Items[i].SellIn < 6)
                {
                    if (QualityLessThan50(i))
                    {
                        IncreaseQuality(i);
                    }
                }
            }

            Items[i].SellIn = Items[i].SellIn - 1;
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

        private bool QualityLessThan50(int i)
        {
            return Items[i].Quality < 50;
        }

        private void IncreaseQuality(int i)
        {
            Items[i].Quality = Items[i].Quality + 1;
        }

        private void DecreaseQuality(int i)
        {
            Items[i].Quality = Items[i].Quality - 1;
        }
    }
}