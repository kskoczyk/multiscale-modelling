namespace Multiscale_Modelling
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.buttonRun = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.microstructureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemImportBmp = new System.Windows.Forms.ToolStripMenuItem();
            this.fromTextFiletxtToolStripMenuItemImportTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toBitmapbmpToolStripMenuItemExportBmp = new System.Windows.Forms.ToolStripMenuItem();
            this.toTextFiletxtToolStripMenuItemExportTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.labelXSize = new System.Windows.Forms.Label();
            this.labelYSize = new System.Windows.Forms.Label();
            this.checkBoxDisplayGrid = new System.Windows.Forms.CheckBox();
            this.groupBoxBoard = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSetBoard = new System.Windows.Forms.Button();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.labelBoundaryCondition = new System.Windows.Forms.Label();
            this.comboBoxBoundaryCondition = new System.Windows.Forms.ComboBox();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.labelNuclei = new System.Windows.Forms.Label();
            this.numericUpDownNucleiNumber = new System.Windows.Forms.NumericUpDown();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.labelLog = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.boardControl1 = new Multiscale_Modelling.BoardControl();
            this.checkBoxAnimate = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            this.groupBoxBoard.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNucleiNumber)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(271, 341);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(100, 50);
            this.buttonRun.TabIndex = 0;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(732, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.microstructureToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // microstructureToolStripMenuItem
            // 
            this.microstructureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.toolStripSeparator1,
            this.exportToolStripMenuItem});
            this.microstructureToolStripMenuItem.Name = "microstructureToolStripMenuItem";
            this.microstructureToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.microstructureToolStripMenuItem.Text = "Microstructure";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemImportBmp,
            this.fromTextFiletxtToolStripMenuItemImportTxt});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // toolStripMenuItemImportBmp
            // 
            this.toolStripMenuItemImportBmp.Name = "toolStripMenuItemImportBmp";
            this.toolStripMenuItemImportBmp.Size = new System.Drawing.Size(218, 26);
            this.toolStripMenuItemImportBmp.Text = "From bitmap (.bmp)";
            // 
            // fromTextFiletxtToolStripMenuItemImportTxt
            // 
            this.fromTextFiletxtToolStripMenuItemImportTxt.Name = "fromTextFiletxtToolStripMenuItemImportTxt";
            this.fromTextFiletxtToolStripMenuItemImportTxt.Size = new System.Drawing.Size(218, 26);
            this.fromTextFiletxtToolStripMenuItemImportTxt.Text = "From text file (.txt)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(126, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toBitmapbmpToolStripMenuItemExportBmp,
            this.toTextFiletxtToolStripMenuItemExportTxt});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // toBitmapbmpToolStripMenuItemExportBmp
            // 
            this.toBitmapbmpToolStripMenuItemExportBmp.Name = "toBitmapbmpToolStripMenuItemExportBmp";
            this.toBitmapbmpToolStripMenuItemExportBmp.Size = new System.Drawing.Size(200, 26);
            this.toBitmapbmpToolStripMenuItemExportBmp.Text = "To bitmap (.bmp)";
            // 
            // toTextFiletxtToolStripMenuItemExportTxt
            // 
            this.toTextFiletxtToolStripMenuItemExportTxt.Name = "toTextFiletxtToolStripMenuItemExportTxt";
            this.toTextFiletxtToolStripMenuItemExportTxt.Size = new System.Drawing.Size(200, 26);
            this.toTextFiletxtToolStripMenuItemExportTxt.Text = "To text file (.txt)";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.Location = new System.Drawing.Point(6, 41);
            this.numericUpDownX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownX.TabIndex = 4;
            this.numericUpDownX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownX.Leave += new System.EventHandler(this.numericUpDownX_Leave);
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.Location = new System.Drawing.Point(142, 41);
            this.numericUpDownY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownY.TabIndex = 5;
            this.numericUpDownY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownY.Leave += new System.EventHandler(this.numericUpDownY_Leave);
            // 
            // labelXSize
            // 
            this.labelXSize.AutoSize = true;
            this.labelXSize.Location = new System.Drawing.Point(3, 18);
            this.labelXSize.Name = "labelXSize";
            this.labelXSize.Size = new System.Drawing.Size(41, 17);
            this.labelXSize.TabIndex = 6;
            this.labelXSize.Text = "xSize";
            // 
            // labelYSize
            // 
            this.labelYSize.AutoSize = true;
            this.labelYSize.Location = new System.Drawing.Point(139, 18);
            this.labelYSize.Name = "labelYSize";
            this.labelYSize.Size = new System.Drawing.Size(42, 17);
            this.labelYSize.TabIndex = 7;
            this.labelYSize.Text = "ySize";
            // 
            // checkBoxDisplayGrid
            // 
            this.checkBoxDisplayGrid.AutoSize = true;
            this.checkBoxDisplayGrid.Location = new System.Drawing.Point(6, 70);
            this.checkBoxDisplayGrid.Name = "checkBoxDisplayGrid";
            this.checkBoxDisplayGrid.Size = new System.Drawing.Size(112, 21);
            this.checkBoxDisplayGrid.TabIndex = 8;
            this.checkBoxDisplayGrid.Text = "Display grid?";
            this.checkBoxDisplayGrid.UseVisualStyleBackColor = true;
            this.checkBoxDisplayGrid.CheckedChanged += new System.EventHandler(this.checkBoxDisplayGrid_CheckedChanged);
            // 
            // groupBoxBoard
            // 
            this.groupBoxBoard.Controls.Add(this.buttonClear);
            this.groupBoxBoard.Controls.Add(this.buttonSetBoard);
            this.groupBoxBoard.Controls.Add(this.labelXSize);
            this.groupBoxBoard.Controls.Add(this.checkBoxDisplayGrid);
            this.groupBoxBoard.Controls.Add(this.labelYSize);
            this.groupBoxBoard.Controls.Add(this.numericUpDownY);
            this.groupBoxBoard.Controls.Add(this.numericUpDownX);
            this.groupBoxBoard.Location = new System.Drawing.Point(18, 12);
            this.groupBoxBoard.Name = "groupBoxBoard";
            this.groupBoxBoard.Size = new System.Drawing.Size(360, 99);
            this.groupBoxBoard.TabIndex = 9;
            this.groupBoxBoard.TabStop = false;
            this.groupBoxBoard.Text = "Board control";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(268, 68);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(85, 23);
            this.buttonClear.TabIndex = 10;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSetBoard
            // 
            this.buttonSetBoard.Location = new System.Drawing.Point(268, 40);
            this.buttonSetBoard.Name = "buttonSetBoard";
            this.buttonSetBoard.Size = new System.Drawing.Size(85, 23);
            this.buttonSetBoard.TabIndex = 9;
            this.buttonSetBoard.Text = "Set";
            this.buttonSetBoard.UseVisualStyleBackColor = true;
            this.buttonSetBoard.Click += new System.EventHandler(this.buttonSetBoard_Click);
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.labelBoundaryCondition);
            this.groupBoxSettings.Controls.Add(this.comboBoxBoundaryCondition);
            this.groupBoxSettings.Controls.Add(this.buttonRandom);
            this.groupBoxSettings.Controls.Add(this.labelNuclei);
            this.groupBoxSettings.Controls.Add(this.numericUpDownNucleiNumber);
            this.groupBoxSettings.Location = new System.Drawing.Point(18, 117);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(360, 132);
            this.groupBoxSettings.TabIndex = 10;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // labelBoundaryCondition
            // 
            this.labelBoundaryCondition.AutoSize = true;
            this.labelBoundaryCondition.Location = new System.Drawing.Point(3, 66);
            this.labelBoundaryCondition.Name = "labelBoundaryCondition";
            this.labelBoundaryCondition.Size = new System.Drawing.Size(132, 17);
            this.labelBoundaryCondition.TabIndex = 13;
            this.labelBoundaryCondition.Text = "Boundary Condition";
            // 
            // comboBoxBoundaryCondition
            // 
            this.comboBoxBoundaryCondition.FormattingEnabled = true;
            this.comboBoxBoundaryCondition.Location = new System.Drawing.Point(6, 89);
            this.comboBoxBoundaryCondition.Name = "comboBoxBoundaryCondition";
            this.comboBoxBoundaryCondition.Size = new System.Drawing.Size(120, 24);
            this.comboBoxBoundaryCondition.TabIndex = 11;
            this.comboBoxBoundaryCondition.SelectedIndexChanged += new System.EventHandler(this.comboBoxBoundaryCondition_SelectedIndexChanged);
            // 
            // buttonRandom
            // 
            this.buttonRandom.Location = new System.Drawing.Point(132, 40);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(85, 23);
            this.buttonRandom.TabIndex = 10;
            this.buttonRandom.Text = "Random";
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // labelNuclei
            // 
            this.labelNuclei.AutoSize = true;
            this.labelNuclei.Location = new System.Drawing.Point(3, 18);
            this.labelNuclei.Name = "labelNuclei";
            this.labelNuclei.Size = new System.Drawing.Size(87, 17);
            this.labelNuclei.TabIndex = 10;
            this.labelNuclei.Text = "No. of nuclei";
            // 
            // numericUpDownNucleiNumber
            // 
            this.numericUpDownNucleiNumber.Location = new System.Drawing.Point(6, 41);
            this.numericUpDownNucleiNumber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownNucleiNumber.Name = "numericUpDownNucleiNumber";
            this.numericUpDownNucleiNumber.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownNucleiNumber.TabIndex = 9;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Location = new System.Drawing.Point(18, 341);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(236, 50);
            this.richTextBoxLog.TabIndex = 11;
            this.richTextBoxLog.Text = "";
            this.richTextBoxLog.TextChanged += new System.EventHandler(this.richTextBoxLog_TextChanged);
            // 
            // labelLog
            // 
            this.labelLog.AutoSize = true;
            this.labelLog.Location = new System.Drawing.Point(15, 321);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(32, 17);
            this.labelLog.TabIndex = 12;
            this.labelLog.Text = "Log";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.boardControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(732, 400);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxAnimate);
            this.panel1.Controls.Add(this.groupBoxBoard);
            this.panel1.Controls.Add(this.buttonRun);
            this.panel1.Controls.Add(this.richTextBoxLog);
            this.panel1.Controls.Add(this.labelLog);
            this.panel1.Controls.Add(this.groupBoxSettings);
            this.panel1.Location = new System.Drawing.Point(346, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 394);
            this.panel1.TabIndex = 14;
            // 
            // boardControl1
            // 
            this.boardControl1.CellNumberHeight = 0;
            this.boardControl1.CellNumberWidth = 0;
            this.boardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boardControl1.IsGridEnabled = false;
            this.boardControl1.Location = new System.Drawing.Point(3, 3);
            this.boardControl1.Name = "boardControl1";
            this.boardControl1.Size = new System.Drawing.Size(337, 394);
            this.boardControl1.TabIndex = 13;
            // 
            // checkBoxAnimate
            // 
            this.checkBoxAnimate.AutoSize = true;
            this.checkBoxAnimate.Location = new System.Drawing.Point(271, 314);
            this.checkBoxAnimate.Name = "checkBoxAnimate";
            this.checkBoxAnimate.Size = new System.Drawing.Size(81, 21);
            this.checkBoxAnimate.TabIndex = 11;
            this.checkBoxAnimate.Text = "Animate";
            this.checkBoxAnimate.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 428);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(750, 400);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            this.groupBoxBoard.ResumeLayout(false);
            this.groupBoxBoard.PerformLayout();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNucleiNumber)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem microstructureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.NumericUpDown numericUpDownX;
        private System.Windows.Forms.NumericUpDown numericUpDownY;
        private System.Windows.Forms.Label labelXSize;
        private System.Windows.Forms.Label labelYSize;
        private System.Windows.Forms.CheckBox checkBoxDisplayGrid;
        private System.Windows.Forms.GroupBox groupBoxBoard;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Label labelNuclei;
        private System.Windows.Forms.NumericUpDown numericUpDownNucleiNumber;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.Button buttonSetBoard;
		private BoardControl boardControl1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.ComboBox comboBoxBoundaryCondition;
        private System.Windows.Forms.Label labelBoundaryCondition;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemImportBmp;
        private System.Windows.Forms.ToolStripMenuItem fromTextFiletxtToolStripMenuItemImportTxt;
        private System.Windows.Forms.ToolStripMenuItem toBitmapbmpToolStripMenuItemExportBmp;
        private System.Windows.Forms.ToolStripMenuItem toTextFiletxtToolStripMenuItemExportTxt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.CheckBox checkBoxAnimate;
    }
}

