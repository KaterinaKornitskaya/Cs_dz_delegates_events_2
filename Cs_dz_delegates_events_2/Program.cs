using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace Cs_dz_delegates_events_2
{
    // Задание 1
    // Создайте анонимный метод для получения RGB значения для цвета радуги.
    // Цвет радуги передаётся в качестве параметра. Напишите код для
    // тестирования работы метода.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RainbowFunc("Red"));  // переведет в нижний регистр, есть цвет
            Console.WriteLine("----------------------------");

            Console.WriteLine(RainbowFunc("aqua"));  // есть цвет
            Console.WriteLine("----------------------------");

            Console.WriteLine(RainbowFunc("gree"));  // нет такого цвета

        }

        // анонимный метод на основе стандартного делегата Func
        static Func<string, (int, int, int)> RainbowFunc = delegate (string color)
        {
            switch(color.ToLower())  // переводим в нижний регистр, в зависимости от цвета типа string
            {                        // возвращаем (int, int, int)
                case "red":
                    ShowMessage(color);
                    return (255, 0, 0);
                case "orange":
                    ShowMessage(color);
                    return (255, 140, 0);
                case "yellow":
                    ShowMessage(color);
                    return (255, 255, 0);
                case "green":
                    ShowMessage(color);
                    return (0, 128, 0);
                case "aqua":
                    ShowMessage(color);
                    return (0, 255, 255);
                case "blue":
                    ShowMessage(color);
                    return (0, 0, 255);
                case "purple":
                    ShowMessage(color);
                    return (128, 0, 128);
            }
            Console.WriteLine($"Ошибка: нет цвета {color.ToLower()}");
            return (-1, -1, -1);          
        };

        static void ShowMessage(string color)  // метод для вывода повторяющегося сообщения о цвете
        {
            Console.WriteLine($"Цвет {color.ToLower()}, значение в RGB: ");
        }
    }
}