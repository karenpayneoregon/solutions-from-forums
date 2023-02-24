using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace ReadExcelFromClipboard
{
	[SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public partial class Form1
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void cmdRun_Click(System.Object sender, System.EventArgs e)
		{

			DataGridView1.DataSource = null;

			try
			{

				IDataObject clipboardData = Clipboard.GetDataObject();

				if (clipboardData != null)
				{

					//Next proceed only of the copied data is in the CSV format indicating Excel content
					if (clipboardData.GetDataPresent(DataFormats.CommaSeparatedValue))
					{

						var clipboardStream = 
                            new System.IO.StreamReader(
                                (System.IO.Stream)clipboardData.GetData(DataFormats.CommaSeparatedValue));

						string formattedData = "";

						//Define a DataTable to hold the copied data for binding to the DataGrid
						DataTable excelTable = new DataTable {TableName = "ExcelData"};


                        while (clipboardStream.Peek() > 0)
						{
							int loopCounter = 0;

							formattedData = clipboardStream.ReadLine();

							Array singleRowData = formattedData.Split(",".ToCharArray());

							if (excelTable.Columns.Count <= 0)
							{
								for (loopCounter = 0; loopCounter <= singleRowData.GetUpperBound(0); loopCounter++)
								{
									excelTable.Columns.Add(singleRowData.GetValue(loopCounter).ToString());
								}

								continue;
							}

                            var rowNew = excelTable.NewRow();

							for (loopCounter = 0; loopCounter <= singleRowData.GetUpperBound(0); loopCounter++)
							{
								rowNew[loopCounter] = singleRowData.GetValue(loopCounter);
							}
							
							excelTable.Rows.Add(rowNew);

						}

						clipboardStream.Close();
						DataGridView1.DataSource = excelTable;
					}
					else
					{
						MessageBox.Show("Clipboard data does not seem to be copied from Excel!");
					}
				}
				else
				{
					MessageBox.Show("Clipboard is empty!");
				}
			}
			catch (Exception exp)
			{
				MessageBox.Show(exp.Message);
			}

		}
		private void cmdClose_Click(System.Object sender, System.EventArgs e)
		{
			Close();
		}

	}

}
