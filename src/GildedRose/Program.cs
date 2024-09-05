using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new() {Name = GildedRose.DEXTERITY_VEST, SellIn = 10, Quality = 20},
                new() {Name = GildedRose.AGED_BRIE, SellIn = 2, Quality = 0},
                new() {Name = GildedRose.EXIXIR_MONGOOSE, SellIn = 5, Quality = 7},
                new() {Name = GildedRose.SULFURAS, SellIn = 0, Quality = 80},
                new() {Name = GildedRose.SULFURAS, SellIn = -1, Quality = 80},
                new() {
                    Name = GildedRose.BACKSTAGE_PASSES,
                    SellIn = 15,
                    Quality = 20
                },
                new() {
                    Name = GildedRose.BACKSTAGE_PASSES,
                    SellIn = 10,
                    Quality = 49
                },
                new() {
                    Name = GildedRose.BACKSTAGE_PASSES,
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new() {Name = GildedRose.CONJURED_MANA_CAKE, SellIn = 3, Quality = 6}
            };

            // Use a "System.Collections.Generic.Dictionary" as this makes the "Key" unique by definition.
            Dictionary<string, Action<Item>> itemsDictionary = new()
            {
                { GildedRose.AGED_BRIE, (item) => new AgedBrieItem(item).Update() },
                { GildedRose.BACKSTAGE_PASSES, (item) => new BackstagePassesItem(item).Update() },
                { GildedRose.SULFURAS, (item) => new SulfurasItem(item).Update() },
                { GildedRose.DEXTERITY_VEST, (item) => new NotSulfurasOrAgedBrieOrBackstagePassesItem(item).Update() },
                { GildedRose.EXIXIR_MONGOOSE, (item) => new NotSulfurasOrAgedBrieOrBackstagePassesItem(item).Update() },
                { GildedRose.CONJURED_MANA_CAKE, (item) => new NotSulfurasOrAgedBrieOrBackstagePassesItem(item).Update() },
                // Add more to the dictionary here when needed. Satifies open/closed principle.
            };

            // We inject the dictionary into the class so the class isn't dependent on setting the items. It ONLY
            // updates the items - single responsibility priciple.
            var app = new GildedRose(Items, itemsDictionary);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
