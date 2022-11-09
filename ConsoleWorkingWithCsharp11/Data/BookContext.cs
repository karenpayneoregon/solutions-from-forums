using ConfigurationLibrary.Classes;
using Microsoft.EntityFrameworkCore;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace ConsoleWorkingWithCsharp11.Data;

/// <summary>
/// From
/// https://github.com/dotnet/EntityFramework.Docs/blob/main/samples/core/Miscellaneous/NewInEFCore7/GroupByEntityTypeSample.cs
/// </summary>
public abstract class BookContext : DbContext
{
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging();
}


public class BookContextSqlServer : BookContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => base.OnConfiguring(
            optionsBuilder.UseSqlServer(
                "Data Source=.\\SQLEXPRESS;Initial Catalog=EF7.Books;Integrated Security=True;Encrypt=False"));
}

public class BookContextInMemory : BookContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => base.OnConfiguring(
            optionsBuilder.UseInMemoryDatabase(nameof(BookContextInMemory)));
}