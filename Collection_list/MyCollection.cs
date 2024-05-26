using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab12;
using library_for_lab10;

namespace Collection_list
{
    internal class MyCollection<T>: MyList4<T>, IEnumerable<T> where T : IInit, ICloneable, new()
    {
        public MyCollection() : base()
        {
            //Этот конструктор вызывает конструктор базового класса MyList4<T>() для создания пустой коллекции
        }

        public MyCollection(int size) : base(size)
        {
            //Этот конструктор вызывает конструктор базового класса MyList4<T>(int size)
        }

        public MyCollection(MyCollection<T> c) : base(c)
        {
            //Этот конструктор вызывает конструктор базового класса MyList4<T>(MyCollection<T> c),который инициализирует коллекцию элементами и емкостью коллекции c
        }
        public MyCollection(T[] collection) : base(collection) { }

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
            throw new NotImplementedException();
        }
    }

    internal class MyEnumerator<T> : IEnumerator<T> where T : IInit, ICloneable, new()
    {
        Point<T>? beg;
        Point<T>? current;

        public MyEnumerator(MyCollection<T> collection)
        {
            beg = collection.beg;
            current = beg;
        }

        public T Current => current.Data;
       
        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            
        }

        
        public bool MoveNext()//двигаемся по коллекции
        {
            if(current.Next==null)
            {
                Reset();//в начало
                return false;
            }
            else
            {
                current = current.Next;
                return true;
            }
        }

        public void Reset()
        {
            current = beg;
        }
    }
}
