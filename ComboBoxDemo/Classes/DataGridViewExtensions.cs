using System.Data;

namespace ComboBoxDemo.Classes;
internal static class DataGridViewExtensions
{
    public static DataTable DataTable(this DataGridView pDataGridView) 
        => (DataTable)pDataGridView.DataSource;

    public static List<DataRow> Checked(this DataTable pDataTable, string pColumnName) 
        => pDataTable.AsEnumerable().Where(row => row.Field<bool>(pColumnName)).ToList();
}

public static class Extensions
{
    public static void ExpandColumns(this DataGridView source, bool sizable = false)
    {
        foreach (DataGridViewColumn col in source.Columns)
        {
            if (col.ValueType.Name != "ICollection`1")
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        if (!sizable) return;

        for (int index = 0; index <= source.Columns.Count - 1; index++)
        {
            int columnWidth = source.Columns[index].Width;

            source.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            // Set Width to calculated AutoSize value:
            source.Columns[index].Width = columnWidth;
        }


    }
}
public static class CheckedListBoxExtensions
{
    /// <summary>
    /// Get checked items as <see cref="T"/>
    /// </summary>
    /// <typeparam name="T">Model</typeparam>
    /// <param name="sender">CheckedListBox</param>
    /// <returns>List if one or more items are checked</returns>
    public static List<T> CheckedList<T>(this CheckedListBox sender)
        => sender.Items.Cast<T>()
            .Where((_, index) => sender.GetItemChecked(index))
            .Select(item => item)
            .ToList();

}