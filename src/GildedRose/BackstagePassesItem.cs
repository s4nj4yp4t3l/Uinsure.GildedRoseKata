namespace GildedRoseKata
{
    // Class just for the "Backstage Passes" item.
    public class BackstagePassesItem: GeneralItem
    {
        private Item _item;

        // When contructor is called with the passed in item, set this on the parent class first.
        public BackstagePassesItem(Item item) : base(item)
        {
            _item = item;
        }

        // Polymorphic method as it overrides the parent method.
        public override void Update()
        {
            if (_item.Quality < GildedRose.GENERAL_MAX_QUALITY) _item.Quality++;
            if (_item.Quality < GildedRose.GENERAL_MAX_QUALITY && _item.SellIn < GildedRose.UPPER_LIMIT_SELLIN) _item.Quality++;
            if (_item.Quality < GildedRose.GENERAL_MAX_QUALITY && _item.SellIn < GildedRose.LOWER_LIMIT_SELLIN) _item.Quality++;
            if (_item.SellIn <= GildedRose.GENERAL_MIN_SELLIN) _item.Quality = 0; // Changed "<" to "<=" when moving as SellIn changed. 
            _item.SellIn--;
        }
    }
}
