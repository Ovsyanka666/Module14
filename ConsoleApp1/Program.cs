using System.Collections.Generic;

namespace CountWords
{
    class Program
    {
        static void Main(string[] args)
        {
            // Сохраняем предложение в строку
            var sentence =
                "Подсчитайте, сколько уникальных символов в этом предложении, используя HashSet<T>, учитывая знаки препинания, но не учитывая пробелы в начале и в конце предложения.";

            // сохраняем в массив char
            var characters = sentence.ToCharArray();

            var symbols = new HashSet<char>();

            // добавляем во множество. Сохраняются только неповторяющиеся символы
            foreach (var symbol in characters)
                symbols.Add(symbol);

            // Выводим результат
            Console.WriteLine(symbols.Count);
        }
    }
}