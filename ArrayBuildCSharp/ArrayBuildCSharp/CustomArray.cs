using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayBuildCSharp
{
    class CustomArray<T>
    {
        T[] arr;
        public uint size
        {
            get;
            private set;
        } = 0;

        public CustomArray(uint Size)
        {
            size = Size;
            arr = new T[size];
        }

        public T this[int i]
        {
            get {
                if (i < 0 || i >= size) 
                    throw new IndexOutOfRangeException("index " + i + " is out of range [0-" + (size-1) + "].");
                return arr[i]; 
            }
            set
            {
                if (i < 0 || i >= size) 
                    throw new IndexOutOfRangeException("index " + i + " is out of range [0-" + (size-1) + "]."); 
                arr[i] = value; 
            }
        }

        public int search(T val)
        {
            for (int i = 0; i < size; i++) {
                if (arr[i].Equals(val)) return i;
            }
            return -1;
        }

        public void insert(T val, int i)
        {
            if (i < 0 || i > size) 
                throw new IndexOutOfRangeException("index " + i + " is out of range [0-" + (size - 1) + "].");

            T[] arrNew = new T[size + 1];
            for (int j = 0; j < i; j++) {
                arrNew[j] = arr[j];
            }
            arrNew[i] = val;
            for (int j = i; j < size; j++) {
                arrNew[j + 1] = arr[j];
            }
            size++;
            arr = arrNew;
        }

        public bool remove(int i)
        {
            if (i < 0 || i >= size) return false; // It's already removed. It was never there. 
            if(size <= 1) {
                size = 0;
                arr = new T[size];
            } else {
                T[] arrNew = new T[size - 1];
                for (int j = 0; j < i; j++) {
                    arrNew[j] = arr[j];
                }
                for (int j = i+1; j < size; j++) {
                    arrNew[j-1] = arr[j];
                }
                size--;
                arr = arrNew;
            }
            return true;
        }
    }
}
