using System;

namespace Counting_Sort
{
    public struct KVEntry
    {
        int key;
        int value;

        public int Key
        {
            get { return key; }
            set
            {
                if (key >= 0)
                    key = value;
                else
                    throw new Exception("Invalid key value");
            }
        }

        public int Value
        {
            get { return value; }
            set
            {
                this.value = value;
            }
        }
    }
}
