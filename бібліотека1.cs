using System;
using System.Collections.Generic;
using System.Linq;

public class Книга
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }

    public override string ToString()
    {
        return $"{Title} by {Author}, {Year} - {Genre}";
    }
}

public class Користувач
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class Читач : Користувач
{
    public string CardNumber { get; set; }
}

public class Бібліотекар : Користувач
{
    public string EmployeeId { get; set; }
}

public class Адміністрація : Бібліотекар
{
    public string AdminCode { get; set; }
}

public class ОблікВидачі
{
    public int IssueId { get; set; }
    public int BookId { get; set; }
    public int UserId { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}

public class Каталог
{
    public int CatalogId { get; set; }
    public List<Книга> Books { get; set; }

    public Каталог()
    {
        Books = new List<Книга>();
    }

    public void ДодатиКнигу(Книга книга)
    {
        Books.Add(книга);
        Console.WriteLine($"Книга '{книга.Title}' додана до каталогу.");
    }

    public Книга ПошукКниги(string title)
    {
        return Books.FirstOrDefault(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }
}

public class Бібліотека
{
    public Каталог Каталог { get; set; }
    public List<Користувач> Користувачі { get; set; }
    public List<ОблікВидачі> ОблікВидач { get; set; }

    public Бібліотека()
    {
        Каталог = new Каталог();
        Користувачі = new List<Користувач>();
        ОблікВидач = new List<ОблікВидач>();
    }

    public void ДодатиКористувача(Користувач користувач)
    {
        Користувачі.Add(користувач);
        Console.WriteLine($"Користувач '{користувач.Name}' доданий.");
    }

    public void ВидатиКнигу(int bookId, int userId)
    {
        var книга = Каталог.Books.FirstOrDefault(b => b.Id == bookId);
        var користувач = Користувачі.FirstOrDefault(u => u.Id == userId);

        if (книга != null && користувач != null)
        {
            ОблікВидач.Add(new ОблікВидачі
            {
                IssueId = ОблікВидач.Count + 1,
                BookId = bookId,
                UserId = userId,
                IssueDate = DateTime.Now
            });
            Console.WriteLine($"Книга '{книга.Title}' видана користувачу '{користувач.Name}'.");
        }
        else
        {
            Console.WriteLine("Книга або користувач не знайдені.");
        }
    }

    public void ПовернутиКнигу(int issueId)
    {
        var облік = ОблікВидач.FirstOrDefault(o => o.IssueId == issueId);

        if (облік != null)
        {
            облік.ReturnDate = DateTime.Now;
            Console.WriteLine($"Книга з issueId '{issueId}' повернена.");
        }
        else
        {
            Console.WriteLine("Запис видачі не знайдений.");
        }
    }

    public Користувач ПошукКористувача(string name)
    {
        return Користувачі.FirstOrDefault(user => user.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}

class Program
{
    static void Main(string[] args)
    {
        Бібліотека бібліотека = new Бібліотека();

      
        бібліотека.Каталог.ДодатиКнигу(new Книга { Id = 1, Title = "Війна і мир", Author = "Лев Толстой", Genre = "Роман", Year = 1869 });
        бібліотека.Каталог.ДодатиКнигу(new Книга { Id = 2, Title = "1984", Author = "Джордж Орвелл", Genre = "Антиутопія", Year = 1949 });

       
        бібліотека.ДодатиКористувача(new Читач { Id = 1, Name = "Іван Іванов", Email = "ivan@example.com", CardNumber = "12345" });
        бібліотека.ДодатиКористувача(new Бібліотекар { Id = 2, Name = "Петро Петров", Email = "petro@example.com", EmployeeId = "emp01" });

     
        var книга = бібліотека.Каталог.ПошукКниги("1984");
        if (книга != null)
        {
            Console.WriteLine($"Знайдена книга: {книга}");
        }
        else
        {
            Console.WriteLine("Книга не знайдена.");
        }

     
        бібліотека.ВидатиКнигу(1, 1); // Видати книгу з Id=1 користувачу з Id=1

       
        бібліотека.ПовернутиКнигу(1); // Повернення книги з issueId=1

      
        var користувач = бібліотека.ПошукКористувача("Іван Іванов");
        if (користувач != null)
        {
            Console.WriteLine($"Знайдений користувач: {користувач.Name}");
        }
        else
        {
            Console.WriteLine("Користувач не знайдений.");
        }
    }
}
