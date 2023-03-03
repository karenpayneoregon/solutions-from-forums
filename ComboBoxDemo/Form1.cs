using ComboBoxDemo.Classes;

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
        SomeClass.Condition += SomeClass_Condition;
        SomeClass.CostSql();
    }

    private void SomeClass_Condition(bool condition)
    {
        // here is where you set visibility of buttons
        if (condition)
        {
            
        }
        else
        {
            
        }
    }
}

public class TimeItem
{
    public int Id { get; set; }
    public TimeSpan Time { get; set; }
    public override string ToString() => $"TimeFrame ({Time:hh})";

}

