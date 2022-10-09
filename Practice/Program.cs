namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {    
            var phoneBook = new List<Contact>();
                        
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            var sortedPhoneBook = phoneBook  //сортировка по имени, а затем по фамилии
                .OrderBy(f => f.Name)
                .ThenBy(l => l.LastName);

            while (true)
            {
                Console.Write("Введите номер страницы ");
                string pageNumber = Console.ReadLine();
                if (pageNumber == "stop")
                    break;
                try
                {
                    int PageNumber = Convert.ToInt32(pageNumber);
                    if (PageNumber > 3 || PageNumber < 1)
                    {
                        Console.WriteLine("Страница не найдена");
                    }
                    else
                    {
                        var pageContent = sortedPhoneBook.Skip((PageNumber - 1) * 2).Take(2);
                        Console.WriteLine();

                        foreach (var entry in pageContent)
                            Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);

                        Console.WriteLine();
                    }
                }
                catch
                {
                    Console.WriteLine("Введите число");
                }
            }
        }
    }
    public class Contact
    {
        public Contact(string name, string lastName, long phoneNumber, String email)
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public String Name { get; }
        public String LastName { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
    }
}
