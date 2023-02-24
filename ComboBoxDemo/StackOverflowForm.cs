using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace ComboBoxDemo;
public partial class StackOverflowForm : Form
{
    public StackOverflowForm()
    {
        InitializeComponent();
        List<Topping> toppings = new List<Topping>
        {
            new Topping() { Id = 1, Name = "Sprinkles" },
            new Topping() { Id = 2, Name = "Chocolate Chips" },
            new Topping() { Id = 3, Name = "M&Ms" },
            new Topping() { Id = 4, Name = "Oreos" },
            new Topping() { Id = 5, Name = "Cookie Dough" }
        };

        checkedListBox1.DataSource = toppings;
    }

    private void GetToppingsButton_Click(object sender, EventArgs e)
    {
        List<Topping> toppings = checkedListBox1.CheckedList<Topping>();
        if (toppings.Count > 0)
        {
            listBox1.DataSource = toppings;
        }
        else
        {
            listBox1.DataSource = null;
        }
    }

    private void GetRadioButton_Click(object sender, EventArgs e)
    {
        var radioButton = Controls.OfType<RadioButton>().FirstOrDefault(x => x.Checked);
        if (radioButton is not null)
        {
            // do something
        }
    }
    private readonly BindingSource _bindingSource = new BindingSource();
    private void LoadDataGridViewButton_Click(object sender, EventArgs e)
    {
        dataGridView1.AutoGenerateColumns = false;

        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn() { ColumnName = "Id", DataType = typeof(int), 
            AutoIncrement = true, AutoIncrementSeed = 1, ColumnMapping = MappingType.Hidden});
        dt.Columns.Add(new DataColumn() { ColumnName = "DateColumn", DataType = typeof(DateTime)});

        dt.Rows.Add(null, new DateTime(2023, 2, 22, 9, 44, 0));
        dt.Rows.Add(null, new DateTime(2023, 2, 17, 10, 58, 0));
        _bindingSource.DataSource = dt;
        dataGridView1.DataSource = _bindingSource;

    }

    private void CurrentButton_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is not null)
        {
            var dateValue = ((DataRowView)_bindingSource.Current).Row.Field<DateTime>("DateColumn");
            MessageBox.Show($@"Date is {dateValue:h:mm:ss tt}");
        }
    }

    private void IterateRowsButton_Click(object sender, EventArgs e)
    {
        var dt = (DataTable)_bindingSource.DataSource;
        if (dt is null)
        {
            return;
        }
        foreach (DataRow row in dt.Rows)
        {
            Debug.WriteLine(row.Field<DateTime>("DateColumn"));
        }
    }
}

public class Topping
{
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString() => Name;
}
public static class CheckedListBoxExtensions
{
    public static List<T> CheckedList<T>(this CheckedListBox sender)
        => sender.Items.Cast<T>()
            .Where((_, index) => sender.GetItemChecked(index))
            .Select(item => item)
            .ToList();
}
