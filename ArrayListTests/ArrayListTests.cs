using System;
using ArrayList;
using NUnit.Framework;

namespace ArrayListTests
{
    public class ArrayListTests
    {
        private ArrayList<int> _list;

        [SetUp]
        public void SetUp()
        {
            _list = new ArrayList<int>();
        }

        [TestCase(new int[] { 0, 1, 2, 4 }, 5, new int[] { 0, 1, 2, 4, 5 })]
        [TestCase(new int[] { }, 5, new int[] { 5 })]
        [TestCase(new int[] { 0 }, -2135, new int[] { 0, -2135 })]
        public void AddTest(int[] array, int a, int[] expected)
        {
            _list.Add(array);
            _list.Add(a);

            Assert.AreEqual(expected,_list.Return());
        }

        [TestCase(new int[] { 0, 1, 3 }, new int[] { 4, 2, 1, 0 }, new int[] { 0, 1, 3, 4, 2, 1, 0 })]
        [TestCase(new int[] { }, new int[] { -1, 2, 0 }, new int[] { -1, 2, 0 })]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        public void AddTest(int[] array, int[] a, int[] expected)
        {
            _list.Add(array);
            _list.Add(a);

            Assert.AreEqual(expected, _list.Return());
        }

        [TestCase(new int[] { 0, 1, 2, 4 }, 2, 5, new int[] { 0, 1, 5, 2, 4 })]
        [TestCase(new int[] { }, 0, 1, new int[] { 1 })]
        [TestCase(new int[] { 0 }, 0, -2135, new int[] { -2135, 0 })]
        public void AddTest(int[] array, int index, int a, int[] expected)
        {
            _list.Add(array);
            _list.Add(index, a);

            Assert.AreEqual(expected, _list.Return());
        }

        [TestCase(new int[] { 0, 1, 2, 4 }, 1, new int[] { 9, 8, 7 }, new int[] { 0, 9, 8, 7, 1, 2, 4 })]
        [TestCase(new int[] { 999 }, 0, new int[] { 1, -2, 3 },new int[] { 1, -2, 3, 999 })]
        [TestCase(new int[] { }, 0, new int[] { }, new int[] { })]
        public void AddTest(int[] array, int index, int[] a, int[] expected) 
        {
            var listForTest = new ArrayList<int>(a);
            _list.Add(array);
            _list.Add(index, listForTest);

            Assert.AreEqual(expected, _list.Return());
        }

        [TestCase(new int[] { 0, 1, 2, 4 }, 5, new int[] { 5, 0, 1, 2, 4 })]
        [TestCase(new int[] { }, 5, new int[] { 5 })]
        [TestCase(new int[] { 0 }, -2135, new int[] { -2135, 0 })]
        public void AddToStartTest(int[] array, int a, int[] expected)
        {
            _list.Add(array);
            _list.AddToStart(a);

            Assert.AreEqual(expected, _list.Return());
        }

        [TestCase(new int[] { 0, 1, 2, 4 }, new int[] { 7, 8, 9 }, new int[] { 7, 8, 9, 0, 1, 2, 4 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 4 }, new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 0 }, new int[] { -23, 67 }, new int[] { -23, 67, 0 })]
        public void AddToStartTest(int[] array, int[] a, int[] expected)
        {
            var listForTest = new ArrayList<int>(a);
            _list.Add(array);
            _list.AddToStart(listForTest);

            Assert.AreEqual(expected, _list.Return());
        }

        [TestCase(new int[] { 0, 1, 2, 4 }, new int[] { 0, 1, 2 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 0 }, new int[] { })]
        public void RemoveTest(int[] array, int[] expected)
        {
            _list.Add(array);
            _list.Remove();

            Assert.AreEqual(expected, _list.Return());
        }

        [TestCase(new int[] { 0, 1, 2, 4 }, 2, new int[] { 0, 1, 4 })]
        [TestCase(new int[] { 0 }, 0, new int[] { })]
        public void RemoveTest(int[] array, int a, int[] expected)
        {
            _list.Add(array);
            _list.Remove(a);

            Assert.AreEqual(expected, _list.Return());
        }

