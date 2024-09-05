namespace GildedRoseKata
{
    public class GeneralItem
    {
        // This is the only common thing we have between all the child classes.
        // So can put it here instead of in each child class.
        private Item _item;

        public GeneralItem(Item item)
        {
            _item = item;
        }

        // Virtual method that can be overridden.
        public virtual void Update()
        {
            // ReadMe.md gives some general condition first, which could have come in here. But then they give
            // other consitions that say something else, so we don't have anything "general".
            // Theres no common functionality between the child classes, but if there were, we could put it here.
            // We could make the class abstract and this method (with no body implementation) abstract as well as 
            // it isn't doing anything. 
            return;
        }
    }
}
