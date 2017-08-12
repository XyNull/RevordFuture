namespace RevordFuture
{
    partial class FormMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.buttonSum = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.InputMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SumMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExcelInMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExcelOutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择时间";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(113, 41);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(265, 25);
            this.dateTimePicker.TabIndex = 1;
            // 
            // buttonSum
            // 
            this.buttonSum.Location = new System.Drawing.Point(388, 35);
            this.buttonSum.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSum.Name = "buttonSum";
            this.buttonSum.Size = new System.Drawing.Size(100, 42);
            this.buttonSum.TabIndex = 2;
            this.buttonSum.Text = "计算";
            this.buttonSum.UseVisualStyleBackColor = true;
            this.buttonSum.Click += new System.EventHandler(this.buttonSum_Click);
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(37, 93);
            this.treeView.Margin = new System.Windows.Forms.Padding(4);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(449, 522);
            this.treeView.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InputMenuItem,
            this.SumMenuItem,
            this.ExcelInMenuItem,
            this.ExcelOutMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(532, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // InputMenuItem
            // 
            this.InputMenuItem.Name = "InputMenuItem";
            this.InputMenuItem.Size = new System.Drawing.Size(81, 24);
            this.InputMenuItem.Text = "输入账目";
            this.InputMenuItem.Click += new System.EventHandler(this.InputMenuItem_Click);
            // 
            // SumMenuItem
            // 
            this.SumMenuItem.Name = "SumMenuItem";
            this.SumMenuItem.Size = new System.Drawing.Size(51, 24);
            this.SumMenuItem.Text = "计算";
            // 
            // ExcelInMenuItem
            // 
            this.ExcelInMenuItem.Name = "ExcelInMenuItem";
            this.ExcelInMenuItem.Size = new System.Drawing.Size(51, 24);
            this.ExcelInMenuItem.Text = "导入";
            // 
            // ExcelOutMenuItem
            // 
            this.ExcelOutMenuItem.Name = "ExcelOutMenuItem";
            this.ExcelOutMenuItem.Size = new System.Drawing.Size(51, 24);
            this.ExcelOutMenuItem.Text = "导出";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 638);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.buttonSum);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RecordFuture";
            this.Load += new System.EventHandler(this.FormSum_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button buttonSum;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem InputMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SumMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExcelInMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExcelOutMenuItem;
    }
}