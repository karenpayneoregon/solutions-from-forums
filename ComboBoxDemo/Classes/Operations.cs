using System.Data;

namespace ComboBoxDemo.Classes;
public class Operations
{
    public delegate void OnTableCreated(DataTable dataTable);
    public static event OnTableCreated TableCreated;

    public delegate void OnRowAdded(DataRow row);
    public static event OnRowAdded RowAdded;

    public delegate void OnIssue(string message);
    public static event OnIssue Issue;

    public delegate void OnException(Exception exception);
    public static event OnException ExceptionEncountered;

    public delegate void OnDone();
    public static event OnDone Done;
    
    public static async Task Work(CancellationToken ct)
    {

        bool tableCreated = false;
        try
        {

            IDataObject clipboardData = Clipboard.GetDataObject();

            if (clipboardData != null)
            {

                if (clipboardData.GetDataPresent(DataFormats.CommaSeparatedValue))
                {

                    var clipboardStream = new StreamReader(((Stream)clipboardData.GetData(DataFormats.CommaSeparatedValue))!);

                    DataTable excelTable = new DataTable { TableName = "ExcelData" };
                    

                    while (clipboardStream.Peek() > 0)
                    {
                        
                        if (ct.IsCancellationRequested)
                        {
                            ct.ThrowIfCancellationRequested();
                        }

                        int loopCounter = 0;

                        var formattedData = await clipboardStream.ReadLineAsync(ct);
                        
                        Array singleRowData = formattedData!.Split(",".ToCharArray());

                        if (excelTable.Columns.Count <= 0)
                        {
                            for (loopCounter = 0; loopCounter <= singleRowData.GetUpperBound(0); loopCounter++)
                            {
                                excelTable.Columns.Add(singleRowData.GetValue(loopCounter)!.ToString());
                            }

                            continue;
                        }

                        if (!tableCreated)
                        {
                            TableCreated?.Invoke(excelTable);
                            tableCreated = true;
                        }
                        
                        var rowNew = excelTable.NewRow();

                        for (loopCounter = 0; loopCounter <= singleRowData.GetUpperBound(0); loopCounter++)
                        {
                            rowNew[loopCounter] = singleRowData.GetValue(loopCounter)!;
                        }
                        
                        excelTable.Rows.Add(rowNew);
                        RowAdded?.Invoke(rowNew);

                    }

                    clipboardStream.Close();
                    excelTable = null;

                }
                else
                {
                    Issue?.Invoke("Clipboard data does not seem to be copied from Excel!");
                }
            }
            else
            {
                Issue?.Invoke("Clipboard is empty!");
            }
        }
        catch (Exception exception)
        {
            ExceptionEncountered?.Invoke(exception);
        }

        Done?.Invoke();
    }


}
