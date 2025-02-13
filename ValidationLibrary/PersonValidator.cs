using FluentValidation;

namespace ValidationLibrary;

/// <summary>
/// Provides validation rules for the <see cref="Person"/> class by combining 
/// multiple validators, including <see cref="UserNameValidator"/>, 
/// <see cref="EmailAddressValidator"/>, and <see cref="PasswordValidator"/>. 
/// This class ensures that all aspects of a <see cref="Person"/> instance 
/// are validated comprehensively.
/// </summary>
public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {

        Include(new UserNameValidator());
        Include(new EmailAddressValidator());
        Include(new PasswordValidator());

    }
}