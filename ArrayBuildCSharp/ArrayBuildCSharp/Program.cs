using System;
using System.Collections.Generic;

namespace ArrayBuildCSharp {
    class Program {

        static void WriteArray<T>(CustomArray<T> ar) {
            for (int i = 0; i < ar.size; i++) {
                Console.Write(ar[i]);
                if (i < ar.size - 1) Console.Write(", ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args) {
            uint size = 5;
            CustomArray<int> ar = new CustomArray<int>(size);
            for (int i = 0; i < size; i++) {
                ar[i] = i + 2;
            }
            WriteArray(ar);


            int x = 0;
            x = x + 0 * (x = x + 1);
            Console.WriteLine(x);

            //OUT OF BOUNDS testing
            //int n = ar[size];
            //int n = ar[-1];
            //ar[size] = 9;
            //ar[-1] = 9;
            //ar.insert(9, (int)ar.size);
            //ar.insert(9, (int)ar.size+1);

            Console.WriteLine(ar.search(4));
            Console.WriteLine(ar.search(40));

            ar.insert(300, (int)(ar.size));
            WriteArray(ar);
            ar.insert(400, 0);
            WriteArray(ar);
            ar.insert(500, (int)(ar.size / 2));
            WriteArray(ar);
            size = ar.size;
            for (int i = 0; i < size + 1; i++) {
                Console.Write("" + ar.removeAt((int)(ar.size / 2)) + " ");
                WriteArray(ar);
            }

            Console.WriteLine();
            Console.WriteLine(size = 4);
            CustomArray<int> insertAr1 = new CustomArray<int>(size);
            for (int i = 0; i < size; i++) {
                insertAr1[i] = i;
            }
            CustomArray<int> insertAr2 = new CustomArray<int>(insertAr1);
            CustomArray<int> insertAr3 = new CustomArray<int>(insertAr1);

            CustomArray<int> insertArDemo = new CustomArray<int>(size);
            for (int i = 0; i < size; i++) {
                insertArDemo[i] = i + (int)size;
            }

            WriteArray(insertAr1);
            WriteArray(insertAr2);
            WriteArray(insertAr3);
            WriteArray(insertArDemo);

            insertAr1.insert(insertArDemo, (int)insertAr1.size);
            insertAr2.insert(insertArDemo, (int)(insertAr2.size / 2));
            insertAr3.insert(insertArDemo, 0);

            Console.WriteLine();
            WriteArray(insertAr1);
            WriteArray(insertAr2);
            WriteArray(insertAr3);
            WriteArray(insertArDemo);
        }
    }
}
