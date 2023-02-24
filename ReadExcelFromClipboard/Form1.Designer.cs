//INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;

namespace ReadExcelFromClipboard
{
	public partial class Form1 : System.Windows.Forms.Form
	{
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.DataGridView1 = new System.Windows.Forms.DataGridView();
			this.Panel1 = new System.Windows.Forms.Panel();
			this.cmdRun = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)this.DataGridView1).BeginInit();
			this.Panel1.SuspendLayout();
			this.SuspendLayout();
			//
			//DataGridView1
			//
			this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DataGridView1.Location = new System.Drawing.Point(0, 0);
			this.DataGridView1.Name = "DataGridView1";
			this.DataGridView1.Size = new System.Drawing.Size(652, 340);
			this.DataGridView1.TabIndex = 0;
			//
			//Panel1
			//
			this.Panel1.Controls.Add(this.cmdRun);
			this.Panel1.Controls.Add(this.cmdClose);
			this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.Panel1.Location = new System.Drawing.Point(0, 340);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(652, 47);
			this.Panel1.TabIndex = 1;
			//
			//cmdRun
			//
			this.cmdRun.Location = new System.Drawing.Point(12, 12);
			this.cmdRun.Name = "cmdRun";
			this.cmdRun.Size = new System.Drawing.Size(75, 23);
			this.cmdRun.TabIndex = 0;
			this.cmdRun.Text = "Run";
			this.cmdRun.UseVisualStyleBackColor = true;
			//
			//cmdClose
			//
			this.cmdClose.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.cmdClose.Location = new System.Drawing.Point(565, 12);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new System.Drawing.Size(75, 23);
			this.cmdClose.TabIndex = 1;
			this.cmdClose.Text = "Close";
			this.cmdClose.UseVisualStyleBackColor = true;
			//
			//Form1
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(652, 387);
			this.Controls.Add(this.DataGridView1);
			this.Controls.Add(this.Panel1);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)this.DataGridView1).EndInit();
			this.Panel1.ResumeLayout(false);
			this.ResumeLayout(false);

//INSTANT C# NOTE: Converted design-time event handler wireups:
			cmdRun.Click += new System.EventHandler(cmdRun_Click);
			cmdClose.Click += new System.EventHandler(cmdClose_Click);
		}
	   internal System.Windows.Forms.DataGridView DataGridView1;
	   internal System.Windows.Forms.Panel Panel1;
	   internal System.Windows.Forms.Button cmdClose;
	   internal System.Windows.Forms.Button cmdRun;

	}

}
