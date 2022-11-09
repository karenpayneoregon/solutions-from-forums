using System.Diagnostics.CodeAnalysis;

namespace ConsoleWorkingWithCsharp11.Models;

/// <summary>
/// required modifier
/// </summary>
public class Person
{
    public Person() { }

    [SetsRequiredMembers]
    public Person(string firstName, string lastName, string email) 
        => (FirstName, LastName, Email) = (firstName, lastName, email);

    public required string FirstName { get; init; }
    public string MiddleName { get; set; }
    public required string LastName { get; init; }
    public required string Email { get; init; }

    [return: NotNullIfNotNull(nameof(url))]
    public string HomeUrl(string url)
    {
        return url;
    }
}