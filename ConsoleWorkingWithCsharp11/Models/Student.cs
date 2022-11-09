using System.Diagnostics.CodeAnalysis;

namespace ConsoleWorkingWithCsharp11.Models;

public class Student : Person
{
    public Student() : base()
    {
    }

    /// <summary>
    /// The SetsRequiredMembers disables the compiler's checks that all required members are initialized
    /// when an object is created. Use it with caution.
    /// </summary>
    [SetsRequiredMembers]
    public Student(string firstName, string lastName, string email) :
        base(firstName, lastName, email)
    {
    }

    public double GPA { get; set; }
}