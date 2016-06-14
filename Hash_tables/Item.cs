namespace Hash_Tables
{
    public class Item
    {
        public Item data, previous, next;

        public Item(Item data)
        {
            this.data = data;
            previous = null;
            next = null;
        }
    }
}
