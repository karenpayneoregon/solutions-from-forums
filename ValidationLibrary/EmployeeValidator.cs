using FluentValidation;

namespace ValidationLibrary;

/// <summary>
/// Provides validation rules for the <see cref="Employee"/> class.
/// This validator includes rules for validating properties such as 
/// username, password, email address, and manager, by incorporating 
/// other specific validators like <see cref="UserNameValidator"/>, 
/// <see cref="PasswordValidator"/>, <see cref="EmailAddressValidator"/>, 
/// and <see cref="ManagerValidator"/>.
/// </summary>
public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        Include(new UserNameValidator());
        Include(new PasswordValidator());
        Include(new EmailAddressValidator());
        Include(new ManagerValidator());
        RuleFor(person => person.Manager)
            .NotEmpty();
    }
}