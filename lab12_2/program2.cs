using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library_for_lab10;

namespace lab12
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            //табличка
            MyHashTable2<Tool> hashTable = new MyHashTable2<Tool>();

            int answer = 1;
            while (answer != 5)
            {

                try
                {
                    PrintMenu();

                    
                    answer = GetValidSizeFromInput();

                    switch (answer)
                    {
                        case 1:
                            Console.WriteLine("создаём таблицу");
                            int size = GetValidSizeFromInput();
                            hashTable.GenerateFromLibrary(size); 
                            Console.WriteLine("Таблица создана");
                            break;

                        case 2:
                            hashTable.PrintT();

                            break;

                        case 3:
                            Console.WriteLine("Введите элемент для поиска:");
                            Tool toolFind = new Tool();
                            toolFind.Init();

                            int index = hashTable.FindItem(toolFind);
                            if (index != -1)
                            {
                                Console.WriteLine($"Элемент '{toolFind}' найден на позиции {index + 1} в таблице\n");
                            }
                            else
                            {
                                Console.WriteLine($"Элемент '{toolFind}' не найден в таблице\n");
                            }
                            break;

                        case 4:
                            Console.WriteLine("Введите информационное поле элемента для удаления:");
                            Tool toolRemove = new Tool();
                            toolRemove.Init();

                            bool removed = hashTable.RemoveItem(toolRemove, false);
                            if (removed)
                            {
                                Console.WriteLine($"Элемент '{toolRemove}' удален из таблицы\n");
                                Console.WriteLine("Таблица после удаления: ");
                                hashTable.PrintT();
                            }
                            else
                            {
                                Console.WriteLine($"Элемент '{toolRemove}' не найден в таблице\n");
                            }
                            break;
                        case 5:
                            MyHashTable2<Tool> hashTable1 = new MyHashTable2<Tool>(10, 0.72);
                            hashTable1.GenerateFromLibrary(7); // Заполним таблицу 7 элементами (меньше 72% от ёмкости)
                            PrintTableInfo(hashTable1); // Выведем информацию о таблице

                            Tool newTool = new Tool();
                            newTool.RandomInit();

                            Console.WriteLine($"Новый элемент: {newTool}");
                            hashTable1.AddItem3(newTool); // Попытка добавления нового элемента

                            PrintTableInfo(hashTable1); // Выведем информацию о таблице после добавления

                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine("1. Задать количество элементов в таблице");
            Console.WriteLine("2. Вывод таблицы на экран");
            Console.WriteLine("3. Поиск элемент в таблице");
            Console.WriteLine("4. Удалить найденный элемент из хеш-таблицы");
            Console.WriteLine("5. Показать, что будет при добавлении элемента в хеш-таблицу, если " +
                "в таблице уже находится максимальное число элементов");
            Console.WriteLine();

        }
        public static int GetValidSizeFromInput()
        {
            int choice;
            bool isConvert;
            do
            {
                Console.WriteLine("Введите число: \n");
                string buf = Console.ReadLine();
                isConvert = int.TryParse(buf, out choice);
                if (!isConvert || choice <= 0)
                {
                    Console.WriteLine("неправильно введено число. \nПопробуйте ещё раз.");
                }
            } while (!isConvert);

            return choice;
        }

        public static void PrintTableInfo(MyHashTable2<Tool> hashTable)
        {
            hashTable.PrintT(); // Вывод текущего состояния таблицы
            Console.WriteLine($"Ёмкость таблицы: {hashTable.Capacity}");
            Console.WriteLine($"Количество элементов: {hashTable.Count}");

        }

    }
}
