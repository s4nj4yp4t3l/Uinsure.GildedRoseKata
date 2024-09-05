namespace GildedRoseKata
{
    // Class just for not the "Sulfuras" or "Aged Brie" or "Backstage Passes" items.
    public class NotSulfurasOrAgedBrieOrBackstagePassesItem : GeneralItem
    {
        private Item _item;

        // When contructor is called with the passed in item, set this on the parent class first.
        public NotSulfurasOrAgedBrieOrBackstagePassesItem(Item item) : base(item)
        {
            _item = item;
        }

        // Polymorphic method as it overrides the parent method.
        public override void Update()
        {
            _item.SellIn--;
            if (_item.SellIn < GildedRose.GENERAL_MIN_SELLIN && _item.Quality > GildedRose.GENERAL_MIN_QUALITY) _item.Quality--;
            if (_item.Quality > GildedRose.GENERAL_MIN_QUALITY) _item.Quality--;
        }
    }
}
