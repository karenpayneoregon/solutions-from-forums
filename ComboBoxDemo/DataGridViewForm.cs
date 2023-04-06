using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using ComboBoxDemo.Classes;
using Microsoft.Data.SqlClient;

namespace ComboBoxDemo;
public partial class DataGridViewForm : Form
{
    public DataGridViewForm()
    {
        InitializeComponent();

        dataGridView1.DataSource = DataOperations.LoadData();
        dataGridView1.Columns["Checked"].HeaderText = "";
        dataGridView1.Columns["Checked"].Width = 25;

        checkedListBox1.DataSource = DataOperations.LoadData();
        checkedListBox1.DisplayMember = "Name";
    }

    private void GetCheckedButton_Click(object sender, EventArgs e)
    {
        var checkedRows = checkedListBox1.CheckedList<DataRowView>().Select(x => x.Row);
        if (checkedRows.Any())
        {
            
        }
        Console.WriteLine();
        //var checkedRows = dataGridView1
        //    .DataTable()
        //    .Checked("Checked");

        //if (checkedRows.Any())
        //{
        //    foreach (var row in checkedRows)
        //    {
        //        // logic to do your work, here I simple show how to access 
        //        // properties
        //        Debug.WriteLine($"" +
        //                        $"{row.Field<int>("CountryIdentifier"),-5}" +
        //                        $"{row.Field<string>("name")}");
        //    } 
        //}
    }

    private void button1_Click(object sender, EventArgs e)
    {
        List<string> values = new() { "F-2389", "F2891", "8057", "8057-D234", "X1 X1" };
        foreach (var value in values)
        {
            Debug.WriteLine($"{value} {value.Increment()}");
        }
   
    }
}
public static class Helpers
{
    public static string Increment(this string sender)
    {
        string value = Regex.Match(sender, "[0-9]+$").Value;
        return sender[..^value.Length] + (long.Parse(value) + 1).ToString().PadLeft(value.Length, '0');
    }
}
public class DataOperations
{
    private static readonly string ConnectionString =
        "Data Source=.\\SQLEXPRESS;" +
        "Initial Catalog=NorthWind2022;" +
        "Integrated Security=True;" +
        "Encrypt=False";

    public static DataTable LoadData()
    {
        var dt = new DataTable();

        using var cn = new SqlConnection { ConnectionString = ConnectionString };
        using var cmd = new SqlCommand { Connection = cn };

        cn.Open();

        cmd.CommandText = "SELECT CountryIdentifier ,[Name] FROM dbo.Countries";

        dt.Load(cmd.ExecuteReader());

        dt.Columns["CountryIdentifier"].ColumnMapping = MappingType.Hidden;
        dt.Columns.Add(new DataColumn()
        {
            ColumnName = "Checked", 
            DefaultValue = false, 
            DataType = typeof(bool)
        });

        dt.Columns["Checked"].SetOrdinal(0);

        return dt;

    }
}
