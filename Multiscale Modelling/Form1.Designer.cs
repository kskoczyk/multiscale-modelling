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
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.labelXSize = new System.Windows.Forms.Label();
            this.labelYSize = new System.Windows.Forms.Label();
            this.checkBoxDisplayGrid = new System.Windows.Forms.CheckBox();
            this.groupBoxBoard = new System.Windows.Forms.GroupBox();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.labelNuclei = new System.Windows.Forms.Label();
            this.numericUpDownNucleiNumber = new System.Windows.Forms.NumericUpDown();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.labelLog = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            this.groupBoxBoard.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNucleiNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(688, 388);
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
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
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
            this.exportToolStripMenuItem});
            this.microstructureToolStripMenuItem.Name = "microstructureToolStripMenuItem";
            this.microstructureToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.microstructureToolStripMenuItem.Text = "Microstructure";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(12, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(410, 407);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.Location = new System.Drawing.Point(6, 41);
            this.numericUpDownX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownX.TabIndex = 4;
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.Location = new System.Drawing.Point(142, 41);
            this.numericUpDownY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownY.TabIndex = 5;
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
            this.checkBoxDisplayGrid.Checked = true;
            this.checkBoxDisplayGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDisplayGrid.Location = new System.Drawing.Point(6, 70);
            this.checkBoxDisplayGrid.Name = "checkBoxDisplayGrid";
            this.checkBoxDisplayGrid.Size = new System.Drawing.Size(112, 21);
            this.checkBoxDisplayGrid.TabIndex = 8;
            this.checkBoxDisplayGrid.Text = "Display grid?";
            this.checkBoxDisplayGrid.UseVisualStyleBackColor = true;
            // 
            // groupBoxBoard
            // 
            this.groupBoxBoard.Controls.Add(this.labelXSize);
            this.groupBoxBoard.Controls.Add(this.checkBoxDisplayGrid);
            this.groupBoxBoard.Controls.Add(this.labelYSize);
            this.groupBoxBoard.Controls.Add(this.numericUpDownY);
            this.groupBoxBoard.Controls.Add(this.numericUpDownX);
            this.groupBoxBoard.Location = new System.Drawing.Point(428, 31);
            this.groupBoxBoard.Name = "groupBoxBoard";
            this.groupBoxBoard.Size = new System.Drawing.Size(360, 99);
            this.groupBoxBoard.TabIndex = 9;
            this.groupBoxBoard.TabStop = false;
            this.groupBoxBoard.Text = "Board control";
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.labelNuclei);
            this.groupBoxSettings.Controls.Add(this.numericUpDownNucleiNumber);
            this.groupBoxSettings.Location = new System.Drawing.Point(428, 136);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(360, 100);
            this.groupBoxSettings.TabIndex = 10;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
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
            this.richTextBoxLog.Location = new System.Drawing.Point(434, 388);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(236, 50);
            this.richTextBoxLog.TabIndex = 11;
            this.richTextBoxLog.Text = "";
            // 
            // labelLog
            // 
            this.labelLog.AutoSize = true;
            this.labelLog.Location = new System.Drawing.Point(434, 365);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(32, 17);
            this.labelLog.TabIndex = 12;
            this.labelLog.Text = "Log";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelLog);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.groupBoxBoard);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            this.groupBoxBoard.ResumeLayout(false);
            this.groupBoxBoard.PerformLayout();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNucleiNumber)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
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
    }
}

