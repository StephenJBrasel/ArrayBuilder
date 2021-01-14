using System;
using System.Collections.Generic;

namespace ArrayBuildCSharp
{
    class Program
    {

        static void WriteArray<T>(CustomArray<T> ar)
        {
            for (int i = 0; i < ar.size; i++)
            {
                Console.Write(ar[i]);
                if (i < ar.size - 1) Console.Write(", ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            uint size = 5;
            CustomArray<int> ar = new CustomArray<int>(size);
            for (int i = 0; i < size; i++)
            {
                ar[i] = i + 2;
            }
            WriteArray(ar);

            //OUT OF BOUNDS testing
            //int n = ar[9];
            //int n = ar[-9];
            //ar[9] = 9;
            //ar[-9] = 9;

            Console.WriteLine(ar.search(4));
            Console.WriteLine(ar.search(40));

            ar.insert(300, (int)(ar.size));
            WriteArray(ar);
            ar.insert(400, 0);
            WriteArray(ar);
            ar.insert(500, (int)(ar.size/2));
            WriteArray(ar);
            size = ar.size;
            for (int i = 0; i < size+1; i++)
            {
                Console.Write("" + ar.remove((int)(ar.size / 2)) + " ");
                WriteArray(ar);
            }
        }
    }
}
