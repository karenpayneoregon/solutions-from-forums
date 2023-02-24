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
}

public class TimeItem
{
    public int Id { get; set; }
    public TimeSpan Time { get; set; }
    public override string ToString() => $"TimeFrame ({Time:hh})";

}
