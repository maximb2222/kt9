using System;
using System.Collections.Generic;

namespace GenericTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите задание (1-3):");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Task1();
                    break;
                case "2":
                    Task2();
                    break;
                case "3":
                    Task3();
                    break;
                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
        }

        static void Task1()
        {
            var stack = new Stack<int>();
            stack.Push(10);
            stack.Push(30);
            stack.Push(20);

            Console.WriteLine($"Максимальный элемент: {stack.Max()}");
        }

        class Stack<T> where T : IComparable<T>
        {
            private List<T> _items = new List<T>();

            public void Push(T item)
            {
                _items.Add(item);
            }

            public T Pop()
            {
                if (_items.Count == 0)
                    throw new InvalidOperationException("Стек пуст.");
                var item = _items[^1];
                _items.RemoveAt(_items.Count - 1);
                return item;
            }

            public T Max()
            {
                if (_items.Count == 0)
                    throw new InvalidOperationException("Стек пуст.");
                T max = _items[0];
                foreach (var item in _items)
                {
                    if (item.CompareTo(max) > 0)
                        max = item;
                }
                return max;
            }
        }


        static void Task2()
        {

            var pair = new Pair<string, string>("Первое", "Второе");
            Console.WriteLine($"До swap: {pair.First}, {pair.Second}");
            pair.Swap();
            Console.WriteLine($"После swap: {pair.First}, {pair.Second}");
        }

        public class Pair<T, U> where T : class where U : class
        {
            public T First { get; set; }
            public U Second { get; set; }

            public Pair(T first, U second)
            {
                First = first;
                Second = second;
            }

            public void Swap()
            {
                var temp = First;
                First = (T)(object)Second;
                Second = (U)(object)temp;
            }

        }

        static void Task3()
        {

            var result = Calculator<int>.Add(5, 10);
            Console.WriteLine($"Сумма: {result}");

            var zero = Calculator<int>.Zero();
            Console.WriteLine($"Нулевое значение: {zero}");
        }
    }

    class Calculator<T> where T : new()
    {
        public static T Add(T x, T y)
        {
            dynamic dx = x, dy = y;
            return (T)(dx + dy);
        }

        public static T Zero()
        {
            return new T();
        }
    }
}
