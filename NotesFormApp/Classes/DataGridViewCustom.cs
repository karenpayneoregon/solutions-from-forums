using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesFormApp.Classes;
public class DataGridViewCustom : DataGridView
{
    public DataGridViewCustom() : base()
    {
        this.ColumnStateChanged += DataGridViewCustom_ColumnStateChanged;
    }

    private void DataGridViewCustom_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
    {
        DataGridView dataGridView = (DataGridView)sender;
        //Only update for full row selection mode.
        if (dataGridView.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
        {
            e.Column.HeaderCell.Style.SelectionBackColor = dataGridView.ColumnHeadersDefaultCellStyle.BackColor;
        }
    }
}
