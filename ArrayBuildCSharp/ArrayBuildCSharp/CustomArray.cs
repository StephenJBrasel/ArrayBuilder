using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayBuildCSharp {
    public class CustomArray<T> {
        T[] arr;
        public uint size {
            get;
            private set;
        } = 0;

        public CustomArray(uint Size) {
            size = Size;
            arr = new T[size];
        }

        public CustomArray(CustomArray<T> that) {
            this.size = that.size;
            this.arr = that.arr;
        }

        public T this[int i] {
            get {
                if (i < 0 || i >= size)
                    throw new IndexOutOfRangeException("index " + i + " is out of range [0-" + (size - 1) + "].");
                return arr[i];
            }
            set {
                if (i < 0 || i >= size)
                    throw new IndexOutOfRangeException("index " + i + " is out of range [0-" + (size - 1) + "].");
                arr[i] = value;
            }
        }

        public int search(T val) {
            for (int i = 0; i < size; i++) {
                if (arr[i].Equals(val)) return i;
            }
            return -1;
        }

        public void insert(T val, int i) {
            if (i < 0 || i > size)
                throw new IndexOutOfRangeException("index " + i + " is out of range [0-" + (size) + "].");

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

        public void insert(CustomArray<T> val, int i) {
            if (i < 0 || i > size)
                throw new IndexOutOfRangeException("index " + i + " is out of range [0-" + (size) + "].");

            T[] arrNew = new T[this.size + val.size];
            for (int j = 0; j < i; j++) {
                arrNew[j] = arr[j];
            }
            // This is just for demonstrating the algorithm, 
            // Standard: 
            //      Array.Copy(val.arr, 0, arrNew, i, val.size);
            for (int j = 0; j < val.size; j++) {
                arrNew[j + i] = val[j];
            }
            for (int j = i; j < size; j++) {
                arrNew[j + val.size] = arr[j];
            }
            size += val.size;
            arr = arrNew;
        }

        public bool removeAt(int i) {
            if (i < 0 || i >= size) return false;
            if (size <= 1) {
                size = 0;
                arr = new T[size];
            } else {
                T[] arrNew = new T[size - 1];
                for (int j = 0; j < i; j++) {
                    arrNew[j] = arr[j];
                }
                for (int j = i + 1; j < size; j++) {
                    arrNew[j - 1] = arr[j];
                }
                size--;
                arr = arrNew;
            }
            return true;
        }

        //remvoes f
        public bool remove(T val) {
            for (int i = 0; i < size; i++) {
                if (arr[i].Equals(val)) {
                    return removeAt(i);
                }
            }
            return false;
        }
    }
}
