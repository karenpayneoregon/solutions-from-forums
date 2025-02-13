namespace SqlServerLibrary.Models;
#nullable disable
/// <summary>
/// Represents metadata information about a datetime column in a SQL Server table.
/// </summary>
public class DateTimeInformation
{
    public string TableName { get; set; }
    public string ColumnName { get; set; }
    public int Precision { get; set; }
    public override string ToString() => $"{ColumnName}: {Precision}";

}