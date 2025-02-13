using FluentValidation;

namespace ValidationLibrary;

/// <summary>
/// Provides validation rules for the <see cref="Employee"/> class, specifically 
/// focusing on the validation of the <c>Manager</c> property. This validator ensures 
/// that the manager name is valid by checking it against a predefined list of acceptable names.
/// </summary>
public class ManagerValidator : AbstractValidator<Employee>
{
    public ManagerValidator()
    {
        
        List<string> managers = ["Jim Adams", "Mary Jones"];

        RuleFor(emp => emp.Manager)
            .Must((employee, name) => managers.Contains(employee.Manager))
            .WithMessage("Invalid manager name");

    }
}