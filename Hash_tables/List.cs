namespace Hash_Tables
{
    public class List
    {
        public Item first, last;

        public List()
        {
            first = null;
            last = null;
        }

        public void add_begin(Item data)
        {
            Item temp = new Item(data);
            temp.next = first;
            temp.previous = null;
            if (first != null)
                first.previous = temp;
            else
                last = temp;
            first = temp;
        }

        public void del_begin()
        {
            if (first == null)
                return;
            Item temp = first;
            first = temp.next;
            if (first != null)
                first.previous = null;
            else
                last = null;
        }

        public void del_end()
        {
            if (first == null)
                return;
            Item temp = last;
            last = temp.previous;
            if (first != null)
                last.next = null;
            else
                first = null;
        }

        public Item search(Item data)
        {
            Item temp = first;
            while (temp != null)
                if (temp.data == data)
                    return temp;
                else
                    temp = temp.next;
            return null;
        }

        public void del_mid(Item data)
        {
            Item temp = search(data);
            if (temp == null)
                return;
            if (first == temp)
            {
                del_begin();
                return;
            }
            if (last == temp)
            {
                del_end();
                return;
            }
            temp.previous.next = temp.next;
            temp.next.previous = temp.previous;
        }

        public string show()
        {
            Item temp = first;
            string show_string = "";
            while (temp != null)
            {
                show_string += temp.data.ToString() + " ";
                temp = temp.next;
            }
            return show_string;
        }
    }
}
