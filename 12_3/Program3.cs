using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library_for_lab10;

namespace lab12
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            //дерево
            Tree<Tool> balancedTree = null;

            int answer = 1;
            while (answer != 6)
            {

                try
                {
                    PrintMenu();


                    answer = GetValidSizeFromInput();

                    switch (answer)
                    {
                        case 1:
                            Console.WriteLine("Cоздаём идеально сбалансированное бинарное дерево");
                            int size = GetValidSizeFromInput();
                            balancedTree = new Tree<Tool>(size);
                            Console.WriteLine("Дерево созданo");
                            break;

                        case 2:
                            balancedTree?.ShowTreeBeforeTransformation();

                            break;

                        case 3:
                            
                            int height = balancedTree.GetTreeHeight();
                            Console.WriteLine($"Высота дерева: {height}");
                            break;

                        case 4:
                            Console.WriteLine("Дерево до преобразования:");
                            balancedTree.ShowTreeBeforeTransformation();

                            Console.WriteLine("\nДерево после преобразования:");
                            balancedTree.ShowTreeAfterTransformation();
                            break;
                        case 5:
                            balancedTree = null;
                            Console.WriteLine("Дерево удалено из памяти.");
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
            Console.WriteLine("1. Задать количество элементов в дереве");
            Console.WriteLine("2. Вывод дерева на экран");
            Console.WriteLine("3. Найти высоту дерева");
            Console.WriteLine("4. Преобразовать идеально сбалансированное дерево в дерево поиска");
            Console.WriteLine("5. Удалить дерево из памяти");

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

    }
}
