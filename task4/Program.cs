using System.Security.Cryptography.X509Certificates;

namespace task4
{
    // Задание 4
    // Создайте лямбда-выражение для подсчёта количества положительных чисел
    // в массиве. Напишите код для тестирования работы лямбды.

    // объявление делегата, который принимает массив интов и возвращает инт
    delegate int MyPositiveDel (int[] x);
    // объявлени еделегата, который принимает инт и возвращает true/false
    delegate bool MyPositiveDel2(int x);
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, -3, 4, 5, -6, 7, -8, 9, 14, 28 };
            ShowArray(arr);

            // способ 1
            Console.WriteLine("\nNumber of positive elements in my array: " 
                + MyPositive(arr));
            // способ 2
            Console.WriteLine("\nNumber of positive elements in my array: "
                 + MyPositive2(arr));
            // способ 3
            Console.WriteLine("\nNumber of positive elements in my array: "
                + MyPositiveFunc(arr, x => x > 0));
            // способ 4
            Console.WriteLine("\nNumber of positive elements in my array: "
                + MyPositiveFunc2(arr, x => x > 0));
        }

        // 1ый способ - лямбда-выражение для подсчета положительных значений
        // массива на основе делегата типа MyPositiveDel
        static MyPositiveDel MyPositive = (x) =>
        {
            int countPositive = 0;
            foreach (var item in x)
            {
                if (item > 0)
                    countPositive++;
            }
            return countPositive;
        };

        // 2ой способ - лямбда-выражение на основе стандартного делегата Func
        static Func<int[], int> MyPositive2 = x =>
        {
            int countPositive = 0;
            foreach (int item in x)
            {
                if (item > 0)
                    countPositive++;
            }
            return countPositive;
        };

        // 3ий способ - использование лямбды как параметра
        static int MyPositiveFunc(int[] arr, MyPositiveDel2 MyFun)
        {
            int countPositive = 0;
            foreach (int item in arr)
            {
                if (MyFun(item))  // если условие MyFun true (условие передадим в main)
                    countPositive ++;  // то плюсуем счетчик
            }
            return countPositive;
        }

        // 4ый способ - использование лямбды как параметра, использование
        // стандартного делегата Predicate
        static int MyPositiveFunc2(int[] arr, Predicate<int> pred)
        {
            int countPositive = 0;
            foreach (int item in arr)
            {
                if(pred(item))
                    countPositive++;
            }
            return countPositive;
        }

        // метод для вывода массива в консоль
        static void ShowArray(int[] arr)
        {
            Console.WriteLine("My array: ");
            foreach (int item in arr)
                Console.Write(item + " ");
        }
    }
}