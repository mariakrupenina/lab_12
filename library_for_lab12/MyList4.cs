using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library_for_lab10;

namespace library_for_lab12
{
    internal class MyList4<T> : IList<T> where T : IInit, ICloneable, new()
    {
        public Point<T>? beg = null;
        public Point<T>? end = null;

        protected int count = 0;

        public int Count => count;
        public bool IsReadOnly => false;

        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MyList4() { } //Создание пустой коллекции

        public MyList4(int size) : this()
        {
            if (size <= 0)
                throw new Exception("размер меньше нуля");
            beg = MakeRandomData();
            end = beg;
            for (int i = 1; i < size; i++)
            {
                T newItem = MakeRandomItem();
                AddToEnd(newItem);
            }
            count = size;
        }

        public MyList4(MyList4<T> c) : this()
        {
            foreach (T item in c)
            {
                AddToEnd((T)item.Clone());
            }
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (index == count)
            {
                AddToEnd(item);
                return;
            }

            Point<T>? current = beg;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            Point<T>? newNode = new Point<T>(item);
            newNode.Next = current;
            newNode.Pred = current.Pred;

            if (current.Pred != null)
                current.Pred.Next = newNode;
            current.Pred = newNode;

            if (current == beg)
                beg = newNode;

            count++;
        }


        public MyList4(T[] collection)
        {
            if (collection == null) throw new Exception("пустая коллекция(null)");
            if (collection.Length == 0) throw new Exception("пустая коллекция");
            T newData = (T)collection[0].Clone();
            beg = new Point<T>(newData);
            end = beg;
            for (int i = 1; i < collection.Length; i++)
            {
                AddToEnd(collection[i]);
            }
        }

        public Point<T> MakeRandomData()
        {
            T data = new T();
            data.RandomInit();
            return new Point<T>(data);
        }

        public T MakeRandomItem()
        {
            T data = new T();
            data.RandomInit();
            return data;
        }

        public void AddToBegin(T item)
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (beg != null)
            {
                beg.Pred = newItem;
                newItem.Next = beg;
                beg = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public void AddToEnd(T item)
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (end != null)
            {
                end.Next = newItem;
                newItem.Pred = end;
                end = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public void PrintList()
        {
            if (count == 0) Console.WriteLine("лист пустой");
            Point<T>? current = beg;
            for (int i = 0; current != null; i++)
            {
                Console.WriteLine(current);
                current = current.Next;
            }
            Console.WriteLine();
        }

        public Point<T>? FindItem(T item)
        {
            Point<T>? current = beg;
            while (current != null)
            {
                if (current.Data == null) throw new Exception("данные равню нулю");
                if (current.Data.Equals(item)) return current;
                current = current.Next;
            }
            return null;
        }



        //
        public bool RemoveItem(T item)
        {
            if (beg == null) throw new Exception("лист пустой");
            Point<T>? pos = FindItem(item);
            if (pos == null) return false;
            count--;
            //1 элемент
            if (beg == end)
            {
                beg = end = null;
                return true;
            }
            //первый
            if (pos.Pred == null)
            {
                beg = beg?.Next;
                beg.Pred = null;
                return true;
            }
            //последний
            if (pos.Next == null)
            {
                end = end.Pred;
                end.Next = null;
                return true;
            }
            Point<T> next = pos.Next;
            Point<T> pred = pos.Pred;
            pos.Next.Pred = pred;
            pos.Pred.Next = next;
            return true;
        }

        public bool Remove(T item)
        {
            Point<T>? current = beg;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    if (current.Pred != null)
                        current.Pred.Next = current.Next;
                    if (current.Next != null)
                        current.Next.Pred = current.Pred;

                    if (current == beg)
                        beg = current.Next;
                    if (current == end)
                        end = current.Pred;

                    count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Clear()
        {
            beg = null;
            end = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            Point<T>? current = beg;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0 || arrayIndex + count > array.Length)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            Point<T>? current = beg;
            while (current != null)
            {
                array[arrayIndex++] = current.Data;
                current = current.Next;
            }
        }

        public int IndexOf(T item)
        {
            Point<T>? current = beg;
            int index = 0;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                    return index;
                current = current.Next;
                index++;
            }
            return -1;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс находится вне диапазона!!!!!!!");

            Point<T>? current = beg;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            if (current.Pred != null)
                current.Pred.Next = current.Next;
            if (current.Next != null)
                current.Next.Pred = current.Pred;

            if (current == beg)
                beg = current.Next;
            if (current == end)
                end = current.Pred;

            count--;
        }

        public void Add(T item)
        {
            AddToEnd((T)item.Clone());
        }

        public IEnumerator<T> GetEnumerator()
        {
            Point<T>? current = beg;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
