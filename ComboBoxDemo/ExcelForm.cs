using System.Data;
using System.Diagnostics;
using ComboBoxDemo.Classes;

namespace ComboBoxDemo;
public partial class ExcelForm : Form
{
    private DataTable _dataTable;
    private CancellationTokenSource _cts = new CancellationTokenSource();

    public ExcelForm()
    {
        InitializeComponent();

        Operations.Issue += Operations_Issue;
        Operations.TableCreated += Operations_TableCreated;
        Operations.RowAdded += Operations_RowAdded;
        Operations.ExceptionEncountered += OperationsOnExceptionEncountered;
        Operations.Done += Operations_Done;
    }

    private void Operations_RowAdded(DataRow row)
    {
        _dataTable.ImportRow(row);
    }

    private void Operations_Done()
    {
        dataGridView1.ExpandColumns();
    }

    private void OperationsOnExceptionEncountered(Exception exception)
    {
        MessageBox.Show(exception.Message);
    }
    
    private void Operations_TableCreated(DataTable dataTable)
    {
        _dataTable = dataTable.Clone();
        dataGridView1.DataSource = _dataTable;
    }

    private void Operations_Issue(string message)
    {
        MessageBox.Show(message);
    }

    private async void ReadDataButton_Click(object sender, EventArgs e)
    {
        if (_cts.IsCancellationRequested == true)
        {
            _cts.Dispose();
            _cts = new CancellationTokenSource();
        }

        try
        {
            await Operations.Work(_cts.Token);
        }
        catch (OperationCanceledException)
        {
            MessageBox.Show("Canceled");
        }
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
        _cts.Cancel();
    }
}
