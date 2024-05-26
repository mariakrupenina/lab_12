using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library_for_lab10;

namespace Collection_list
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("                 Создание коллекций                \n ");

            //Пустая
            Console.WriteLine("Пустая коллекция:");
            MyCollection<Tool> emptyCollection = new MyCollection<Tool>();
            foreach (Tool t in emptyCollection)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();

            //Из 5 случайных элементов
            Console.WriteLine("Коллекция из 5 элементов");
            MyCollection<Tool> randomCollection = new MyCollection<Tool>(5);
            foreach (Tool t in randomCollection)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();

            //На основе существующей коллекции
            Console.WriteLine("Копия коллекции:");
            MyCollection<Tool> copiedCollection = new MyCollection<Tool>(randomCollection);
            foreach (Tool t in copiedCollection)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();






            // Демонстрация методов работы с коллекцией
            Console.WriteLine("\n                 Демонстрация методов работы с коллекцией:");

            // Добавление элемента в начало коллекции
            Tool newTool = new Tool(); // создаем новый инструмент
            newTool.RandomInit();      // инициализируем случайными данными
            copiedCollection.AddToBegin(newTool);
            Console.WriteLine("\nДобавление элемента в начало:");
            foreach (Tool t in copiedCollection)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();

            // Добавление элемента в конец коллекции
            Tool anotherTool = new Tool();
            anotherTool.RandomInit();     
            copiedCollection.AddToEnd(anotherTool);
            Console.WriteLine("\nДобавление элемента в конец:");
            foreach (Tool t in copiedCollection)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();

            // Удаление элемента по индексу
            Console.WriteLine("Удаление элемента по индексу:");
            Console.WriteLine("Введите индекс: ");
            int indexToRemove = int.Parse(Console.ReadLine()) - 1;

            try
            {
                copiedCollection.RemoveAt(indexToRemove);
                Console.WriteLine($"\nУдаление элемента по индексу {indexToRemove}:");
                foreach (Tool t in copiedCollection)
                {
                    Console.WriteLine(t);
                }
                Console.WriteLine();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Очистка коллекции
            copiedCollection.Clear();
            Console.WriteLine("\nКоллекция после очистки:");
            foreach (Tool t in copiedCollection)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();


        }


    }
}
