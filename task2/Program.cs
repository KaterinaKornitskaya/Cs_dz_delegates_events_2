using System.Xml.Linq;

namespace task2
{
 // Задание 2
 // Создайте класс рюкзак. Характеристики рюкзака:
 // ■ Цвет рюкзака;
 // ■ Фирма производитель;
 // ■ Ткань рюкзака;
 // ■ Вес рюкзака;
 // ■ Объём рюкзака;
 // ■ Содержимое рюкзака(список объектов, у каждого объекта кроме названия
 // нужно учитывать занимаемый объём).
 // Создайте методы для заполнения характеристик.
 // Создайте событие для добавления объекта в рюкзак.
 // Реализуйте анонимный метод в качестве обработчика события добавления
 // объекта. Если при попытке добавления может быть превышен объём рюкзака,
 // нужно генерировать исключение.

    internal class Program
    {
        static void Main(string[] args)
        {
            Backpack obj = new Backpack();
            obj.ShowBackpack();
            Console.WriteLine("Складываем рюкзак.");

            // лямбда-выражение как обработчик события
            obj.ItemAdded += (item) =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Попытка добавить объект");
                Console.ForegroundColor = ConsoleColor.White;
            };

            // лямбда-выражение как обработчик события
            obj.ItemNotAdded += (item) =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Удаление объекта");
                Console.ForegroundColor = ConsoleColor.White;
            };
            obj.CreatePack();
            obj.ShowThings();
        }
    }

    class Backpack  // класс рюкзак
    {
        string color;     // цвет
        string company;   // фирма-производитель
        string material;  // ткань
        double weight;    // вес
        double volume;    // общий объем
        BackpackContent content = new BackpackContent();  // содержимое

        public event Action<string> ItemAdded;  // событие для добавление вещи
        public event Action<string> ItemNotAdded;  // событие для удаления вещи

        public Backpack()  // конструктор
        {
            color = "red";
            company  ="nike";
            material = "cotton";
            weight = 2;
            volume = 30;
        }

        public void CreatePack()  // метод Вместить вещи
        {
            double count = 0;  // счетчик для объема вещей
            do
            {
                try  // генерация искоючения
                {
                    count+=content.AddThing();  // вызываем метод Добавить вещь,
                                                // который возвращает объем вещи
                    ItemAdded?.Invoke(content.name);  // вызов события Добавления
                    // вывод в консоль оставшегося объема
                    Console.WriteLine($"Оставшийся объем: {volume - count} литров!");

                    if ((volume - count) < 0)  // если осталось недостаточно объема
                    {
                        ItemNotAdded?.Invoke(content.name);  // вызов события Удаления
                        content.RemoveThing();  // то удаляем последнюю вещь из списка
                        throw new Exception("Последняя вещь не влезет!");  // выдаем исключение
                    }
                }
                catch(Exception ex)  // отлов исключения
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor= ConsoleColor.White;
                }
            } while ((volume-count) > 0);  // продолжаем цикл, пока есть место в рюкзаке
        }

        public void ShowBackpack()  // метод Вывод описания рюкзака в консоль
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Мой рюкзак: " +
                $"\nЦвет: {color} " +
                $"\nФирма: {company} " +
                $"\nТкань: {material} " +
                $"\nВес: {weight}" +
                $"\nОбщий объем: {volume} литров.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ShowThings()  // метод Вывод вещей в рюкзаке в консоль
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Вещи в рюкзаке:\n");
            content.ShowList();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    class Thing  // класс Вещь
    {
        public string name { get; set; }  // название
        public double vol { get; set; }  // объем 
        public Thing() { }

        public void CreateThing()  // метод для создания Вещи
        {
            Console.Write("Название вещи: ");
            name = Convert.ToString(Console.ReadLine());
            Console.Write("Объем вещи: ");
            vol = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(ReturnVol());
        }
        public double ReturnVol()  // метод Возврат объема вещи
        {
            return vol;
        }
    }

    class BackpackContent : Thing  // класс Содержимое рюкзака
    {
        List<Thing> list = new List<Thing>();  // список вещей
       
        public List<Thing> List
        {
            get { return list; }
            set { list = value; }
        }

        public BackpackContent()
        {
            list = new List<Thing>();
        }
       
        public double AddThing()  // метод Добавление вещи в список
        {
            Thing ob = new Thing();
            ob.CreateThing();
            list.Add(ob);
            return ob.vol;
        }

        public void RemoveThing()  // метод Удаление вещи из списка
        {
            list.RemoveAt(list.Count-1);
        }
        public void ShowList()
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.name + ", объем: "+ item.vol);
            }
        }
    }   
}