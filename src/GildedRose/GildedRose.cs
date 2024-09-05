using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata
{
    public class GildedRose
    {
        // Pull magic strings and numbers out of code & set as constants.
        public const string AGED_BRIE = "Aged Brie";
        public const string BACKSTAGE_PASSES = "Backstage passes to a TAFKAL80ETC concert";
        public const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        public const string DEXTERITY_VEST = "+5 Dexterity Vest";
        public const string EXIXIR_MONGOOSE = "Elixir of the Mongoose";
        public const string CONJURED_MANA_CAKE = "Conjured Mana Cake";

        public const int GENERAL_MIN_QUALITY = 0; // The min quality of an item..
        public const int GENERAL_MIN_SELLIN = 0; // The min sell-in of an item.
        public const int GENERAL_MAX_QUALITY = 50; // The max quality of an item not named "Sulfuras, Hand of Ragnaros" is never more than 50.
        public const int UPPER_LIMIT_SELLIN = 11; // The upper sell-in limit of an item.
        public const int LOWER_LIMIT_SELLIN = 6; // The upper sell-in limit of an item.

        private IList<Item> Items;

        // A dictionary which has two parameters:
        //      "key" = item-name (string) is unique
        //      "value" = reference to our void method (Action)
        // Because our "Update()" method in our classes is void method we can use simpler "Action".
        // Inject the dictionary of items into the class as a parameter because if we leave it in here it breaks 
        // the single responsibility priciple. This class should only update the item not set the item.
        private Dictionary<string, Action<Item>> ItemsDictionary;

        // Don't need this constructor now we are also passing in the dictionary of items.
        //public GildedRose(IList<Item> Items)
        //{
        //    this.Items = Items;
        //}

        public GildedRose(IList<Item> Items, Dictionary<string, Action<Item>> itemsDictionary)
        {
            this.Items = Items;
            // - Visual Studio quick refactoring. Moved variablke into constructor.
            this.ItemsDictionary = itemsDictionary;
        }

        //public Dictionary<string, Action<Item>> ItemsDictionary = new()
        //{
        //    { AGED_BRIE, (item) => new AgedBrieItem(item).Update() },
        //    { BACKSTAGE_PASSES, (item) => new BackstagePassesItem(item).Update() },
        //    { SULFURAS, (item) => new SulfurasItem(item).Update() },
        //    { DEXTERITY_VEST, (item) => new NotSulfurasOrAgedBrieOrBackstagePassesItem(item).Update() },
        //    { EXIXIR_MONGOOSE, (item) => new NotSulfurasOrAgedBrieOrBackstagePassesItem(item).Update() },
        //    { CONJURED_MANA_CAKE, (item) => new NotSulfurasOrAgedBrieOrBackstagePassesItem(item).Update() },
        //    // Add more to the dictionary here when needed. Satifies open/closed principle.
        //};

        // Not the best name for the method as apart from updating the "quality", sometimes the "sellin" changes as well.
        public void UpdateQuality()
        {
            KeyValuePair<string, Action<Item>> selectedItem; // Variable to hold the single value in our Dictionary. 
            // Use "foreach" instead of "for" - Visual Studio quick refactoring.
            foreach (Item item in Items)
            {
                // Find the matching item in the dictionary.
                selectedItem = ItemsDictionary.FirstOrDefault(x => x.Key == item.Name);
                // Send our current item to the dictionary to invoke the Update() method.
                selectedItem.Value(item);

                // Change from "if...if else...else" to switch-case  - Visual Studio quick refactoring.
                //switch (item.Name)
                //{
                //    // Aged Brie
                //    case AGED_BRIE:
                //        new AgedBrieItem(item).Update();
                //        break;
                //    // Backstage passes to a TAFKAL80ETC concert
                //    case BACKSTAGE_PASSES:
                //        new BackstagePassesItem(item).Update();
                //        break;
                //    // Sulpfuras
                //    case SULFURAS:
                //        new UpdateItemSulfuras(item).Update();
                //        break;
                //    default:
                //        new NotSulfurasOrAgedBrieOrBackstagePassesItem(item).Update();
                //        break;
                //}
            }
        }
    }
}