namespace ValidationLibrary;

/// <summary>
/// Represents an employee, inheriting properties and behaviors from the <see cref="Person"/> class.
/// This class adds specific functionality for employees, including a property for the manager.
/// </summary>
public class Employee : Person
{
    public string Manager { get; set; }
}