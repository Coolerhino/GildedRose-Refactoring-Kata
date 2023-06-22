using System.Collections.Generic;
using GildedRoseKata.Inventory;

namespace GildedRoseKata
{
    public class GoodCategory
    {
        public IGoodCategory BuildFor(Item item)
        {
            if (IsAgedBrie(item))
            {
                return new AgedBrie(item.Quality, item.SellIn);
            }
            else if (IsBackstagePass(item))
            {
                return new BackstagePass(item.Quality, item.SellIn);
            }
            else if (IsGeneric(item))
            {
                return new Generic(item.Quality, item.SellIn);
            }
            return null;
        }
        
        private bool IsGeneric(Item i)
        {
            return !(IsBackstagePass(i) || IsAgedBrie(i));
        }

        private bool IsBackstagePass(Item i)
        {
            return i.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private bool IsAgedBrie(Item i)
        {
            return i.Name == "Aged Brie";
        }
    }
    
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
                if (IsSulfuras(Items[i])) continue;
                var item = new GoodCategory().BuildFor(Items[i]);
                item.Update();
                Items[i].Quality = item.Quality;
                Items[i].SellIn = item.SellIn;
            }
        }
        
        private bool IsSulfuras(Item i)
        {
            return i.Name == "Sulfuras, Hand of Ragnaros";
        }
    }
}