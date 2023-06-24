using System.Collections.Generic;
using GildedRoseKata.Inventory;

namespace GildedRoseKata
{
    public class GoodCategory
    {
        public IGoodCategory BuildFor(Item item) => item.Name switch
        {
            "Backstage passes to a TAFKAL80ETC concert" => new BackstagePass(item.Quality, item.SellIn),
            "Aged Brie" => new AgedBrie(item.Quality, item.SellIn),
            _ => new Generic(item.Quality, item.SellIn)
        };
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