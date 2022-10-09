namespace Unit142
{
    class Program
    {
        static void Main()
        {
            string[] words = { "Обезьяна", "Лягушка", "Кот", "Собака", "Черепаха" };

            var wordsLength = from w in words
                              orderby w.Length
                              select new
                              {
                                  word = w,
                                  length = w.Length
                              };

            foreach (var n in wordsLength)
                Console.WriteLine(n.word + " - " + n.length);

            List<Student> students = new List<Student>
            {
                new Student { Name = "Андрей", Age = 23, Languages = new List<string> { "английский", "немецкий" } },
                new Student { Name = "Сергей", Age = 27, Languages = new List<string> { "английский", "французский" } },
                new Student { Name = "Дмитрий", Age = 29, Languages = new List<string> { "английский", "испанский" } },
                new Student { Name = "Василий", Age = 24, Languages = new List<string> { "испанский", "немецкий" } }
            };

            var studentApplications = from s in students
                                      where s.Age < 27
                                      let Birth = DateTime.Now.Year - s.Age
                                      select new Application()
                                      {
                                          Name = s.Name,
                                          YearOfBirth = Birth
                                      };
            foreach (var a in studentApplications)
                Console.WriteLine(a.Name + " " + a.YearOfBirth);

            var coarses = new List<Coarse>
                {
                   new Coarse {Name="Язык программирования C#", StartDate = new DateTime(2020, 12, 20)},
                   new Coarse {Name="Язык SQL и реляционные базы данных", StartDate = new DateTime(2020, 12, 15)},
                };

            var StudCourses = from stud in students
                              where stud.Age < 29 && stud.Languages.Contains("английский")
                              from course in coarses
                              where course.Name == "Язык программирования C#"
                              select new
                              {
                                  Name = stud.Name,
                                  CoarseName = course.Name
                              };
            foreach (var s in StudCourses)
                Console.WriteLine("Студент {0} зачислен на курс {1}", s.Name, s.CoarseName);


            var contacts = new List<Contact>()
                {
                   new Contact() { Name = "Андрей", Phone = 7999945005 },
                   new Contact() { Name = "Сергей", Phone = 799990455 },
                   new Contact() { Name = "Иван", Phone = 79999675 },
                   new Contact() { Name = "Игорь", Phone = 8884994 },
                   new Contact() { Name = "Анна", Phone = 665565656 },
                   new Contact() { Name = "Василий", Phone = 3434 }
                };

            var Page1 = contacts.Take(2);
            var Page2 = contacts.Skip(2).Take(2);
            var Page3 = contacts.Skip(4).Take(2);

            while (true)
            {
                Console.Write("Выберите страницу телефонной книги: ");
                string TempPage = Console.ReadLine();
                try
                {
                    int Page = Convert.ToInt32(TempPage);
                    switch (Page)
                    {
                        case 1:
                            foreach (var cont in Page1)
                                Console.WriteLine(cont.Name + " " + cont.Phone);
                            break;
                        case 2:
                            foreach (var cont in Page2)
                                Console.WriteLine(cont.Name + " " + cont.Phone);
                            break;
                        case 3:
                            foreach (var cont in Page3)
                                Console.WriteLine(cont.Name + " " + cont.Phone);
                            break;
                        default:
                            Console.WriteLine("Страница не найдена");
                            break;


                    }
                }
                catch
                {
                    Console.WriteLine("Введите число");
                }

                if (TempPage == "stop")
                    break;
            }

            var cars = new List<Car>()
                {
                   new Car("Suzuki", "JP"),
                   new Car("Toyota", "JP"),
                   new Car("Opel", "DE"),
                   new Car("Kamaz", "RUS"),
                   new Car("Lada", "RUS"),
                   new Car("Lada", "RUS"),
                   new Car("Honda", "JP"),
                };


            var notJapanCars1 = cars.Where(car => car.CountryCode != "JP");
            foreach (var car in notJapanCars1)
                Console.WriteLine(car.Manufacturer + " " + car.CountryCode);

            Console.WriteLine("new");

            var notJapanCars = cars.SkipWhile(car => car.CountryCode == "JP").TakeWhile(car => car.CountryCode != "JP");
            foreach (var car in notJapanCars)
                Console.WriteLine(car.Manufacturer + " " + car.CountryCode);

            Console.WriteLine("new");

            cars.RemoveAll(car => car.CountryCode == "JP");
            

        }

        public class Application
        {
            public string Name { get; set; }
            public int YearOfBirth { get; set; }
        }

        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Languages { get; set; }
        }

        public class Coarse
        {
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
        }
        
        public class Contact
        {
            public string Name { get; set; }
            public long Phone { get; set; }
        }

        public class Car
        {
            public string Manufacturer { get; set; }
            public string CountryCode { get; set; }

            public Car(string manufacturer, string countryCode)
            {
                Manufacturer = manufacturer;
                CountryCode = countryCode;
            }
        }
    }
}