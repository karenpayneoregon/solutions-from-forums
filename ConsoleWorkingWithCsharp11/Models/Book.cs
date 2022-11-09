namespace ConsoleWorkingWithCsharp11.Models;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public ICollection<Book> Books { get; } = new List<Book>();
}

public class Book
{
    public int Id { get; set; }
    public Author Author { get; set; } = default!;
    public int Price { get; set; }
}