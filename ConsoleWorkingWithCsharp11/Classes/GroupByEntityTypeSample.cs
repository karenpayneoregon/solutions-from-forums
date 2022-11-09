using Microsoft.EntityFrameworkCore;


namespace ConsoleWorkingWithCsharp11.Classes;

/// <summary>
/// From
/// https://github.com/dotnet/EntityFramework.Docs/blob/main/samples/core/Miscellaneous/NewInEFCore7/GroupByEntityTypeSample.cs
///
/// TODO change connection string
/// 
/// </summary>
public static class GroupByEntityTypeSample
{
    /// <summary>
    /// SELECT B.Id, B.AuthorId, B.Price, A.[Name] FROM dbo.Books AS B INNER JOIN dbo.Authors AS A ON B.Id = A.Id;
    /// </summary>
    public static Task GroupBy_entity_type_SqlServer()
    {
        Helpers.PrintSampleName();
        return QueryTest<BookContextSqlServer>();
    }

    //public static Task GroupBy_entity_type_Sqlite()
    //{
    //    Helpers.PrintSampleName();
    //    return QueryTest<BookContextSqlite>();
    //}

    public static Task GroupBy_entity_type_InMemory()
    {
        Helpers.PrintSampleName();
        return QueryTest<BookContextInMemory>();
    }

    private static async Task QueryTest<TContext>()
        where TContext : BookContext, new()
    {
        await using (var context = new TContext())
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            var toast = new Author { Name = "Toast" };
            var alice = new Author { Name = "Alice" };

            await context.AddRangeAsync(
                new Book { Author = alice, Price = 10 },
                new Book { Author = alice, Price = 11 },
                new Book { Author = toast, Price = 12 },
                new Book { Author = toast, Price = 13 },
                new Book { Author = toast, Price = 14 });

            await context.SaveChangesAsync();
        }

        await using (var context = new TContext())
        {
            AnsiConsole.MarkupLine("[paleturquoise1]GroupByEntityType[/]");
            #region GroupByEntityType
            var query = context.Books
                .GroupBy(s => s.Author)
                .Select(s => new { Author = s.Key, MaxPrice = s.Max(p => p.Price) });
            #endregion

            await foreach (var group in query.AsAsyncEnumerable())
            {
                AnsiConsole.MarkupLine($"[cyan]Author:[/] [green1]{group.Author.Name}[/] [cyan]MaxPrice[/] = [green1]{group.MaxPrice}[/]");
            }
        }

        await using (var context = new TContext())
        {
            AnsiConsole.MarkupLine("[paleturquoise1]GroupByEntityTypeReversed[/]");
            #region GroupByEntityTypeReversed
            var query = context.Authors
                .Select(a => new { Author = a, MaxPrice = a.Books.Max(b => b.Price) });
            #endregion

            await foreach (var group in query.AsAsyncEnumerable())
            {
                AnsiConsole.MarkupLine($"[cyan]Author:[/] [green1]{group.Author.Name}[/] [cyan]MaxPrice[/] = [green1]{group.MaxPrice}[/]");
            }
        }
    }






}