        [TestCase(new int[] { 0, 1, 2, 4 }, 1, 3, new int[] { 0 })]
        [TestCase(new int[] { 0, 1, 2, 4, 45, 231, -46 }, 3, 2, new int[] { 0, 1, 2, 231, -46 })]
        [TestCase(new int[] { 0 }, 0, 1, new int[] { })]
        [TestCase(new int[] { }, 0, 1, new int[] { })]
        public void RemoveTest(int[] array, int index, int quantity, int[] expected)
        {
            _list.Add(array);
            _list.Remove(index, quantity);

            Assert.AreEqual(expected, _list.Return());
        }

        [TestCase(new int[] { 0, 1, 4, 5 }, new int[] { 1, 4, 5 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 4 }, new int[] { })]
        public void RemoveFirstElementTest(int[] array, int[] expected)
        {
            _list.Add(array);
            _list.RemoveStart();

            Assert.AreEqual(expected, _list.Return());
        }

        [TestCase(new int[] { 0, 1, 4, 5 }, 3, new int[] { 5 })]
        [TestCase(new int[] { 0, 1, 4, 5, -99, 24, 65 }, 3, new int[] { 5, -99, 24, 65 })]
        [TestCase(new int[] { }, 1, new int[] { })]
        [TestCase(new int[] { 4 }, 1, new int[] { })]
        public void RemoveFirstElementTest(int[] array, int quantity, int[] expected)
        {
            _list.Add(array);
            _list.RemoveFirstElement(quantity);

            Assert.AreEqual(expected, _list.Return());
        }

        [TestCase(new int[] { 0, 1, 4, 5 }, 3, new int[] { 0 })]
        [TestCase(new int[] { 0, 1, 4, 5, -99, 24, 65 }, 3, new int[] { 0, 1, 4, 5 })]
        [TestCase(new int[] { 4 }, 1, new int[] { })]
        public void RemoveLastElementTest(int[] array, int quantity, int[] expected)
        {
            _list.Add(array);
            _list.RemoveLastElement(quantity);

            Assert.AreEqual(expected, _list.Return());
        }

        [TestCase(new int[] { }, 1)]
        public void RemoveLastElement_WhenQuantityIsBigger_ShouldException(int[] array, int quantity)
        {
            _list.Add(array);

            var ex = Assert.Throws<Exception>(() => _list.RemoveLastElement(quantity));

            Assert.That(ex.Message, Is.EqualTo("Quantity is bigger than length"));
        }

