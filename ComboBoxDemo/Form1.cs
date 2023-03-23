using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ComboBoxDemo;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        comboBox1.DataSource = new List<TimeItem>
        {
            new () { Id = 1, Time = new TimeSpan(12, 0, 0) },
            new () { Id = 2, Time = new TimeSpan(10, 0, 0) },
            new () { Id = 3, Time = new TimeSpan(8,0,0)}
        };
    }

    private void GetButton_Click(object sender, EventArgs e)
    {
        var current = comboBox1.SelectedItem as TimeItem;
        MessageBox.Show(current!.Id.ToString());
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        await CopyFileAsync(@"C:\OED\DotnetLand\Database1.accdb", @"C:\Work");
    }

    public static async Task CopyFileAsync(string sourceFile, string endDirectory)
    {
        await using FileStream sourceStream = File.Open(sourceFile, FileMode.Open);
        await using FileStream destinationStream = File.Create(
            Path.Combine(endDirectory, Path.GetFileName(sourceFile)));
        await sourceStream.CopyToAsync(destinationStream);
    }

    private void button2_Click(object sender, EventArgs e)
    {
        string[] values = new[] {"0001", "01", "A001" };

        foreach (var value in values)
        {
            Debug.WriteLine($"{value,-10}{Helpers.NextValue(value)}");
        }
    }

    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/api/system.string.replacelineendings?view=net-7.0
    ///
    /// https://www.nuget.org/packages/Microsoft.CodeAnalysis.BannedApiAnalyzers
    /// How to use Microsoft.CodeAnalysis.BannedApiAnalyzers
    /// https://github.com/dotnet/roslyn-analyzers/blob/main/src/Microsoft.CodeAnalysis.BannedApiAnalyzers/BannedApiAnalyzers.Help.md
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button3_Click(object sender, EventArgs e)
    {
        var test = DateTime.Now;
        var input = """
            line 1

            line 2
            """;
        var lines = input
            .ReplaceLineEndings().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

    }

    private void Form1_Load(object sender, EventArgs e)
    {
        DataTable dataTable = new DataTable("Employees");

        dataTable.Columns.Add("EmployeeID", typeof(int));
        dataTable.Columns.Add("Name", typeof(string));
        dataTable.Columns.Add("Designation", typeof(string));

        dataTable.Rows.Add(1, "Natalia", "Developer");
        dataTable.Rows.Add(2, "Jonathan", "Developer");
        dataTable.Rows.Add(3, "Jake", "Developer");
        dataTable.Rows.Add(4, "Abraham", "Developer");
        dataTable.Rows.Add(5, "Mary", "Team Lead");
        dataTable.Rows.Add(6, "Calvin", "Project Manager");
        dataTable.Rows.Add(7, "Sarah", "Team Lead");
        dataTable.Rows.Add(8, "Monica", "Developer");
        dataTable.Rows.Add(9, "Donna", "Developer");

        multiColumnComboBox1.DataSource = dataTable;
        multiColumnComboBox1.DisplayMember = "Name";
        multiColumnComboBox1.ValueMember = "EmployeeID";
    }

    private void CurrentButton_Click(object sender, EventArgs e)
    {
        int id = ((DataRowView)multiColumnComboBox1.SelectedItem).Row.Field<int>("EmployeeID");
    }
}



public class TimeItem
{
    public int Id { get; set; }
    public TimeSpan Time { get; set; }
    public override string ToString() => $"TimeFrame ({Time:hh})";
}

public class TimeItemNew
{
    public int Id { get; set; }
    public TimeSpan Time { get; set; }
    public override string ToString() => $"TimeFrame ({Time:hh})";
}
public class Helpers
{
    public static string NextValue(string sender)
    {
        string value = Regex.Match(sender, "[0-9]+$").Value;
        return sender[..^value.Length] + (long.Parse(value) + 1)
            .ToString().PadLeft(value.Length, '0');
    }
}