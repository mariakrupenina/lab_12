using library_for_lab10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public class Tree<T> where T : IInit, IComparable, new()
    {
        Point<T>? root = null;
        int count = 0;
        public int Count => count;

        public Tree(int length)
        {
            count = length;
            root = MakeTree(length);
        }


        //public void ShowTree()
        //{
        //    if (root == null)
        //    {
        //        Console.WriteLine("Дерево пусто");
        //    }
        //    else
        //    {
        //        try
        //        {
        //            Show(root);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"Ошибка при выводе дерева: {ex.Message}");
        //        }
        //    }
        //}


        
        public void ShowTreeBeforeTransformation()
        {
            try
            {
                if (root == null)
                {
                    Console.WriteLine("Дерево пусто");
                }
                else
                {
                    Show(root);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Дерево пусто");
            }
        }

        public void ShowTreeAfterTransformation()
        {
            TransformToFindTree();
            Show(root);
        }

        //ИСД
        // Создание дерева с заданной длиной
        public Point<T>? MakeTree(int length)
        {
            if (length <= 0)
            {
                return null; // Дерево пусто, root остается null
            }

            T data = new T();
            data.RandomInit(); //создание узла дерева 
            Point<T> newItem = new Point<T>(data);

            int nl = length / 2;
            int nr = length - nl - 1;

            newItem.Left = MakeTree(nl);
            newItem.Right = MakeTree(nr);

            return newItem;
        }

        void TransformToArray(Point<T> point, T[] array, ref int current) //ref int current - переменная, которая отслеживает текущую позицию в массиве 
            //параметр ref int current используется для изменения значения
            //переменной current из вызывающего кода. Это позволяет методу изменять
            //значение current и влиять на переменную, которая была передана в метод как аргумент
        {
            if (point != null)
            {
                TransformToArray(point.Left, array, ref current);
                array[current++] = point.Data;
                TransformToArray(point.Right, array, ref current);
            }
        }

        public void TransformToFindTree()
        {
            if (root == null)
            {
                return;
            }

            T[] array = new T[count];
            int current = 0;
            TransformToArray(root, array, ref current);
            root = null; //Обнуляем текущее дерево

            //Пересоздаём дерево на основе  массива
            foreach (var item in array)
            {
                AddPoint(item); //Добавляем элемент в дерево
            }
        }

        void Show(Point<T>? point, int spaces = 10)
        {
            if (point != null)
            {
                Show(point.Left, spaces + 10); //Рекурсивно выводим левое поддерево

                //Выводим текущий узел с отступами
                for (int i = 0; i < spaces; i++)
                    Console.Write(" ");
                Console.WriteLine(point.Data);

                Show(point.Right, spaces + 10); //Рекурсивно выводим правое поддерево
            }
        }

        //void Show(Point<T>? point, int level = 0)
        //{
        //    if (point != null)
        //    {
        //        Show(point.Right, level + 1); //Рекурсивно выводим правое поддерево, увеличивая уровень

        //        //Выводим текущий узел с отступами, зависящими от уровня
        //        Console.WriteLine($"{new string(' ', level * 4)}{point.Data}");

        //        Show(point.Left, level + 1); //Рекурсивно выводим левое поддерево, увеличивая уровень
        //    }
        //}

        //Добавление нового элемента в дерево поиска
        public void AddPoint(T data)
        {
            Point<T>? newNode = new Point<T>(data);

            if (root == null)
            {
                //Дерево пустое, новый элемент становится корнем
                root = newNode;
                count++;
                return;
            }

            Point<T>? current = root;
            Point<T>? parent = null;

            while (current != null)
            {
                parent = current;

                //Сравниваем новый элемент с текущим узлом
                int comparison = data.CompareTo(current.Data);

                if (comparison == 0)
                {
                    // Элемент уже существует, не добавляем дубликат
                    return;
                }
                else if (comparison < 0)
                {
                    //Новый элемент меньше текущего, двигаемся влево
                    current = current.Left;
                }
                else
                {
                    //Новый элемент больше текущего, двигаемся вправо
                    current = current.Right;
                }
            }

            //Добавляем новый элемент в дерево
            int compareWithParent = data.CompareTo(parent!.Data);

            if (compareWithParent < 0)
            {
                parent.Left = newNode;
            }
            else
            {
                parent.Right = newNode;
            }

            count++;
        }


        //Рекурсивный метод для определения высоты дерева
        public int GetTreeHeight()
        {
            return CalculateTreeHeight(root);
        }

        //Вспомогательный рекурсивный метод для расчёта высоты дерева
        private int CalculateTreeHeight(Point<T>? node)
        {
            if (node == null)
                return 0;

            //Рекурсивно находим высоты левого и правого поддеревьев
            int leftHeight = CalculateTreeHeight(node.Left);
            int rightHeight = CalculateTreeHeight(node.Right);

            //Высота дерева равна максимальной высоте из левого и правого поддеревьев плюс один (для текущего узла)
            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}
