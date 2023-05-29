namespace task3
{
    // Задание 3
    // Создайте лямбда-выражение для подсчёта количества чисел в массиве,
    // кратных семи. Напишите код для тестирования работы лямбды.

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 5, 7, 8, 9, 14, 15, 28 };
            Console.Write("My Array: ");
            foreach (int x in arr)
                Console.Write(x + " ");

            // способ 1
            Console.WriteLine("\nКол-во чисел, кратных 7: " + myDel(arr));
            // способ 2
            Console.WriteLine("\nКол-во чисел, кратных 7: " + myDel2(arr));
            // способ 3
            Console.WriteLine("\nКол-во чисел, кратных 7: " 
                + MyFun(arr, x => x % 7 == 0));
        }

        // объявление делегата
        delegate int MyDel(int[] x);
        // 1ый способ - создание лямбда-выражения на основе делегата типа MyDel
        static MyDel myDel = x =>
        {
            int count = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] % 7 == 0)
                    count++;
            }
            return count;
        };

        // 2ой способ - создание лямбда-выражения на основе стандартного делегата Func
        static Func<int[], int> myDel2 = x =>
        {
            int count = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] % 7 == 0)
                    count++;
            }
            return count;
        };

        // 3ий способ - использования лямбда-выражение как параметра метода
        static int MyFun(int[] arr, Predicate<int> predicate)
        {
            int count = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if (predicate(arr[i]))
                    count++;
            }
            return count;
        }
    }  
}