        [TestCase(new int[] { 0, 1, 9, 2, 4, 6 }, 2, 3)]
        [TestCase(new int[] { }, 2, -1)]
        [TestCase(new int[] { -231, -678, 789, 231 }, 111,  -1)]
        public void GetIndexTest(int[] array, int element, int expected)
        {
            _list.Add(array);
            int actual = _list.GetIndex(element);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 3, 123, 56, 79 }, new int[] { 79, 56, 123, 3, 2 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        [TestCase(new int[] { 1, 9 }, new int[] { 9, 1 })]
        public void ReversTest(int[] array, int[] expected)
        {
            _list.Add(array);
            _list.Reverse();

            Assert.AreEqual(expected, _list.Return());
        }

        [TestCase(new int[] { 3, 1, 6, 8, 89, 23, 111 },  1)]
        [TestCase(new int[] { -3, 1, -6, 8, -89, 23, 111, 0 },-89)]
        public void MinTest(int[] array, int expected)
        {
            _list.Add(array);
            int actual = _list.Min();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void Min_WhenArrayIsEmpty_ShouldException(int[] array)
        {
            _list.Add(array);
            int actual;

            var ex = Assert.Throws<Exception>(() => actual = _list.Min());

            Assert.That(ex.Message, Is.EqualTo("No elements in array"));
        }

        [TestCase(new int[] { 3, 1, 6, 8, 89, 23, 111 }, 111)]
        [TestCase(new int[] { -3, 1, -6, 8, -89, 23, 0 }, 23)]
        public void MaxTest(int[] array, int expected)
        {
            _list.Add(array);
            int actual = _list.Max();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void Max_WhenArrayIsEmpty_ShouldException(int[] array)
        {
            _list.Add(array);
            int actual;

            var ex = Assert.Throws<Exception>(() => actual = _list.Max());

            Assert.That(ex.Message, Is.EqualTo("No elements in array"));
        }

        [TestCase(new int[] { 3, 1, 6, 8, 89, 23, 111 }, new int[] { 1, 3, 6, 8, 23, 89, 111 })]
        [TestCase(new int[] { -3, 1, -6, 8, -89, 23, 0 }, new int[] { -89, -6, -3, 0, 1, 8, 23 })]
        [TestCase(new int[] { }, new int[] { })]
        public void SortArrayIncTest(int[] array, int[] expected)
        {
            _list.Add(array);
            _list.SortArrayInc();

            Assert.AreEqual(expected, _list.Return());
        }

        [TestCase(new int[] { 3, 1, 6, 8, 89, 23, 111 }, new int[] { 111, 89, 23, 8, 6, 3, 1 })]
        [TestCase(new int[] { -3, 1, -6, 8, -89, 23, 0 }, new int[] { 23, 8, 1, 0, -3, -6, -89 })]
        [TestCase(new int[] { }, new int[] { })]
        public void SortArrayDecTest(int[] array, int[] expected)
        {
            _list.Add(array);
            _list.SortArrayDec();

            Assert.AreEqual(expected, _list.Return());
        }

        [TestCase(new int[] { 3, 1, 6, 8, 89, 23, 111, 3, 67, 3 }, 3, new int[] { 1, 6, 8, 89, 23, 111, 67 })]
        [TestCase(new int[] { -3, 1, -6, 8, -89, 23, 0 }, -89, new int[] { -3, 1, -6, 8, 23, 0 })]
        [TestCase(new int[] { }, 0, new int[] { })]
        public void RemoveElementTest(int[] array, int element, int[] expected)
        {
            _list.Add(array);
            _list.RemoveElement(element);

            Assert.AreEqual(expected, _list.Return());
        }

        [TestCase(new int[] { 3, 1, 6, 8, 89, 23, 111, 3, 67, 3 }, 3, 8)]
        [TestCase(new int[] { -3, 1, -6, 8, -89, 23, 0 }, 5,  23)]
        public void GetElementTest(int[] array, int index, int expected)
        {
            _list.Add(array);

            Assert.AreEqual(expected, _list[index]);
        }

        [TestCase(new int[] { }, 0)]
        public void GetElement_WhenIndexIsOutOfRange_ShouldException(int[] array, int index)
        {
            _list.Add(array);
            int element;

            var ex = Assert.Throws<Exception>(() =>  element = _list[index]);

            Assert.That(ex.Message, Is.EqualTo("index out of range"));
        }

        [TestCase(new int[] { 3, 1, 6, 8, 89, 23, 111, 3, 67, 3 }, 3, 44, new int[] { 3, 1, 6, 44, 89, 23, 111, 3, 67, 3 })]
        [TestCase(new int[] { -3, 1, -6, 8, -89, 23, 0 }, 5, 111, new int[] { -3, 1, -6, 8, -89, 111, 0 })]
        [TestCase(new int[] { }, 0, 1, new int[] { })]
        public void SetElementTest(int[] array, int index, int num, int[] expected)
        {
            _list.Add(array);
            _list[index] = num;

            Assert.AreEqual(expected, _list.Return());
        }

        [TestCase(new int[] { 3, 1, 6, 8, 89, 23, 111, 3, 67, 3 }, 6)]
        [TestCase(new int[] { -3, 1, -6, 8, -89, 23, 0 }, 5)]
        public void GetMaxElementIndexTest(int[] array, int expected)
        {
            _list.Add(array);

            Assert.AreEqual(expected, _list.MaxElementIndex);
        }

        [TestCase(new int[] { })]
        public void GetMaxElementIndex_WhenArrayIsEmpty_ShouldException(int[] array)
        {
            _list.Add(array);
            int actual;

            var ex = Assert.Throws<Exception>(() => actual = _list.MaxElementIndex);

            Assert.That(ex.Message, Is.EqualTo("No elements in array"));
        }

        [TestCase(new int[] { 3, 1, 6, 8, 89, 23, 111, 3, 67, 3 }, 1)]
        [TestCase(new int[] { -3, 1, -6, 8, -89, 23, 0 }, 4)]
        public void GetMinElementIndexTest(int[] array, int expected)
        {
            _list.Add(array);

            Assert.AreEqual(expected, _list.MinElementIndex);
        }

        [TestCase(new int[] { })]
        public void GetMinElementIndex_WhenArrayIsEmpty_ShouldException(int[] array)
        {
            _list.Add(array);
            int actual;

            var ex = Assert.Throws<Exception>(() => actual = _list.MinElementIndex);

            Assert.That(ex.Message, Is.EqualTo("No elements in array"));
        }
    }
}