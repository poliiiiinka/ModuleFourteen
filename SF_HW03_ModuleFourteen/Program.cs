using SF_HW03_ModuleFourteen.Classes;

namespace SF_HW03_ModuleFourteen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // создаём пустой список с типом данных Contact
            var phonebook = new List<Contact>();

            // добавляем контакты
            phonebook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phonebook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phonebook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phonebook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phonebook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phonebook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            while (true)
            {
                // читаем введенный с консоли символ
                var input = Console.ReadKey().KeyChar;

                // проверяем, число ли это
                var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

                // если не соответствует критериям - показываем ошибку
                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Страницы не существует");
                }
                // если соответствует - запускаем вывод
                else
                {
                    // пропускаем нужное количество элементов и берем 2 для показа на странице
                    var pageContent = phonebook.Skip((pageNumber - 1) * 2).Take(2);
                    Console.WriteLine();

                    // сортируем контакты сначала на имени, затем по фамилии
                    var pageContentSorted = pageContent.OrderBy(pc => pc.Name).ThenBy(pc => pc.LastName);

                    // выводим результат
                    foreach (var entry in pageContentSorted)
                        Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);

                    Console.WriteLine();
                }
            }
        }
    }
}
