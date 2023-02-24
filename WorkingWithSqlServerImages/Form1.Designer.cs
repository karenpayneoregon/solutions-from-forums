namespace WorkingWithSqlServerImages;

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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ReadClientButton = new System.Windows.Forms.Button();
            this.InsertClientButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TruncateButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ReadDapperButton = new System.Windows.Forms.Button();
            this.InsertDapperButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ReadClientButton);
            this.groupBox1.Controls.Add(this.InsertClientButton);
            this.groupBox1.Location = new System.Drawing.Point(27, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SqlClient";
            // 
            // ReadClientButton
            // 
            this.ReadClientButton.Location = new System.Drawing.Point(18, 72);
            this.ReadClientButton.Name = "ReadClientButton";
            this.ReadClientButton.Size = new System.Drawing.Size(206, 29);
            this.ReadClientButton.TabIndex = 2;
            this.ReadClientButton.Text = "Read first image";
            this.ReadClientButton.UseVisualStyleBackColor = true;
            this.ReadClientButton.Click += new System.EventHandler(this.ReadClientButton_Click);
            // 
            // InsertClientButton
            // 
            this.InsertClientButton.Location = new System.Drawing.Point(18, 37);
            this.InsertClientButton.Name = "InsertClientButton";
            this.InsertClientButton.Size = new System.Drawing.Size(206, 29);
            this.InsertClientButton.TabIndex = 1;
            this.InsertClientButton.Text = "Insert image";
            this.InsertClientButton.UseVisualStyleBackColor = true;
            this.InsertClientButton.Click += new System.EventHandler(this.InsertClientButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TruncateButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 392);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 58);
            this.panel1.TabIndex = 1;
            // 
            // TruncateButton
            // 
            this.TruncateButton.Location = new System.Drawing.Point(12, 17);
            this.TruncateButton.Name = "TruncateButton";
            this.TruncateButton.Size = new System.Drawing.Size(94, 29);
            this.TruncateButton.TabIndex = 0;
            this.TruncateButton.Text = "Truncate";
            this.toolTip1.SetToolTip(this.TruncateButton, "There is no warning for this");
            this.TruncateButton.UseVisualStyleBackColor = true;
            this.TruncateButton.Click += new System.EventHandler(this.TruncateButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(609, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ReadDapperButton);
            this.groupBox2.Controls.Add(this.InsertDapperButton);
            this.groupBox2.Location = new System.Drawing.Point(27, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 137);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dapper";
            // 
            // ReadDapperButton
            // 
            this.ReadDapperButton.Location = new System.Drawing.Point(18, 72);
            this.ReadDapperButton.Name = "ReadDapperButton";
            this.ReadDapperButton.Size = new System.Drawing.Size(206, 29);
            this.ReadDapperButton.TabIndex = 2;
            this.ReadDapperButton.Text = "Read first image";
            this.ReadDapperButton.UseVisualStyleBackColor = true;
            this.ReadDapperButton.Click += new System.EventHandler(this.ReadDapperButton_Click);
            // 
            // InsertDapperButton
            // 
            this.InsertDapperButton.Location = new System.Drawing.Point(18, 37);
            this.InsertDapperButton.Name = "InsertDapperButton";
            this.InsertDapperButton.Size = new System.Drawing.Size(206, 29);
            this.InsertDapperButton.TabIndex = 1;
            this.InsertDapperButton.Text = "Insert image";
            this.InsertDapperButton.UseVisualStyleBackColor = true;
            this.InsertDapperButton.Click += new System.EventHandler(this.InsertDapperButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private GroupBox groupBox1;
    private Panel panel1;
    private Button TruncateButton;
    private ToolTip toolTip1;
    private Button InsertClientButton;
    private Button ReadClientButton;
    private PictureBox pictureBox1;
    private GroupBox groupBox2;
    private Button ReadDapperButton;
    private Button InsertDapperButton;
}
