namespace task6
{
    // Задание 6
    // Создайте лямбда-выражение для проверки есть ли в тексте заданное
    // слово. Напишите код для тестирования работы лямбды.
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "Hello my love";
            string str2 = "love";
            string str3 = "loves";
            Console.WriteLine($"Is string '{str1}' contains string '{str2}'?");
            Console.WriteLine(myDel(str1, str2));
            Console.WriteLine($"Is string '{str1}' contains string '{str3}'?");
            Console.WriteLine(myDel(str1, str3));
        }

        // объявление делегата типа MyDel, принимает два параметра типа
        // string и возвращает значение типа bool
        delegate bool MyDel(string s1,  string s2);

        // лямбда-выражение на основе делегата типа MyDel
        static MyDel myDel = (string s1, string s2) =>
        {
            if (s1.Contains(s2))  // если строка1 содержит строку2
                return true;      // то возвращаем truе
            return false;          
        };           
    }
}