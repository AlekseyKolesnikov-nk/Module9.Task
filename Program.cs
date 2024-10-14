using System.Security.Cryptography.X509Certificates;

namespace Module9.Task
{
    class Programm
    {
        public static void Main(string[] args)
        {
            NumberReader numberReader = new NumberReader();
            numberReader.NumberEnteredEvent += NameSorted;

            while(true)                                                                                     // Цикл до тех пор, пока будет без исключений
            {
                try
                {
                    numberReader.Read();
                    break;
                }
                catch (FormatException)                                                                             // Исключение - некорректный тип данных
                {
                    Console.WriteLine("Повторите ввод данных, значение должно быть целочисленным");
                }
                catch (ArgumentOutOfRangeException argumentOutOfRangeException)                                     // Исключение - данные вне диапазона
                {
                    Console.WriteLine("Повторите ввод данных, значение должно быть 1 или 2");
                }
                catch (Exception ex)                                                                                // Пользовательские исключения (при невыполнении - прерывание):
                {                                                                                                       // В списке не 5 фамилий,
                    Console.WriteLine(ex.Message);                                                                      // Фамилия должна быть не менее 2 символов,
                    break;                                                                                              // В списке точно должен быть Иванов
                };
            }
        }

        public static void NameSorted (int number)
        {
            List<string> stringList = new List<string> { "Петров", "Борисов", "Сидоров", "Иванов", "Васильев" };                            // Задан список 

            if (stringList.Count > 5 | stringList.Count < 5) throw new Exception("Сортировка прервана. В списке не 5 человек");   // Условие для пользовательского исключения - список из 5 фамилий

            foreach (string str in stringList)
            {
                if (str.Length < 2) throw new Exception("Сортировка прервана. В списке ошибка. Проверьте, фамилия не менее 2 символов)");               // Условие для пользовательского исключения - фамилия не менее 2 символов
            }

            for (int i = 0; i < stringList.Count; i++)
            {
                if (stringList[i] == "Иванов") goto Br;
            }
                throw new Exception("Сортировка прервана. В списке нет Иванова. Проверьте, он точно есть в этой группе");        // Условие для пользовательского исключения - проверка на наличие фамилии "Иванов"

        Br:
            Console.WriteLine();

            switch (number)
            {
                case 1: Console.WriteLine("Выбрана прямая сортировка (1)\n");                                         // Если выбор - 1 - Сортировка по возрастанию
                    var sortedList = stringList.OrderBy(s => s);
                    foreach (var item in sortedList)
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case 2: Console.WriteLine("Выбрана обратная сортировка (2)\n");                                       // Если выбор - 2 - Сортировка по убыванию
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
        public delegate void NumberEnteredDelegate(int number);                                                     // Делегат
        public event NumberEnteredDelegate NumberEnteredEvent;                                                      // Событие

        public void Read()
        {
            Console.WriteLine("\nДля прямой сортировки выберите 1, для обратной сортировки выберите 2");
            int number = Convert.ToInt32(Console.ReadLine());

            if(number! == 1 && number! == 2) throw new FormatException();                                           // Условие для исключения - некорректный дип данных

            if(number! < 1 | number! > 2) throw new ArgumentOutOfRangeException();                                  // Условие для исключения - число вне диапазона

            

            NumberEntered(number);
        }

        protected virtual void NumberEntered(int number)
        {
            NumberEnteredEvent?.Invoke(number);
        }
    }

}
