using System.Data;
using System.Globalization;
using ConfigurationLibrary.Classes;
using Microsoft.Data.SqlClient;
using SqlServerDateTime2PrecisionApp.Data;
using SqlServerLibrary;

namespace SqlServerDateTime2PrecisionApp.Classes;

internal class DateTime2Operations
{

    public static void GetCreatedColumnDateTime()
    {
        var table1 = CreateDataReaderTable();

        using var cn = new SqlConnection(ConfigurationHelper.ConnectionString());
        using var cmd = new SqlCommand { Connection = cn, CommandText = "SELECT Created FROM dbo.AuditLog" };

        cn.Open();
        
        var reader = cmd.ExecuteReader();
        var millisecondsFormat = GetMillisecondPrecision();

        while (reader.Read())
        {
            var created = reader.GetDateTime(0);

            var formatted1 = created.ToString($"MM/dd/yyyy hh:mm:ss.{millisecondsFormat}");
            var formatted2 = created.ToString($"MM/dd/yyyy hh:mm:ss.fff");
            var formatted3 = created.ToString($"MM/dd/yyyy hh:mm:ss.ff");

            table1.AddRow("Date time value", created.ToString(CultureInfo.CurrentCulture), "", created.Millisecond.ToString(), created.TimeOfDay.ToString());
            table1.AddRow("Date time value formatted", formatted1, millisecondsFormat, created.Millisecond.ToString());
            table1.AddRow("Date time value formatted", formatted2, "fff");
            table1.AddRow("Date time value formatted", formatted3, "ff");
            table1.AddEmptyRow();
        }

        reader.Close();
        
        AnsiConsole.Write(table1);

        //-------------------------------------------------------------\\
        DataTable dataTable = new DataTable();
        dataTable.Load(cmd.ExecuteReader());

        var table2 = CreateTable("DataTable");

        foreach (DataRow row in dataTable.Rows)
        {
            table2.AddRow(
                row.Field<DateTime>("Created").ToString(),
                row.Field<DateTime>("Created").ToString($"MM/dd/yyyy hh:mm:ss.{millisecondsFormat}"));
        }

        AnsiConsole.Write(table2);

        //-------------------------------------------------------------\\
        var table3 = CreateTable();

        using var context = new Context();
        var data = context.AuditLog.ToList();
        foreach (var log in data)
        {
            table3.AddRow(log.Created.ToString(), log.Created?.ToString($"MM/dd/yyyy hh:mm:ss.{millisecondsFormat}")!);
        }

        AnsiConsole.Write(table3);

    }

    /// <summary>
    /// Get precision for DateTime2 for AuditLog using, in this case catalog defined in appsettings.json
    /// Defaults to fff
    /// </summary>
    /// <returns>DateTime2 precision</returns>
    /// <remarks>See overload below</remarks>
    public static string GetMillisecondPrecision()
    {
        var (list, hasColumns) = DataHelpers.GetDateTimeInformation(ConfigurationHelper.ConnectionString(), "AuditLog");
        return hasColumns ? new string('f', list.FirstOrDefault()!.Precision) : "fff";
    }

    /// <summary>
    /// Get precision for DateTime2 using, in this case catalog defined in appsettings.json
    /// Defaults to fff
    /// </summary>
    /// <param name="tableName">Existing table name</param>
    /// <param name="columnName">Column to get precision</param>
    /// <returns>DateTime2 precision</returns>
    public static string GetMillisecondPrecision(string tableName, string columnName)
    {
        var (list, _) = DataHelpers.GetDateTimeInformation(ConfigurationHelper.ConnectionString(), tableName);
        
        var column = list.FirstOrDefault(x => 
            string.Equals(x.ColumnName, columnName, StringComparison.CurrentCultureIgnoreCase));

        return column != null ? new string('f', column.Precision) : "ff";
        
    }

    /// <summary>
    /// Create Spectre.Console table
    /// </summary>
    public static Table CreateDataReaderTable()
    {
        var table = new Table()
            .RoundedBorder()
            .AddColumn("[cyan]Description[/]")
            .AddColumn("[cyan]Value[/]")
            .AddColumn("[cyan]Format[/]")
            .AddColumn("[cyan]Milliseconds[/]")
            .AddColumn("[cyan]TimeOfDay[/]")
            .Alignment(Justify.Center)
            .BorderColor(Color.LightSlateGrey)
            .Title("[LightGreen]DataReader[/]");
        return table;
    }
    public static Table CreateTable(string title = "EF Core")
    {
        var table = new Table()
            .RoundedBorder()
            .AddColumn("[cyan]Actual[/]")
            .AddColumn("[cyan]Formatted[/]")
            .Alignment(Justify.Center)
            .BorderColor(Color.LightSlateGrey)
            .Title($"[LightGreen]{title}[/]");
        return table;
    }
}