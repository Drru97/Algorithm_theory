using System;

namespace Hash_tables_Open_addressing
{
    class Program
    {
        const Int32 DELETED = -1;
        static Int32 m = 10;
        static Int32[] hash = new Int32[m];
        static Int32 c1 = 1, c2 = 3;
        static Int32 m_ = m - 1;
        static Int16 num_of_keys = 0;

        static void Main(string[] args)
        {
            for (int i = 0; i < hash.Length; i++)
            {
                hash[i] = DELETED;
            }
            int to_do;
            int func;
            showFunc();
            func = Convert.ToInt32(Console.ReadLine());
            Func<int, int, int> f = new Func<int, int, int>(h_linear);
            if (func == 1) f = new Func<int, int, int>(h_linear);
            if (func == 2) f = new Func<int, int, int>(h_quad);
            if (func == 3) f = new Func<int, int, int>(h_double);
            showHelp();
            to_do = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                if (to_do == 1)
                {
                    if (num_of_keys < m)
                    {
                        int key;
                        Console.Write("enter key ->");
                        key = Convert.ToInt32(Console.ReadLine());
                        HashInsert(key, f);
                        num_of_keys++;
                        foreach (Int32 item in hash)
                        {
                            Console.WriteLine("item = " + ((item == DELETED) ? "DELETED" : Convert.ToString(item)));
                        }
                    }
                    else Console.WriteLine("Hash is full\n");
                }
                if (to_do == 2)
                {
                    int key;
                    Console.WriteLine("enter key to search: ");
                    key = Convert.ToInt32(Console.ReadLine());
                    int res = HashSearch(key);
                    Console.WriteLine("Key = " + key + " index = " + res);
                }
                if (to_do == 3)
                {
                    if (num_of_keys > 0)
                    {
                        int key;
                        Console.Write("enter key -> ");
                        key = Convert.ToInt32(Console.ReadLine());
                        HashDelete(key);
                        num_of_keys--;
                        foreach (Int32 item in hash)
                        {
                            Console.WriteLine("item = " + ((item == DELETED) ? "DELETED" : Convert.ToString(item)));
                        }
                    }
                    else Console.WriteLine("Has is empty!\n");
                }
                if (to_do == 4)
                {
                    Console.WriteLine("Table: \n");
                    foreach (Int32 item in hash)
                    {
                        Console.WriteLine("item = " + ((item == DELETED) ? "DELETED" : Convert.ToString(item)));
                    }
                }
                if (to_do == 5)
                {
                    break;
                }

                showHelp();
                to_do = Convert.ToInt32(Console.ReadLine());
            }
            Console.Read();
        }

        static void showFunc()
        {
            Console.WriteLine("Select func: ");
            Console.WriteLine("1 - linear");
            Console.WriteLine("2 - quadratic");
            Console.WriteLine("3 - double");
            Console.Write("choice  -> ");
        }

        static void showHelp()
        {
            Console.WriteLine("Select action:");
            Console.WriteLine("- 1. Insert");
            Console.WriteLine("- 2. Search");
            Console.WriteLine("- 3. Delete");
            Console.WriteLine("- 4. Show");
            Console.WriteLine("- 5. Exit");
            Console.Write("Choice -> ");
        }

        static Int32 h(Int32 k)
        {
            return k % m;
        }

        static Int32 h_linear(Int32 k, Int32 i)
        {
            return (h(k) + i) % m;
        }

        static Int32 h_quad(Int32 k, Int32 i)
        {
            return ((h(k) + c1 * i + c2 * i * i) % m);
        }

        static Int32 h2(Int32 k)
        {
            return 1 + (k % (m - 1));
        }

        static Int32 h_double(Int32 k, Int32 i)
        {
            return (h(k) + i * h2(k)) % m;
        }

        static Int32 HashSearch(Int32 k)
        {
            Int32 i = 0;
            int j = 0;
            do
            {
                j = h_linear(k, i);
                if (hash[j] == k) return j;
                else i++;
            } while (hash[j] != DELETED && i != m);
            return DELETED;
        }

        static Int32 HashInsert(Int32 k, Func<int, int, int> h)
        {
            Int32 i = 0;
            do
            {
                int j = h(k, i);
                {
                    if (hash[j] == DELETED)
                    {
                        hash[j] = k;
                        return j;
                    }
                    else i++;
                }
            } while (i != m);
            return -1;
        }

        static void HashDelete(int k)
        {
            int j = HashSearch(k);
            hash[j] = DELETED;
        }
    }
}
