using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTest
{
    class Program
    {

        static void Main(string[] args)
        {
            // Добавим Россию с её городами
            var russianCities = new List<City>();
            russianCities.Add(new City("Москва", 11900000));
            russianCities.Add(new City("Санкт-Петербург", 4991000));
            russianCities.Add(new City("Волгоград", 1099000));
            russianCities.Add(new City("Казань", 1169000));
            russianCities.Add(new City("Севастополь", 449138));

            var CitiesNames = russianCities.Where(c => c.Name.Length <= 10).OrderBy(c => c.Name.Length);

            foreach (City el in CitiesNames)
                Console.WriteLine(el.Name);

            string[] text = { "Раз два три",
                               "четыре пять шесть",
                               "семь восемь девять" };

            var words = from str in text // пробегаемся по элементам массива
                        from word in str.Split(' ') // дробим каждый элемент по пробелам, сохраняя в новую последовательность
                        select word; // собираем все куски в результирующую выборку

            // выводим результат
            foreach (var word in words)
                Console.WriteLine(word);

            var numsList = new List<int[]>()
                    {           
                       new[] {2, 3, 7, 1},
                       new[] {45, 17, 88, 0},
                       new[] {23, 32, 44, -6},
                    };

            var nums = from array in numsList
                       from num in array
                       orderby num
                       select num;
            foreach (var num in nums)
                Console.WriteLine(num);




        }

        // Создадим модель класс для города
        public class City
        {
            public City(string name, long population)
            {
                Name = name;
                Population = population;
            }

            public string Name { get; set; }
            public long Population { get; set; }
        }
    }
}

