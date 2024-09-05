namespace GildedRoseKata
{
    // Class just for the "Sulfuras" item.
    public class SulfurasItem : GeneralItem
    {
        private Item _item;

        // When contructor is called with the passed in item, set this on the parent class first.
        public SulfurasItem(Item item) : base(item)
        {
            _item = item;
        }

        // Polymorphic method as it overrides the parent method.
        public override void Update()
        {
            // Do nothing at the moment....but could put some code in here if we needed to in future in requirements ask for it.
            return;
        }
    }
}
