using System;
using System.Collections.Generic;

namespace ArrayList
{
    public class ArrayList<T> where T : IEquatable<T>
    {
        private T[] _array;
        private int _length;

        public ArrayList()
        {
            _array = new T[0];
            _length = 0;
        }

        public ArrayList(T a)
        {
            _array = new T[1];
            _array[0] = a;
            _length = 1;
        }
        public ArrayList(T[] array)
        {
            _array = array;
            _length = array.Length;
        }


        public T this[int i]
        {
            get
            {
                if (_length > i)
                    return _array[i];
                throw new Exception("index out of range");
            }
            set
            {
                if (_length > i)
                    _array[i] = value;
            }
        }

        public int Length
        {
            get => _length;
        }

        public int MaxElementIndex
        {
            get
            {
                int index = GetIndex(Max());

                return index;
            }
        }

        public int MinElementIndex
        {
            get
            {
                int index = GetIndex(Min());

                return index;
            }
        }

        public void Add(ArrayList<T> a)
        {
            while (_length + a.Length > _array.Length)
            {
                UpArraySize();
            }

            for (int i = 0; i < a.Length; i++)
            {
                _array[_length + i] = a[i];
            }

            _length += a.Length;
        }

        public void AddToStart(ArrayList<T> a)
        {
            MoveArrayElementsToRight(0, a);
            for (int i = 0; i < a.Length; i++)
            {
                _array[i] = a[i];
            }

            _length += a.Length;
        }

        public void Add(int index, ArrayList<T> a)
        {
            if (index < _length)
            {
                MoveArrayElementsToRight(index, a);
                for (int i = 0; i < a.Length; i++)
                    _array[index + i] = a[i];

                _length += a.Length;
            }
        }

        public void Add(T[] a)
        {
            while (_length + a.Length > _array.Length)
            {
                UpArraySize();
            }

            for (int i = 0; i < a.Length; i++)
            {
                _array[_length + i] = a[i];
            }

            _length += a.Length;
        }

        public void Add(T element)
        {
            if (_length >= _array.Length)
            {
                UpArraySize();
            }

            _array[_length] = element;
            _length++;

        }

        public void AddToStart(T element)
        {
            MoveToRight(0);
            _array[0] = element;
            _length++;
        }

        public void Add(int index, T element)
        {
            MoveToRight(index);
            _array[index] = element;
            _length++;
        }

        public void Remove()
        {
            if (_length != 0)
            {
                _length--;
            }

            if (_length + _length * 0.3 + 1 < _array.Length)
            {
                DownArraySize();
            }
        }

        public void RemoveStart()
        {
            for (int i = 0; i < _length - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            if (_length != 0)
                _length--;

            if (_length + _length * .3 + 1 < _array.Length)
                DownArraySize();
        }

        public void Remove(int index)
        {
            if (index < 0)
            {
                throw new Exception("Incorrect index");
            }

            if (_length > 1)
            {
                for (int i = index; i < _length - 1; i++)
                {
                    _array[i] = _array[i + 1];
                }
            }

            if (_length != 0)
                _length--;

            if (_length + _length * 0.3 + 1 < _array.Length)
                DownArraySize();
        }

        public void RemoveLastElement(int quantity)
        {
            _length -= quantity;

            if (_length < 0)
            {
                throw new Exception("Quantity is bigger than length");
            }
            if (_length + _length * 0.3 + 1 < _array.Length)
                DownArraySize();
        }

        public void RemoveFirstElement(int quantity)
        {
            if (_length > 1)
            {
                if (_length > quantity)
                {
                    for (int i = 0; i < _length - quantity; i++)
                    {
                        _array[i] = _array[i + quantity];
                    }
                }

                _length -= quantity;
            }
            else
            {
                _length = 0;
            }

            if (_length + _length * .3 + 1 < _array.Length)
                DownArraySize();
        }
        public void Remove(int index, int quantity)
        {
            if (_length > 1)
            {
                if (_length - index > quantity)
                {
                    for (int i = index; i < _length - quantity; i++)
                    {
                        _array[i] = _array[i + quantity];
                    }
                }

                _length -= quantity;
            }
            else
            {
                _length = 0;
            }

            if (_length + _length * .3 + 1 < _array.Length)
                DownArraySize();
        }

        public int GetIndex(T element)
        {
            for (int i = 0; i < _length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_array[i], element))
                    return i;
            }

            return -1;
        }

        public void Reverse()
        {
            for (int i = 0; i < _length / 2; i++)
            {
                T tmp = _array[i];
                _array[i] = _array[_length - i - 1];
                _array[_length - i - 1] = tmp;
            }
        }

        public T Max()
        {
            T max;
            var comparer = Comparer<T>.Default;

            if (_length != 0)
            {
                max = _array[0];
                for (int i = 1; i < _length; i++)
                {
                    if (comparer.Compare(_array[i], max) > 0)
                    {
                        max = _array[i];
                    }
                }
            }
            else
                throw new Exception("No elements in array");

            return max;
        }

        public T Min()
        {
            T min;
            var comparer = Comparer<T>.Default;

            if (_length != 0)
            {
                min = _array[0];
                for (int i = 1; i < _length; i++)
                {
                    if (comparer.Compare(_array[i], min) < 0)
                    {
                        min = _array[i];
                    }
                }
            }
            else
                throw new Exception("No elements in array");

            return min;
        }

        public void SortArrayInc()
        {
            var comparer = Comparer<T>.Default;
            for (int i = 0; i < _length - 1; i++)
            {
                for (int j = 0; j < _length - 1 - i; j++)
                {
                    if (comparer.Compare(_array[j],  _array[j + 1]) > 0)
                    {
                        T temp = _array[j];
                        _array[j] = _array[j + 1];
                        _array[j + 1] = temp;
                    }
                }
            }
        }

        public void SortArrayDec()
        {
            var comparer = Comparer<T>.Default;
            for (int i = 0; i < _length - 1; i++)
            {
                for (int j = 0; j < _length - 1 - i; j++)
                {
                    if (comparer.Compare(_array[j], _array[j + 1]) < 0)
                    {
                        T temp = _array[j];
                        _array[j] = _array[j + 1];
                        _array[j + 1] = temp;
                    }
                }
            }
        }

        public void RemoveElement(T a)
        {
            for (int i = 0; i < _length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_array[i], a))
                    Remove(i);
            }
        }

        public T[] Return()
        {
            T[] arrayForReturn = new T[_length];
            for (int i = 0; i < arrayForReturn.Length; i++)
            {
                arrayForReturn[i] = _array[i];
            }

            return arrayForReturn;
        }

        private void DownArraySize()
        {
            int newLength = Convert.ToInt32(_array.Length * 0.7);
            T[] newArray = _array;
            _array = new T[newLength];

            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = newArray[i];
            }

        }
        
        private void MoveToRight(int a)
        {
            if (_length >= _array.Length)
            {
                UpArraySize();
            }

            for (int i = _length - 1; i >= a; i--)
            {
                _array[i + 1] = _array[i];
            }
        }

        private void UpArraySize()
        {
            int newLength = Convert.ToInt32(_array.Length * 1.3 + 1);
            T[] newArray = new T[newLength];

            for (int i = 0; i < _array.Length; i++)
            {
                newArray[i] = _array[i];
            }

            _array = newArray;
        }

        private void MoveArrayElementsToRight(int index, ArrayList<T> arr)
        {
            while (_length + arr.Length > _array.Length)
            {
                UpArraySize();
            }
            int shift = arr.Length;

            for (int i = _length - 1; i >= index; i--)
            {
               _array[i + shift] = _array[i];
            }

        }
    }
}
