using System;
using Xunit;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        
        [Theory]
        [InlineData(22, 8, 20)]
        [InlineData(23, 4, 20)]
        [InlineData(0, 0, 20)]
        public void assert_backstage_pass_quality(int expected, int sellIn, int quality)
        {
            var items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality }
            };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(expected, items[0].Quality);
        }
        
        [Theory]
        [InlineData(22, 0, 20)]
        public void assert_aged_brie_quality(int expected, int sellIn, int quality)
        {
            var items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality }
            };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(expected, items[0].Quality);
        }
        
        [Fact]
        public void test_generic()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = -1, Quality = 3 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }
    }
}
