#nullable disable

namespace ConsoleWorkingWithCsharp11.Models;

public partial class Customer
{
    public int Identifier { get; set; }
    public string CompanyName { get; set; }
    public string ContactFirstName { get; set; }
    public string ContactLastName { get; set; }
    public int? ContactTypeIdentifier { get; set; }
    public int? GenderIdentifier { get; set; }
    public virtual ContactTypes ContactTypeNavigation { get; set; }
    public virtual Genders GenderNavigation { get; set; }
    public override string ToString() => CompanyName;

}