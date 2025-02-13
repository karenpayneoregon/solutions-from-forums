using FluentValidation;

namespace ValidationLibrary;

/// <summary>
/// Provides validation rules for the <see cref="Person"/> class, specifically 
/// for password-related properties. This validator ensures that the password 
/// meets the required length and matches the password confirmation field.
/// </summary>
public class PasswordValidator : AbstractValidator<Person>
{

    public PasswordValidator()
    {

        RuleFor(person => person.Password.Length)
            .GreaterThan(7);

        RuleFor(person => person.Password)
            .Equal(p => p.PasswordConfirmation)
            .WithState(x => StatusCodes.PasswordsMisMatch);

    }
}