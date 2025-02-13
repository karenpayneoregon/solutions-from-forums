namespace DynamicButtonsApp;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.ProductsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ProductsListBox
            // 
            this.ProductsListBox.AccessibleDescription = "Shows selected products for a specific category";
            this.ProductsListBox.FormattingEnabled = true;
            this.ProductsListBox.ItemHeight = 20;
            this.ProductsListBox.Location = new System.Drawing.Point(182, 12);
            this.ProductsListBox.Name = "ProductsListBox";
            this.ProductsListBox.Size = new System.Drawing.Size(269, 284);
            this.ProductsListBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AccessibleDescription = "Code sample for create dynamic buttons from a database";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 326);
            this.Controls.Add(this.ProductsListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Dynamic button";
            this.ResumeLayout(false);

    }

    #endregion

    private ListBox ProductsListBox;
}
