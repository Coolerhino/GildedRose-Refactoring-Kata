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
                    HandleGeneric(i);
                }
                else if (IsAgedBrie(i))
                {
                    HandleAgedBrie(i);
                }
                else if (IsBackstagePass(i))
                {
                    HandleBackstagePass(i);
                }
            }
        }

        private void HandleAgedBrie(int i)
        {
            if (QualityLessThan50(i))
            {
                IncreaseQuality(i);
            }

            Items[i].SellIn = Items[i].SellIn - 1;
            if (Items[i].SellIn < 0)
            {
                if (QualityLessThan50(i))
                {
                    IncreaseQuality(i);
                }
            }
        }

        private void HandleGeneric(int i)
        {
            if (Items[i].Quality > 0)
            {
                DecreaseQuality(i);
            }

            Items[i].SellIn = Items[i].SellIn - 1;

            if (Items[i].SellIn < 0)
            {
                if (Items[i].Quality > 0)
                {
                    DecreaseQuality(i);
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
            if (Items[i].SellIn < 0)
            {
                Items[i].Quality = Items[i].Quality - Items[i].Quality;
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