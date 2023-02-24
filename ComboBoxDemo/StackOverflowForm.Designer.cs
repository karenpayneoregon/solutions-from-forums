namespace ComboBoxDemo;

partial class StackOverflowForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.GetToppingsButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.GetRadioButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LoadDataGridViewButton = new System.Windows.Forms.Button();
            this.CurrentButton = new System.Windows.Forms.Button();
            this.IterateRowsButton = new System.Windows.Forms.Button();
            this.DateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(32, 23);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(150, 202);
            this.checkedListBox1.TabIndex = 0;
            // 
            // GetToppingsButton
            // 
            this.GetToppingsButton.Location = new System.Drawing.Point(188, 23);
            this.GetToppingsButton.Name = "GetToppingsButton";
            this.GetToppingsButton.Size = new System.Drawing.Size(94, 29);
            this.GetToppingsButton.TabIndex = 1;
            this.GetToppingsButton.Text = "Toppings";
            this.GetToppingsButton.UseVisualStyleBackColor = true;
            this.GetToppingsButton.Click += new System.EventHandler(this.GetToppingsButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(188, 58);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(150, 164);
            this.listBox1.TabIndex = 2;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(32, 320);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(117, 24);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(32, 281);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(117, 24);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // GetRadioButton
            // 
            this.GetRadioButton.Location = new System.Drawing.Point(188, 281);
            this.GetRadioButton.Name = "GetRadioButton";
            this.GetRadioButton.Size = new System.Drawing.Size(94, 29);
            this.GetRadioButton.TabIndex = 5;
            this.GetRadioButton.Text = "button1";
            this.GetRadioButton.UseVisualStyleBackColor = true;
            this.GetRadioButton.Click += new System.EventHandler(this.GetRadioButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateColumn});
            this.dataGridView1.Location = new System.Drawing.Point(385, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(403, 188);
            this.dataGridView1.TabIndex = 6;
            // 
            // LoadDataGridViewButton
            // 
            this.LoadDataGridViewButton.Location = new System.Drawing.Point(385, 252);
            this.LoadDataGridViewButton.Name = "LoadDataGridViewButton";
            this.LoadDataGridViewButton.Size = new System.Drawing.Size(94, 29);
            this.LoadDataGridViewButton.TabIndex = 7;
            this.LoadDataGridViewButton.Text = "Load Grid";
            this.LoadDataGridViewButton.UseVisualStyleBackColor = true;
            this.LoadDataGridViewButton.Click += new System.EventHandler(this.LoadDataGridViewButton_Click);
            // 
            // CurrentButton
            // 
            this.CurrentButton.Location = new System.Drawing.Point(499, 252);
            this.CurrentButton.Name = "CurrentButton";
            this.CurrentButton.Size = new System.Drawing.Size(94, 29);
            this.CurrentButton.TabIndex = 8;
            this.CurrentButton.Text = "Get current";
            this.CurrentButton.UseVisualStyleBackColor = true;
            this.CurrentButton.Click += new System.EventHandler(this.CurrentButton_Click);
            // 
            // IterateRowsButton
            // 
            this.IterateRowsButton.Location = new System.Drawing.Point(599, 252);
            this.IterateRowsButton.Name = "IterateRowsButton";
            this.IterateRowsButton.Size = new System.Drawing.Size(94, 29);
            this.IterateRowsButton.TabIndex = 9;
            this.IterateRowsButton.Text = "Iterate";
            this.IterateRowsButton.UseVisualStyleBackColor = true;
            this.IterateRowsButton.Click += new System.EventHandler(this.IterateRowsButton_Click);
            // 
            // DateColumn
            // 
            this.DateColumn.DataPropertyName = "DateColumn";
            dataGridViewCellStyle1.Format = "h:m tt d/M/yyyy";
            this.DateColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.DateColumn.HeaderText = "Date";
            this.DateColumn.MinimumWidth = 6;
            this.DateColumn.Name = "DateColumn";
            this.DateColumn.Width = 200;
            // 
            // StackOverflowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.IterateRowsButton);
            this.Controls.Add(this.CurrentButton);
            this.Controls.Add(this.LoadDataGridViewButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.GetRadioButton);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.GetToppingsButton);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "StackOverflowForm";
            this.Text = "StackOverflowForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private CheckedListBox checkedListBox1;
    private Button GetToppingsButton;
    private ListBox listBox1;
    private RadioButton radioButton1;
    private RadioButton radioButton2;
    private Button GetRadioButton;
    private DataGridView dataGridView1;
    private Button LoadDataGridViewButton;
    private Button CurrentButton;
    private Button IterateRowsButton;
    private DataGridViewTextBoxColumn DateColumn;
}