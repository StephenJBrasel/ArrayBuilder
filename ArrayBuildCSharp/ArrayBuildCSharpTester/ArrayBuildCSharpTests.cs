using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayBuildCSharp;
using System;

namespace ArrayBuildCSharpTester {
    [TestClass]
    public class ArrayBuildCSharpPositiveTesting {
        CustomArray<int> intAr;
        uint Size = 5;

        [TestInitialize]
        public void Setup() {
            intAr = new CustomArray<int>(Size);
        }

        [TestCleanup]
        public void TearDown() {
            intAr = null;
        }

        [TestMethod]
        public void notNull() {
            Assert.IsNotNull(intAr);
        }

        [TestMethod]
        public void size() {
            Assert.AreEqual(Size, intAr.size);
        }

        [TestMethod]
        public void copyConstructor() {
            CustomArray<int> copyAr = new CustomArray<int>(intAr);
            Assert.AreEqual(intAr.size, copyAr.size);
            for (int i = 0; i < intAr.size; i++) {
                Assert.AreEqual(intAr[1], copyAr[1]);
            }
        }

        [TestMethod]
        public void bracketing() {
            for (int i = 0; i < Size; i++) {
                intAr[i] = i;
            }
            for (int i = 0; i < intAr.size; i++) {
                Assert.AreEqual(intAr[i], i);
            }
        }

        [TestMethod]
        public void search() {
            intAr.insert(int.MaxValue, (int)(intAr.size));
            Assert.AreEqual((int)(intAr.size-1), intAr.search(int.MaxValue));
        }

        [TestMethod]
        public void insertTFront() {
            intAr.insert(int.MaxValue, 0);
            int[] expected = new int[Size + 1];
            expected[0] = int.MaxValue;
            for (int i = 0; i < intAr.size; i++) {
                Assert.AreEqual(expected[i], intAr[i]);
            }
        }

        [TestMethod]
        public void insertTMid() {
            intAr.insert(int.MaxValue, (int)(intAr.size / 2));
            int[] expected = new int[Size + 1];
            expected[Size/2] = int.MaxValue;
            for (int i = 0; i < intAr.size; i++) {
                Assert.AreEqual(expected[i], intAr[i]);
            }
        }

        [TestMethod]
        public void insertTEnd() {
            intAr.insert(int.MaxValue, (int)(intAr.size));
            int[] expected = new int[Size+1];
            expected[Size] = int.MaxValue;
            for (int i = 0; i < intAr.size; i++) {
                Assert.AreEqual(expected[i], intAr[i]);
            }
        }

        [TestMethod]
        public void insertTArrFront() {
            CustomArray<int> TArr = new CustomArray<int>(Size);
            int[] expected = new int[2*Size];
            for (int i = 0; i < TArr.size; i++) {
                TArr[i] = i;
                expected[i] = i;
            }
            intAr.insert(TArr, 0);
            for (int i = 0; i < intAr.size; i++) {
                Assert.AreEqual(expected[i], intAr[i]);
            }
        }

        [TestMethod]
        public void insertTArrMid() {
            CustomArray<int> TArr = new CustomArray<int>(Size);
            int[] expected = new int[2 * Size];
            int halfLen = (int)(intAr.size / 2);
            for (int i = 0; i < TArr.size; i++) {
                TArr[i] = i;
                expected[i + halfLen] = i;
            }
            intAr.insert(TArr, (int)(intAr.size/2));
            for (int i = 0; i < intAr.size; i++) {
                Assert.AreEqual(expected[i], intAr[i]);
            }
        }

        [TestMethod]
        public void insertTArrEnd() {
            CustomArray<int> TArr = new CustomArray<int>(Size);
            int[] expected = new int[2 * Size];
            for (int i = 0; i < TArr.size; i++) {
                TArr[i] = i;
                expected[i + (int)(intAr.size)] = i;
            }
            intAr.insert(TArr, (int)intAr.size);
            for (int i = 0; i < intAr.size; i++) {
                Assert.AreEqual(expected[i], intAr[i]);
            }
        }

        [TestMethod]
        public void removeIndexWorks() {
            for (int i = 0; i < intAr.size; i++) {
                intAr[i] = i;
            }
            if (Size == 0) Assert.IsFalse(intAr.removeAt(0));
            else Assert.IsTrue(intAr.removeAt(0));
        }

        [TestMethod]
        public void removeIndexDecrementsSize() {
            for (int i = 0; i < intAr.size; i++) {
                intAr[i] = i;
            }
            intAr.removeAt(0);
            if (Size == 0) Assert.AreEqual(0, (int)intAr.size);
            else Assert.AreEqual((int)Size - 1, (int)(intAr.size));
        }

        [TestMethod]
        public void removeIndexAdjustsArray() {
            for (int i = 0; i < intAr.size; i++) {
                intAr[i] = i;
            }
            intAr.removeAt(0);
            for (int i = 0; i < intAr.size; i++) {
                Assert.AreEqual(i + 1, intAr[i]);
            }
        }

        [TestMethod]
        public void removeTValWorks() {
            for (int i = 0; i < intAr.size; i++) {
                intAr[i] = i;
            }
            if (Size == 0) Assert.IsFalse(intAr.remove(0));
            else Assert.IsTrue(intAr.remove(0));
        }

        [TestMethod]
        public void removeTValDecrementsSize() {
            for (int i = 0; i < intAr.size; i++) {
                intAr[i] = i;
            }
            intAr.remove(0);
            if (Size == 0) Assert.AreEqual(0, (int)intAr.size);
            else Assert.AreEqual((int)Size - 1, (int)(intAr.size));
        }

        [TestMethod]
        public void removeTValAdjustsArray() {
            for (int i = 0; i < intAr.size; i++) {
                intAr[i] = i;
            }
            intAr.remove(0);
            for (int i = 0; i < intAr.size; i++) {
                Assert.AreEqual(i + 1, intAr[i]);
            }
        }
    }
    [TestClass]
    public class ArrayBuildCSharpNegativeTesting {
        CustomArray<int> intAr;
        uint Size = 5;

        [TestInitialize]
        public void Setup() {
            intAr = new CustomArray<int>(Size);
        }

        [TestCleanup]
        public void TearDown() {
            intAr = null;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void bracketSize() {
            int store = intAr[(int)intAr.size];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void bracketNegative() {
            int store = intAr[-1];
        }

        [TestMethod]
        public void searchNotFound() {
            Assert.AreEqual(-1, intAr.search(1));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void insertTSizePlusOne() {
            intAr.insert(int.MaxValue, (int)(intAr.size + 1));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void insertTNegativeOne() {
            intAr.insert(int.MaxValue, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void insertTArrSizePlusOne() {
            CustomArray<int> TArr = new CustomArray<int>(Size);
            intAr.insert(TArr, (int)(intAr.size+1));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void insertTArrNegativeOne() {
            CustomArray<int> TArr = new CustomArray<int>(Size);
            intAr.insert(TArr, -1);
        }

        [TestMethod]
        public void removeIndexNegativeIndex() {
            Assert.IsFalse(intAr.removeAt(-1));
        }

        [TestMethod]
        public void removeIndexSizePlusOne() {
            Assert.IsFalse(intAr.removeAt((int)(intAr.size + 1)));
        }

        [TestMethod]
        public void removeTValNotInArray() {
            Assert.IsFalse(intAr.remove(-1));
        }
    }
}
