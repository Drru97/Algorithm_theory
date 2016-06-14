using System;

namespace Hash_Tables
{
    class OpenHashTable
    {
        public int m;
        List[] T;
        string function;
        double A;

        public OpenHashTable(int m)
        {
            this.m = m;
            T = new List[m];
            function = "division";
            A = (Math.Sqrt(5) - 1) / 2;
        }

        public int h(int k)
        {
            if (function == "division")
                return k % m;
            else
                return (int)(m * ((k * A) % 1));
        }

        void Chained_Hash_Insert(int x)
        {
           // T[h(x)].add_begin();
        }


    }
}
