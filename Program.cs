using System.Security.Cryptography.X509Certificates;

namespace Module9.Task
{
    class Programm
    {
        public static void Main(string[] args)
        {
            NumberReader numberReader = new NumberReader();
            numberReader.NumberEnteredEvent += NameSorted;

            while(true)
            {
                try
                {
                    numberReader.Read();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено некорректное значение");
                };
            }
        }

        public static void NameSorted (int number)
        {
            List<string> stringList = new List<string> { "Петров", "Иванов", "Сидоров", "Борисов", "Васильев" };
            switch (number)
            {
                case 1: Console.WriteLine("1 - Выбрана прямая сортировка");
                    var sortedList = stringList.OrderBy(s => s);
                    foreach (var item in sortedList)
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case 2: Console.WriteLine("2 - Выбрана обратная сортировка");
                   sortedList = stringList.OrderByDescending(s => s);
                    foreach (var item in sortedList)
                    {
                        Console.WriteLine(item);
                    }
                    break;
            }
        }
    }

    class NumberReader
    {
        public delegate void NumberEnteredDelegate(int number);
        public event NumberEnteredDelegate NumberEnteredEvent;

        public void Read()
        {
            Console.WriteLine("Для прямой сортировки выберите 1, для обратной сортировки выберите 2");
            int number = Convert.ToInt32(Console.ReadLine());

            if(number! == 1 && number! == 2) throw new FormatException();

            NumberEntered(number);
        }

        protected virtual void NumberEntered(int number)
        {
            NumberEnteredEvent?.Invoke(number);
        }
    }





}



    //    public string SSS()
    //    {
    //        var sortedList = stringList.OrderBy(s => s);
    //        foreach (var item in sortedList)
    //        {
    //            Console.WriteLine(item);
    //        }
    //    }
    //}



