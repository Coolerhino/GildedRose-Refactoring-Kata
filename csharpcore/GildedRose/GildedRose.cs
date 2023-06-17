using System.Collections.Generic;

namespace GildedRoseKata
{
    public class Sulfuras
    {
        public int Quality { get; private set; }

        public int SellIn { get; private set; }
        
        public Sulfuras(int quality, int sellIn)
        {
            Quality = quality;
            SellIn = sellIn;
        }
        
        public void Update()
        {
        }
    }
    
    public class Generic
    {
        public int Quality { get; private set; }

        public int SellIn { get; private set; }
        
        public Generic(int quality, int sellIn)
        {
            Quality = quality;
            SellIn = sellIn;
        }
        
        public void Update()
        {
            if (Quality > 0)
            {
                Quality = Quality - 1;
            }

            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                if (Quality > 0)
                {
                    Quality = Quality - 1;
                }
            }
        }
    }
    
    public class AgedBrie
    {
        public int Quality { get; private set; }

        public int SellIn { get; private set; }
        
        public AgedBrie(int quality, int sellIn)
        {
            Quality = quality;
            SellIn = sellIn;
        }

        public void Update()
        {
            if (Quality < 50)
            {
                Quality = Quality + 1;
            }

            SellIn = SellIn - 1;
            if (SellIn < 0)
            {
                if (Quality < 50)
                {
                    Quality = Quality + 1;
                }
            }
        }
    }
    
    public class BackstagePass
    {
        public int Quality { get; private set; }

        public int SellIn { get; private set; }
        
        public BackstagePass(int quality, int sellIn)
        {
            Quality = quality;
            SellIn = sellIn;
        }

        public void Update()
        {
            if (Quality < 50)
            {
                Quality = Quality + 1;
                if (SellIn < 11)
                {
                    if (Quality < 50)
                    {
                        Quality = Quality + 1;
                    }
                }

                if (SellIn < 6)
                {
                    if (Quality < 50)
                    {
                        Quality = Quality + 1;
                    }
                }
            }

            SellIn = SellIn - 1;
            if (SellIn < 0)
            {
                Quality = Quality - Quality;
            }
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
                if (IsSulfuras(i))
                {
                    var sulfuras = new Sulfuras(Items[i].Quality, Items[i].SellIn);
                    sulfuras.Update();
                    Items[i].Quality = sulfuras.Quality;
                    Items[i].SellIn = sulfuras.SellIn;
                }
                else if (IsGeneric(i))
                {
                    var generic = new Generic(Items[i].Quality, Items[i].SellIn);
                    generic.Update();
                    Items[i].Quality = generic.Quality;
                    Items[i].SellIn = generic.SellIn;
                }
                else if (IsAgedBrie(i))
                {
                    var agedBrie = new AgedBrie(Items[i].Quality, Items[i].SellIn);
                    agedBrie.Update();
                    Items[i].Quality = agedBrie.Quality;
                    Items[i].SellIn = agedBrie.SellIn;
                }
                else if (IsBackstagePass(i))
                {
                    var backstagePass = new BackstagePass(Items[i].Quality, Items[i].SellIn);
                    backstagePass.Update();
                    Items[i].Quality = backstagePass.Quality;
                    Items[i].SellIn = backstagePass.SellIn;
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