namespace ValidationLibrary;
/// <summary>
/// Represents a person with properties for username, email address, password, 
/// and password confirmation. This class is used as a model for validation purposes 
/// in the <c>ValidationLibrary</c>.
/// </summary>
public class Person
{
    public string UserName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public string PasswordConfirmation { get; set; }
}