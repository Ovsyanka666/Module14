using System.Linq;

namespace Module14
{
    class Program
    {
        static void Main()
        {
            string[] people = { "Анна", "Мария", "Сергей", "Алексей", "Дмитрий", "Ян" };
            List<string> People = new List<string>();

            foreach (string el in people)
            {
                if (el[0] is 'А')               
                    People.Add(el);                               
            }

            People.Sort();

            foreach (string element in People)            
                Console.WriteLine(element);



            var selectedPeople = from p in people // промежуточная переменная p 
                                 where p.StartsWith("А") // фильтрация по условию
                                 orderby p // сортировка по возрастанию (дефолтная)
                                 select p; // выбираем объект и сохраняем в выборку

            foreach (string s in selectedPeople)
                Console.WriteLine(s);


            var objects = new List<object>(){ 1, "Сергей ", "Андрей ", 300 };

            var selectedPeople1 = from o in objects
                                   where o is string
                                   orderby o
                                   select o;
            foreach (string obj in selectedPeople1)
                Console.WriteLine(obj);

            var selectedObj = objects
                .Where(o => o is string)
                .OrderBy(p => p);


            foreach (string obj in selectedObj)
                Console.WriteLine(obj);

        }
    }
}