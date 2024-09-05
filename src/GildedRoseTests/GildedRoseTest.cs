using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using System;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            Dictionary<string, Action<Item>> itemsDictionary = new()
            {
                { GildedRose.AGED_BRIE, (item) => new AgedBrieItem(item).Update() },
            };

            IList<Item> Items = new List<Item> { new Item { Name = GildedRose.AGED_BRIE, SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items, itemsDictionary);
            app.UpdateQuality();
            Assert.Equal(GildedRose.AGED_BRIE, Items[0].Name);
        }
    }
}
