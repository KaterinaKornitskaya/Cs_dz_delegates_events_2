using System.Security.Cryptography.X509Certificates;

namespace task5
{
    // Задание 5
    // Создайте лямбда-выражение для отображения уникальных отрицательных
    // чисел в массиве. Напишите код для тестирования работы лямбды
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, -2, -2, -3, 4, -5, -6, 7, -8, -8 };
            Console.WriteLine("My arr: ");
            foreach(int item in arr)
                Console.Write(item + " ");

            Console.WriteLine("\nUnique negative elements: ");
            myDel(arr);
        }

        // лямбда выражение на основе стандартного делегата Action
        static Action<int[]> myDel = x =>
        {
            for(int i = 0; i < x.Length; i++)
            {
                // проверка - если первый и последний индексы вхождение элемента равны
                if(Array.IndexOf(x, x[i]) == Array.LastIndexOf(x, x[i]) 
                   && x[i] < 0)  // и если элемен меньше 0
                {
                    // значит эти элементы - уникальны и отрицательный, выводим в консоль
                    Console.Write(x[i] + " ");
                }
            }
        };
    }
}