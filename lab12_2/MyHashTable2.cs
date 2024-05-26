using library_for_lab10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public class MyHashTable2<T> where T: Tool, IInit, IComparable, new()
    {
        T[] table; // таблица
        int count = 0; //количсетво записей
        double fillRatio = 0; //коэффициент заполняемости таблицы

        public int Capacity => table.Length; //ёмкость, количество выделенной памяти
        public int Count => count; //текущее количество жлементов

        //конструктор
        public MyHashTable2(int size = 10, double fillRatio = 0.72)
        {
            table = new T[size];
            this.fillRatio = fillRatio;
        }

        public bool Contains(T data)
        {
            int index = FindItem(data);
            if (index < 0) return false;
            count--;
            table[index] = default;
            return true;
        }

        public void PrintH()
        {
            bool isEmpty = true;

            foreach (T item in table)
            {
                if (item != null)
                {
                    isEmpty = false;
                    break;
                }
            }

            if (isEmpty)
            {
                Console.WriteLine("Таблица пустая \n");
            }
            else
            {
                int i = 0;
                Console.WriteLine();
                Console.WriteLine("        ХЕШ ТАБЛИЦА: \n");
                foreach (T item in table)
                {
                    if (item != null)
                    {
                        Console.WriteLine($"{i + 1}:   {item}");
                        i++;
                    }
                }
                Console.WriteLine();
            }
        }

        public void PrintT()
        {
            int i = 0;
            foreach (T item in table)
            {
                Console.WriteLine($"{i+1}: {item}");
                i++;
            }
        }


        public void AddItem(T item)
        {
            if ((double)Count / Capacity > fillRatio) // Проверяем заполненность таблицы
            {
                //Увеличиваем таблицу в 2 раза
                T[] temp = table; // Сохраняем текущую таблицу
                table = new T[temp.Length * 2]; // Создаем новую увеличенную таблицу
                count = 0; // Сбрасываем счетчик элементов

                //Переписываем все существующие элементы в новую таблицу
                foreach (T existingItem in temp)
                {
                    if (existingItem != null)
                    {
                        AddData(existingItem); // Добавляем существующий элемент в новую таблицу
                    }
                }
            }

            // Добавляем новый элемент в таблицу
            AddData(item);
        }

        //добавление элемента в таблицу(првиат)
        void AddData(T data)
        {
            if (data == null) return; //доб-ся пустой элемент
            //ищем место
            int index = GetIndex(data);
            int current = index; //запомнили индекс
            //уже занято
            if (table[index] != null)
            {
                //идём до конца таблицы или до перовго пустого места
                while (current < table.Length && table[current] != null)
                    current++;
                //если таблица закончилась
                if (current == table.Length)
                {
                    //идём от начала таблицы до ииндекса который запомнили
                    current = 0;
                    while (current < index && table[current] != null)
                        current++;
                    //места нет
                    if (current == index)
                    {
                        throw new Exception("Нет места в таблице");
                    }
                }
            }

            //место найдено
            table[current] = data;
            count++;
        }

        int GetIndex(T data)
        {
            return Math.Abs(data.GetHashCode()) % Capacity;
        }

        public bool RemoveItem(T data, bool retrySearch = false)
        {
            int index = FindItem(data);
            if (index != -1)
            {
                //нашли элемент, удаляем его
                table[index] = default; //Устанавливаем значение по умолчанию (null) для освобождения ячейки
                count--;
                return true;
            }

            //Элемент не найден
            if (retrySearch)
            {
                //Если задан флаг retrySearch, попробуем найти элемент перебором
                index = 0;
                while (index < table.Length)
                {
                    if (table[index] != null && table[index].Equals(data))
                    {
                        //Нашли элемент, удаляем его
                        table[index] = default;
                        count--;
                        return true;
                    }
                    index++;
                }
            }

            //Элемент не найден и не удален
            return false;
        }

        public int FindItem(T data)
        {
            int index = GetIndex(data);

            //нет элемента
            if (table[index] == null) return -1;

            //есть элемент
            if (table[index].Equals(data)) return index;
            else
            {
                int current = index; 
                while (current < table.Length)
                {
                    if (table[current] != null && table[current].Equals(data)) return current; 
                    
                    current++;
                }
                current = 0;
                while(current < index)
                {
                    if (table[current] != null && table[current].Equals(data))
                        return current;
                    current++;
                }
            }

            //не нашли
            return -1;
        }

        //ДЛЯ ДЕМОНСТРАЦИИ ЁМКОСТИ!!!!!!!!!!!!
        void AddData3(T data)
        {
            int index = GetIndex(data);

            // Ищем первое пустое место для добавления элемента
            while (table[index] != null)
            {
                index = (index + 1) % Capacity; //Пробуем следующий индекс
            }

            table[index] = data; //Добавляем элемент по найденному индексу
            count++;
        }

        public void AddItem3(T item)
        {
            if (((double)(Count + 1) / Capacity) > fillRatio)
            {
                //Увеличиваем ёмкость таблицы в 2 раза
                ResizeTable3();
                //После увеличения ёмкости нужно заново вычислить индекс для добавления элемента
                AddData3(item);
            }
            else
            {
                //Добавляем элемент без увеличения ёмкости
                AddData3(item);
            }
        }

        void ResizeTable3()
        {
            T[] oldTable = table;
            table = new T[oldTable.Length * 2]; // Увеличиваем ёмкость в 2 раза
            count = 0;
            foreach (T item in oldTable)
            {
                if (item != null)
                {
                    AddData3(item);
                }
            }
        }

        //Метод для формирования хеш-таблицы из элементов библиотеки
        public void GenerateFromLibrary(int size)
        {
            for (int i = 0; i < size; i++)
            {
                T newItem = new T();
                newItem.RandomInit();
                AddItem3(newItem); // Добавляем элемент в хеш-таблицу
            }
        }

    }
}
