using System.Text;
using ValidationLibrary;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace ValidationApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        ValidateEmployee();

        Console.ReadLine();
    }

    private static void ValidateEmployee()
    {
        Employee employee = new()
        {
            UserName = "111111",
            Password = "my@Password1",
            PasswordConfirmation = "my@Password1",
            EmailAddress = "billyBob@gmail.met",
            Manager = "Jim Adams"
        };

        EmployeeValidator validator = new();
        ValidationResult result = validator.Validate(employee);

        if (result.IsValid)
        {
            Console.WriteLine("Valid");
        }
        else
        {
            StringBuilder builder = new();
            foreach (var error in result.Errors)
            {
                
                if (error.CustomState is not null)
                {
                    if ((StatusCodes)error.CustomState == StatusCodes.PasswordsMisMatch)
                    {
                        builder.AppendLine("Passwords do not match");
                    }
                }
                else
                {
                    builder.AppendLine(error.ErrorMessage);
                }
            }

            Console.WriteLine(builder);

            var test = result.Errors.FirstOrDefault(x => x.PropertyName == "EmailAddress");
            if (test is not null)
            {
                Console.WriteLine(test.AttemptedValue);
            }
        }
    }

    private static void ValidatePerson()
    {
        Person person = new()
        {
            UserName = "billyBob",
            Password = "my@Password",
            EmailAddress = "billyBob@gmailcom",
            PasswordConfirmation = "my@Password1"
        };

        PersonValidator validator = new();
        ValidationResult result = validator.Validate(person);

        if (result.IsValid)
        {
            Console.WriteLine("Valid");
        }
        else
        {
            StringBuilder builder = new();
            foreach (var error in result.Errors)
            {
                builder.AppendLine(error.ErrorMessage);
            }

            Console.WriteLine(builder);
        }
    }
}