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
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.labelSimulationType = new System.Windows.Forms.Label();
            this.labelYSize = new System.Windows.Forms.Label();
            this.checkBoxDisplayGrid = new System.Windows.Forms.CheckBox();
            this.groupBoxBoard = new System.Windows.Forms.GroupBox();
            this.labelXSize = new System.Windows.Forms.Label();
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
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
            this.boardControl1 = new Multiscale_Modelling.BoardControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2ndPhase = new System.Windows.Forms.Label();
            this.groupBoxView = new System.Windows.Forms.GroupBox();
            this.groupBoxSubstructure = new System.Windows.Forms.GroupBox();
            this.checkBoxSubstructureVisible = new System.Windows.Forms.CheckBox();
            this.groupBoxBorder = new System.Windows.Forms.GroupBox();
            this.labelThickness = new System.Windows.Forms.Label();
            this.numericUpDownThickness = new System.Windows.Forms.NumericUpDown();
            this.buttonClearBorders = new System.Windows.Forms.Button();
            this.buttonDrawBorders = new System.Windows.Forms.Button();
            this.checkBoxBorderVisible = new System.Windows.Forms.CheckBox();
            this.groupBoxPhase = new System.Windows.Forms.GroupBox();
            this.buttonClearPhases = new System.Windows.Forms.Button();
            this.checkBoxPhaseVisible = new System.Windows.Forms.CheckBox();
            this.groupBoxSimulation = new System.Windows.Forms.GroupBox();
            this.labelProbability = new System.Windows.Forms.Label();
            this.numericUpDownProbability = new System.Windows.Forms.NumericUpDown();
            this.comboBoxSimulationType = new System.Windows.Forms.ComboBox();
            this.groupBoxInclusions = new System.Windows.Forms.GroupBox();
            this.labelInclusionType = new System.Windows.Forms.Label();
            this.comboBoxInclusionType = new System.Windows.Forms.ComboBox();
            this.buttonAddInclusions = new System.Windows.Forms.Button();
            this.labelInclusionsNumber = new System.Windows.Forms.Label();
            this.labelInclusionsRadius = new System.Windows.Forms.Label();
            this.numericUpDownInclusionsRadius = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownInclusionsNumber = new System.Windows.Forms.NumericUpDown();
            this.checkBoxAnimate = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            this.groupBoxBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNucleiNumber)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxView.SuspendLayout();
            this.groupBoxSubstructure.SuspendLayout();
            this.groupBoxBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThickness)).BeginInit();
            this.groupBoxPhase.SuspendLayout();
            this.groupBoxSimulation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProbability)).BeginInit();
            this.groupBoxInclusions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInclusionsRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInclusionsNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(264, 802);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(109, 50);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // microstructureToolStripMenuItem
            // 
            this.microstructureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.toolStripSeparator1,
            this.exportToolStripMenuItem});
            this.microstructureToolStripMenuItem.Name = "microstructureToolStripMenuItem";
            this.microstructureToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.microstructureToolStripMenuItem.Text = "Microstructure";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemImportBmp,
            this.fromTextFiletxtToolStripMenuItemImportTxt});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // toolStripMenuItemImportBmp
            // 
            this.toolStripMenuItemImportBmp.Name = "toolStripMenuItemImportBmp";
            this.toolStripMenuItemImportBmp.Size = new System.Drawing.Size(226, 26);
            this.toolStripMenuItemImportBmp.Text = "From bitmap (.bmp)";
            this.toolStripMenuItemImportBmp.Click += new System.EventHandler(this.toolStripMenuItemImportBmp_Click);
            // 
            // fromTextFiletxtToolStripMenuItemImportTxt
            // 
            this.fromTextFiletxtToolStripMenuItemImportTxt.Name = "fromTextFiletxtToolStripMenuItemImportTxt";
            this.fromTextFiletxtToolStripMenuItemImportTxt.Size = new System.Drawing.Size(226, 26);
            this.fromTextFiletxtToolStripMenuItemImportTxt.Text = "From text file (.txt)";
            this.fromTextFiletxtToolStripMenuItemImportTxt.Click += new System.EventHandler(this.fromTextFiletxtToolStripMenuItemImportTxt_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(134, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toBitmapbmpToolStripMenuItemExportBmp,
            this.toTextFiletxtToolStripMenuItemExportTxt});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // toBitmapbmpToolStripMenuItemExportBmp
            // 
            this.toBitmapbmpToolStripMenuItemExportBmp.Name = "toBitmapbmpToolStripMenuItemExportBmp";
            this.toBitmapbmpToolStripMenuItemExportBmp.Size = new System.Drawing.Size(208, 26);
            this.toBitmapbmpToolStripMenuItemExportBmp.Text = "To bitmap (.bmp)";
            this.toBitmapbmpToolStripMenuItemExportBmp.Click += new System.EventHandler(this.toBitmapbmpToolStripMenuItemExportBmp_Click);
            // 
            // toTextFiletxtToolStripMenuItemExportTxt
            // 
            this.toTextFiletxtToolStripMenuItemExportTxt.Name = "toTextFiletxtToolStripMenuItemExportTxt";
            this.toTextFiletxtToolStripMenuItemExportTxt.Size = new System.Drawing.Size(208, 26);
            this.toTextFiletxtToolStripMenuItemExportTxt.Text = "To text file (.txt)";
            this.toTextFiletxtToolStripMenuItemExportTxt.Click += new System.EventHandler(this.toTextFiletxtToolStripMenuItemExportTxt_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
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
            // labelSimulationType
            // 
            this.labelSimulationType.AutoSize = true;
            this.labelSimulationType.Location = new System.Drawing.Point(6, 18);
            this.labelSimulationType.Name = "labelSimulationType";
            this.labelSimulationType.Size = new System.Drawing.Size(109, 17);
            this.labelSimulationType.TabIndex = 6;
            this.labelSimulationType.Text = "Simulation Type";
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
            this.checkBoxDisplayGrid.Size = new System.Drawing.Size(104, 21);
            this.checkBoxDisplayGrid.TabIndex = 8;
            this.checkBoxDisplayGrid.Text = "Display grid";
            this.checkBoxDisplayGrid.UseVisualStyleBackColor = true;
            this.checkBoxDisplayGrid.CheckedChanged += new System.EventHandler(this.checkBoxDisplayGrid_CheckedChanged);
            // 
            // groupBoxBoard
            // 
            this.groupBoxBoard.Controls.Add(this.labelXSize);
            this.groupBoxBoard.Controls.Add(this.numericUpDownX);
            this.groupBoxBoard.Controls.Add(this.buttonClear);
            this.groupBoxBoard.Controls.Add(this.buttonSetBoard);
            this.groupBoxBoard.Controls.Add(this.checkBoxDisplayGrid);
            this.groupBoxBoard.Controls.Add(this.labelYSize);
            this.groupBoxBoard.Controls.Add(this.numericUpDownY);
            this.groupBoxBoard.Location = new System.Drawing.Point(14, 3);
            this.groupBoxBoard.Name = "groupBoxBoard";
            this.groupBoxBoard.Size = new System.Drawing.Size(360, 99);
            this.groupBoxBoard.TabIndex = 9;
            this.groupBoxBoard.TabStop = false;
            this.groupBoxBoard.Text = "Board control";
            // 
            // labelXSize
            // 
            this.labelXSize.AutoSize = true;
            this.labelXSize.Location = new System.Drawing.Point(7, 18);
            this.labelXSize.Name = "labelXSize";
            this.labelXSize.Size = new System.Drawing.Size(41, 17);
            this.labelXSize.TabIndex = 12;
            this.labelXSize.Text = "xSize";
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
            this.numericUpDownX.TabIndex = 11;
            this.numericUpDownX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownX.Leave += new System.EventHandler(this.numericUpDownX_Leave);
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
            this.groupBoxSettings.Location = new System.Drawing.Point(14, 233);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(360, 122);
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
            this.comboBoxBoundaryCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.richTextBoxLog.Location = new System.Drawing.Point(14, 775);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(244, 77);
            this.richTextBoxLog.TabIndex = 11;
            this.richTextBoxLog.Text = "";
            this.richTextBoxLog.TextChanged += new System.EventHandler(this.richTextBoxLog_TextChanged);
            // 
            // labelLog
            // 
            this.labelLog.AutoSize = true;
            this.labelLog.Location = new System.Drawing.Point(11, 755);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(732, 875);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // boardControl1
            // 
            this.boardControl1.CellNumberHeight = 0;
            this.boardControl1.CellNumberWidth = 0;
            this.boardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boardControl1.IsGridEnabled = false;
            this.boardControl1.Location = new System.Drawing.Point(3, 3);
            this.boardControl1.Name = "boardControl1";
            this.boardControl1.Size = new System.Drawing.Size(337, 869);
            this.boardControl1.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2ndPhase);
            this.panel1.Controls.Add(this.groupBoxView);
            this.panel1.Controls.Add(this.groupBoxSimulation);
            this.panel1.Controls.Add(this.groupBoxInclusions);
            this.panel1.Controls.Add(this.checkBoxAnimate);
            this.panel1.Controls.Add(this.groupBoxBoard);
            this.panel1.Controls.Add(this.buttonRun);
            this.panel1.Controls.Add(this.richTextBoxLog);
            this.panel1.Controls.Add(this.labelLog);
            this.panel1.Controls.Add(this.groupBoxSettings);
            this.panel1.Location = new System.Drawing.Point(346, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 867);
            this.panel1.TabIndex = 14;
            // 
            // label2ndPhase
            // 
            this.label2ndPhase.AutoSize = true;
            this.label2ndPhase.Location = new System.Drawing.Point(11, 677);
            this.label2ndPhase.MaximumSize = new System.Drawing.Size(365, 0);
            this.label2ndPhase.Name = "label2ndPhase";
            this.label2ndPhase.Size = new System.Drawing.Size(362, 68);
            this.label2ndPhase.TabIndex = 18;
            this.label2ndPhase.Text = "2nd phase unlocked! Use left mouse click for shifting between phases, right click" +
    " for drawing grain boundaries, middle click for selection of individual grains t" +
    "o go through 2nd phase simulation.\r\n";
            this.label2ndPhase.Visible = false;
            // 
            // groupBoxView
            // 
            this.groupBoxView.Controls.Add(this.groupBoxSubstructure);
            this.groupBoxView.Controls.Add(this.groupBoxBorder);
            this.groupBoxView.Controls.Add(this.groupBoxPhase);
            this.groupBoxView.Enabled = false;
            this.groupBoxView.Location = new System.Drawing.Point(14, 491);
            this.groupBoxView.Name = "groupBoxView";
            this.groupBoxView.Size = new System.Drawing.Size(360, 183);
            this.groupBoxView.TabIndex = 17;
            this.groupBoxView.TabStop = false;
            this.groupBoxView.Text = "View";
            // 
            // groupBoxSubstructure
            // 
            this.groupBoxSubstructure.Controls.Add(this.checkBoxSubstructureVisible);
            this.groupBoxSubstructure.Location = new System.Drawing.Point(242, 21);
            this.groupBoxSubstructure.Name = "groupBoxSubstructure";
            this.groupBoxSubstructure.Size = new System.Drawing.Size(112, 152);
            this.groupBoxSubstructure.TabIndex = 2;
            this.groupBoxSubstructure.TabStop = false;
            this.groupBoxSubstructure.Text = "Substructure";
            // 
            // checkBoxSubstructureVisible
            // 
            this.checkBoxSubstructureVisible.AutoSize = true;
            this.checkBoxSubstructureVisible.Checked = true;
            this.checkBoxSubstructureVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSubstructureVisible.Location = new System.Drawing.Point(6, 21);
            this.checkBoxSubstructureVisible.Name = "checkBoxSubstructureVisible";
            this.checkBoxSubstructureVisible.Size = new System.Drawing.Size(71, 21);
            this.checkBoxSubstructureVisible.TabIndex = 19;
            this.checkBoxSubstructureVisible.Text = "Visible";
            this.checkBoxSubstructureVisible.UseVisualStyleBackColor = true;
            this.checkBoxSubstructureVisible.CheckedChanged += new System.EventHandler(this.checkBoxSubstructureVisible_CheckedChanged);
            // 
            // groupBoxBorder
            // 
            this.groupBoxBorder.Controls.Add(this.labelThickness);
            this.groupBoxBorder.Controls.Add(this.numericUpDownThickness);
            this.groupBoxBorder.Controls.Add(this.buttonClearBorders);
            this.groupBoxBorder.Controls.Add(this.buttonDrawBorders);
            this.groupBoxBorder.Controls.Add(this.checkBoxBorderVisible);
            this.groupBoxBorder.Location = new System.Drawing.Point(124, 21);
            this.groupBoxBorder.Name = "groupBoxBorder";
            this.groupBoxBorder.Size = new System.Drawing.Size(112, 152);
            this.groupBoxBorder.TabIndex = 1;
            this.groupBoxBorder.TabStop = false;
            this.groupBoxBorder.Text = "Borders";
            // 
            // labelThickness
            // 
            this.labelThickness.AutoSize = true;
            this.labelThickness.Location = new System.Drawing.Point(3, 45);
            this.labelThickness.Name = "labelThickness";
            this.labelThickness.Size = new System.Drawing.Size(72, 17);
            this.labelThickness.TabIndex = 18;
            this.labelThickness.Text = "Thickness";
            // 
            // numericUpDownThickness
            // 
            this.numericUpDownThickness.Location = new System.Drawing.Point(6, 65);
            this.numericUpDownThickness.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownThickness.Name = "numericUpDownThickness";
            this.numericUpDownThickness.Size = new System.Drawing.Size(100, 22);
            this.numericUpDownThickness.TabIndex = 17;
            this.numericUpDownThickness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownThickness.ValueChanged += new System.EventHandler(this.numericUpDownThickness_ValueChanged);
            this.numericUpDownThickness.Leave += new System.EventHandler(this.numericUpDownThickness_Leave);
            // 
            // buttonClearBorders
            // 
            this.buttonClearBorders.Location = new System.Drawing.Point(6, 122);
            this.buttonClearBorders.Name = "buttonClearBorders";
            this.buttonClearBorders.Size = new System.Drawing.Size(100, 23);
            this.buttonClearBorders.TabIndex = 3;
            this.buttonClearBorders.Text = "Clear all";
            this.buttonClearBorders.UseVisualStyleBackColor = true;
            this.buttonClearBorders.Click += new System.EventHandler(this.buttonClearBorders_Click);
            // 
            // buttonDrawBorders
            // 
            this.buttonDrawBorders.Location = new System.Drawing.Point(6, 93);
            this.buttonDrawBorders.Name = "buttonDrawBorders";
            this.buttonDrawBorders.Size = new System.Drawing.Size(100, 23);
            this.buttonDrawBorders.TabIndex = 2;
            this.buttonDrawBorders.Text = "Draw all";
            this.buttonDrawBorders.UseVisualStyleBackColor = true;
            this.buttonDrawBorders.Click += new System.EventHandler(this.buttonDrawBorders_Click);
            // 
            // checkBoxBorderVisible
            // 
            this.checkBoxBorderVisible.AutoSize = true;
            this.checkBoxBorderVisible.Checked = true;
            this.checkBoxBorderVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBorderVisible.Location = new System.Drawing.Point(6, 21);
            this.checkBoxBorderVisible.Name = "checkBoxBorderVisible";
            this.checkBoxBorderVisible.Size = new System.Drawing.Size(71, 21);
            this.checkBoxBorderVisible.TabIndex = 1;
            this.checkBoxBorderVisible.Text = "Visible";
            this.checkBoxBorderVisible.UseVisualStyleBackColor = true;
            this.checkBoxBorderVisible.CheckedChanged += new System.EventHandler(this.checkBoxBorderVisible_CheckedChanged);
            // 
            // groupBoxPhase
            // 
            this.groupBoxPhase.Controls.Add(this.buttonClearPhases);
            this.groupBoxPhase.Controls.Add(this.checkBoxPhaseVisible);
            this.groupBoxPhase.Location = new System.Drawing.Point(6, 21);
            this.groupBoxPhase.Name = "groupBoxPhase";
            this.groupBoxPhase.Size = new System.Drawing.Size(112, 152);
            this.groupBoxPhase.TabIndex = 0;
            this.groupBoxPhase.TabStop = false;
            this.groupBoxPhase.Text = "Phase";
            // 
            // buttonClearPhases
            // 
            this.buttonClearPhases.Location = new System.Drawing.Point(6, 48);
            this.buttonClearPhases.Name = "buttonClearPhases";
            this.buttonClearPhases.Size = new System.Drawing.Size(100, 23);
            this.buttonClearPhases.TabIndex = 19;
            this.buttonClearPhases.Text = "Clear all";
            this.buttonClearPhases.UseVisualStyleBackColor = true;
            this.buttonClearPhases.Click += new System.EventHandler(this.buttonClearPhases_Click);
            // 
            // checkBoxPhaseVisible
            // 
            this.checkBoxPhaseVisible.AutoSize = true;
            this.checkBoxPhaseVisible.Checked = true;
            this.checkBoxPhaseVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPhaseVisible.Location = new System.Drawing.Point(6, 21);
            this.checkBoxPhaseVisible.Name = "checkBoxPhaseVisible";
            this.checkBoxPhaseVisible.Size = new System.Drawing.Size(71, 21);
            this.checkBoxPhaseVisible.TabIndex = 0;
            this.checkBoxPhaseVisible.Text = "Visible";
            this.checkBoxPhaseVisible.UseVisualStyleBackColor = true;
            this.checkBoxPhaseVisible.CheckedChanged += new System.EventHandler(this.checkBoxPhaseVisible_CheckedChanged);
            // 
            // groupBoxSimulation
            // 
            this.groupBoxSimulation.Controls.Add(this.labelProbability);
            this.groupBoxSimulation.Controls.Add(this.numericUpDownProbability);
            this.groupBoxSimulation.Controls.Add(this.comboBoxSimulationType);
            this.groupBoxSimulation.Controls.Add(this.labelSimulationType);
            this.groupBoxSimulation.Location = new System.Drawing.Point(14, 108);
            this.groupBoxSimulation.Name = "groupBoxSimulation";
            this.groupBoxSimulation.Size = new System.Drawing.Size(360, 119);
            this.groupBoxSimulation.TabIndex = 11;
            this.groupBoxSimulation.TabStop = false;
            this.groupBoxSimulation.Text = "Simulation";
            // 
            // labelProbability
            // 
            this.labelProbability.AutoSize = true;
            this.labelProbability.Location = new System.Drawing.Point(6, 65);
            this.labelProbability.Name = "labelProbability";
            this.labelProbability.Size = new System.Drawing.Size(180, 17);
            this.labelProbability.TabIndex = 15;
            this.labelProbability.Text = "Probability of a new cell [%]";
            // 
            // numericUpDownProbability
            // 
            this.numericUpDownProbability.Enabled = false;
            this.numericUpDownProbability.Location = new System.Drawing.Point(6, 85);
            this.numericUpDownProbability.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownProbability.Name = "numericUpDownProbability";
            this.numericUpDownProbability.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownProbability.TabIndex = 14;
            this.numericUpDownProbability.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownProbability.Leave += new System.EventHandler(this.numericUpDownProbability_Leave);
            // 
            // comboBoxSimulationType
            // 
            this.comboBoxSimulationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSimulationType.FormattingEnabled = true;
            this.comboBoxSimulationType.Location = new System.Drawing.Point(6, 38);
            this.comboBoxSimulationType.Name = "comboBoxSimulationType";
            this.comboBoxSimulationType.Size = new System.Drawing.Size(120, 24);
            this.comboBoxSimulationType.TabIndex = 14;
            this.comboBoxSimulationType.SelectedIndexChanged += new System.EventHandler(this.comboBoxSimulationType_SelectedIndexChanged);
            // 
            // groupBoxInclusions
            // 
            this.groupBoxInclusions.Controls.Add(this.labelInclusionType);
            this.groupBoxInclusions.Controls.Add(this.comboBoxInclusionType);
            this.groupBoxInclusions.Controls.Add(this.buttonAddInclusions);
            this.groupBoxInclusions.Controls.Add(this.labelInclusionsNumber);
            this.groupBoxInclusions.Controls.Add(this.labelInclusionsRadius);
            this.groupBoxInclusions.Controls.Add(this.numericUpDownInclusionsRadius);
            this.groupBoxInclusions.Controls.Add(this.numericUpDownInclusionsNumber);
            this.groupBoxInclusions.Location = new System.Drawing.Point(14, 361);
            this.groupBoxInclusions.Name = "groupBoxInclusions";
            this.groupBoxInclusions.Size = new System.Drawing.Size(360, 124);
            this.groupBoxInclusions.TabIndex = 13;
            this.groupBoxInclusions.TabStop = false;
            this.groupBoxInclusions.Text = "Inclusions";
            // 
            // labelInclusionType
            // 
            this.labelInclusionType.AutoSize = true;
            this.labelInclusionType.Location = new System.Drawing.Point(3, 66);
            this.labelInclusionType.Name = "labelInclusionType";
            this.labelInclusionType.Size = new System.Drawing.Size(99, 17);
            this.labelInclusionType.TabIndex = 16;
            this.labelInclusionType.Text = "Inclusion Type";
            // 
            // comboBoxInclusionType
            // 
            this.comboBoxInclusionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInclusionType.FormattingEnabled = true;
            this.comboBoxInclusionType.Location = new System.Drawing.Point(6, 89);
            this.comboBoxInclusionType.Name = "comboBoxInclusionType";
            this.comboBoxInclusionType.Size = new System.Drawing.Size(120, 24);
            this.comboBoxInclusionType.TabIndex = 15;
            // 
            // buttonAddInclusions
            // 
            this.buttonAddInclusions.Location = new System.Drawing.Point(268, 40);
            this.buttonAddInclusions.Name = "buttonAddInclusions";
            this.buttonAddInclusions.Size = new System.Drawing.Size(85, 23);
            this.buttonAddInclusions.TabIndex = 14;
            this.buttonAddInclusions.Text = "Add";
            this.buttonAddInclusions.UseVisualStyleBackColor = true;
            this.buttonAddInclusions.Click += new System.EventHandler(this.buttonAddInclusions_Click);
            // 
            // labelInclusionsNumber
            // 
            this.labelInclusionsNumber.AutoSize = true;
            this.labelInclusionsNumber.Location = new System.Drawing.Point(3, 18);
            this.labelInclusionsNumber.Name = "labelInclusionsNumber";
            this.labelInclusionsNumber.Size = new System.Drawing.Size(58, 17);
            this.labelInclusionsNumber.TabIndex = 12;
            this.labelInclusionsNumber.Text = "Number";
            // 
            // labelInclusionsRadius
            // 
            this.labelInclusionsRadius.AutoSize = true;
            this.labelInclusionsRadius.Location = new System.Drawing.Point(139, 18);
            this.labelInclusionsRadius.Name = "labelInclusionsRadius";
            this.labelInclusionsRadius.Size = new System.Drawing.Size(52, 17);
            this.labelInclusionsRadius.TabIndex = 13;
            this.labelInclusionsRadius.Text = "Radius";
            // 
            // numericUpDownInclusionsRadius
            // 
            this.numericUpDownInclusionsRadius.Location = new System.Drawing.Point(142, 41);
            this.numericUpDownInclusionsRadius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownInclusionsRadius.Name = "numericUpDownInclusionsRadius";
            this.numericUpDownInclusionsRadius.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownInclusionsRadius.TabIndex = 11;
            this.numericUpDownInclusionsRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownInclusionsNumber
            // 
            this.numericUpDownInclusionsNumber.Location = new System.Drawing.Point(6, 41);
            this.numericUpDownInclusionsNumber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownInclusionsNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownInclusionsNumber.Name = "numericUpDownInclusionsNumber";
            this.numericUpDownInclusionsNumber.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownInclusionsNumber.TabIndex = 10;
            this.numericUpDownInclusionsNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBoxAnimate
            // 
            this.checkBoxAnimate.AutoSize = true;
            this.checkBoxAnimate.Location = new System.Drawing.Point(273, 775);
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
            this.ClientSize = new System.Drawing.Size(732, 903);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(750, 950);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            this.groupBoxBoard.ResumeLayout(false);
            this.groupBoxBoard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNucleiNumber)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxView.ResumeLayout(false);
            this.groupBoxSubstructure.ResumeLayout(false);
            this.groupBoxSubstructure.PerformLayout();
            this.groupBoxBorder.ResumeLayout(false);
            this.groupBoxBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThickness)).EndInit();
            this.groupBoxPhase.ResumeLayout(false);
            this.groupBoxPhase.PerformLayout();
            this.groupBoxSimulation.ResumeLayout(false);
            this.groupBoxSimulation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProbability)).EndInit();
            this.groupBoxInclusions.ResumeLayout(false);
            this.groupBoxInclusions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInclusionsRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInclusionsNumber)).EndInit();
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
        private System.Windows.Forms.NumericUpDown numericUpDownY;
        private System.Windows.Forms.Label labelSimulationType;
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
        private System.Windows.Forms.GroupBox groupBoxInclusions;
        private System.Windows.Forms.Button buttonAddInclusions;
        private System.Windows.Forms.Label labelInclusionsNumber;
        private System.Windows.Forms.Label labelInclusionsRadius;
        private System.Windows.Forms.NumericUpDown numericUpDownInclusionsRadius;
        private System.Windows.Forms.NumericUpDown numericUpDownInclusionsNumber;
        private System.Windows.Forms.Label labelInclusionType;
        private System.Windows.Forms.ComboBox comboBoxInclusionType;
        private System.Windows.Forms.GroupBox groupBoxSimulation;
        private System.Windows.Forms.ComboBox comboBoxSimulationType;
        private System.Windows.Forms.Label labelProbability;
        private System.Windows.Forms.NumericUpDown numericUpDownProbability;
        private System.Windows.Forms.Label labelXSize;
        private System.Windows.Forms.NumericUpDown numericUpDownX;
        private System.Windows.Forms.GroupBox groupBoxView;
        private System.Windows.Forms.Label label2ndPhase;
        private System.Windows.Forms.GroupBox groupBoxSubstructure;
        private System.Windows.Forms.GroupBox groupBoxBorder;
        private System.Windows.Forms.GroupBox groupBoxPhase;
        private System.Windows.Forms.Button buttonClearBorders;
        private System.Windows.Forms.Button buttonDrawBorders;
        private System.Windows.Forms.CheckBox checkBoxBorderVisible;
        private System.Windows.Forms.CheckBox checkBoxPhaseVisible;
        private System.Windows.Forms.Label labelThickness;
        private System.Windows.Forms.NumericUpDown numericUpDownThickness;
        private System.Windows.Forms.Button buttonClearPhases;
        private System.Windows.Forms.CheckBox checkBoxSubstructureVisible;
    }
}

