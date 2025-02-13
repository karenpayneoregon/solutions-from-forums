using FluentValidation;

namespace ValidationLibrary;

/// <summary>
/// Provides validation rules for the <see cref="Person.UserName"/> property.
/// This validator ensures that the username is not empty and meets the 
/// minimum length requirement. It is used as part of the comprehensive 
/// validation process for <see cref="Person"/> and related classes.
/// </summary>
public class UserNameValidator : AbstractValidator<Person>
{
    public UserNameValidator()
    {
        RuleFor(person => person.UserName)
            .NotEmpty()
            .MinimumLength(3);
    }
}