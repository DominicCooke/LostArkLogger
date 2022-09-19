using System.Windows.Forms;

namespace LostArkLogger
{
    partial class MainWindow
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.loggedPacketCountLabel = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.processButton = new System.Windows.Forms.Button();
            this.accessoryCount = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.earringCount = new System.Windows.Forms.Label();
            this.ringCount = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.engraving1Choice = new System.Windows.Forms.ComboBox();
            this.engraving1Label = new System.Windows.Forms.Label();
            this.engraving1QuantityLabel = new System.Windows.Forms.Label();
            this.engraving1Quantity_1 = new System.Windows.Forms.TextBox();
            this.engraving2Quantity_1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.engraving3Quantity_1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.engraving3Choice = new System.Windows.Forms.ComboBox();
            this.engraving4Quantity_1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.engraving4Choice = new System.Windows.Forms.ComboBox();
            this.engraving5Quantity_1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.engraving5Choice = new System.Windows.Forms.ComboBox();
            this.engraving6Quantity_1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.engraving6Choice = new System.Windows.Forms.ComboBox();
            this.engraving2Choice = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.maxCost = new System.Windows.Forms.TextBox();
            this.engraving6Quantity_2 = new System.Windows.Forms.TextBox();
            this.engraving5Quantity_2 = new System.Windows.Forms.TextBox();
            this.engraving4Quantity_2 = new System.Windows.Forms.TextBox();
            this.engraving3Quantity_2 = new System.Windows.Forms.TextBox();
            this.engraving2Quantity_2 = new System.Windows.Forms.TextBox();
            this.engraving1Quantity_2 = new System.Windows.Forms.TextBox();
            this.engraving6Quantity_3 = new System.Windows.Forms.TextBox();
            this.engraving5Quantity_3 = new System.Windows.Forms.TextBox();
            this.engraving4Quantity_3 = new System.Windows.Forms.TextBox();
            this.engraving3Quantity_3 = new System.Windows.Forms.TextBox();
            this.engraving2Quantity_3 = new System.Windows.Forms.TextBox();
            this.engraving1Quantity_3 = new System.Windows.Forms.TextBox();
            this.necklaceCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.desiredStatType1 = new System.Windows.Forms.ComboBox();
            this.desiredStatType2 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.engraving6Quantity_4 = new System.Windows.Forms.TextBox();
            this.engraving5Quantity_4 = new System.Windows.Forms.TextBox();
            this.engraving4Quantity_4 = new System.Windows.Forms.TextBox();
            this.engraving3Quantity_4 = new System.Windows.Forms.TextBox();
            this.engraving2Quantity_4 = new System.Windows.Forms.TextBox();
            this.engraving1Quantity_4 = new System.Windows.Forms.TextBox();
            this.engraving6Quantity_5 = new System.Windows.Forms.TextBox();
            this.engraving5Quantity_5 = new System.Windows.Forms.TextBox();
            this.engraving4Quantity_5 = new System.Windows.Forms.TextBox();
            this.engraving3Quantity_5 = new System.Windows.Forms.TextBox();
            this.engraving2Quantity_5 = new System.Windows.Forms.TextBox();
            this.engraving1Quantity_5 = new System.Windows.Forms.TextBox();
            this.engraving6Quantity_6 = new System.Windows.Forms.TextBox();
            this.engraving5Quantity_6 = new System.Windows.Forms.TextBox();
            this.engraving4Quantity_6 = new System.Windows.Forms.TextBox();
            this.engraving3Quantity_6 = new System.Windows.Forms.TextBox();
            this.engraving2Quantity_6 = new System.Windows.Forms.TextBox();
            this.engraving1Quantity_6 = new System.Windows.Forms.TextBox();
            this.saveLastEngravingsButton = new System.Windows.Forms.Button();
            this.loadLastEngravingsButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cheapest_Textbox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.highestStat1_textBox = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.highestStat2_textBox = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cheapest500HighStat1_textBox = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.cheapest500HighStat2_textBox = new System.Windows.Forms.TextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.cheapestWithRelicNeck_textBox = new System.Windows.Forms.TextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.cheapest80Q_textBox = new System.Windows.Forms.TextBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.cheapest90Q_textBox = new System.Windows.Forms.TextBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.cheapest95Q_textBox = new System.Windows.Forms.TextBox();
            this.reuse_checkBox = new System.Windows.Forms.CheckBox();
            this.message_Label = new System.Windows.Forms.Label();
            this.filterWorryingNeg_checkBox = new System.Windows.Forms.CheckBox();
            this.filterZeroNegEngraving_checkBox = new System.Windows.Forms.CheckBox();
            this.min_stat1 = new System.Windows.Forms.TextBox();
            this.min_stat2 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.sniffModeCheckbox = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.loggedAuctionPacketCountLabel = new System.Windows.Forms.Label();
            this.manualNegativeEngravingInputsCheckBox = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.atkPowMax = new System.Windows.Forms.TextBox();
            this.atkSpdMax = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.defMax = new System.Windows.Forms.TextBox();
            this.moveSpdMax = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.maxNegEngValuesPanel = new System.Windows.Forms.Panel();
            this.stat1CostChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.stat2CostChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.minCost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.maxNegEngValuesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stat1CostChart)).BeginInit();
            this.tabPage11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stat2CostChart)).BeginInit();
            this.SuspendLayout();
            // 
            // loggedPacketCountLabel
            // 
            this.loggedPacketCountLabel.AutoSize = true;
            this.loggedPacketCountLabel.Location = new System.Drawing.Point(13, 10);
            this.loggedPacketCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.loggedPacketCountLabel.Name = "loggedPacketCountLabel";
            this.loggedPacketCountLabel.Size = new System.Drawing.Size(100, 13);
            this.loggedPacketCountLabel.TabIndex = 2;
            this.loggedPacketCountLabel.Text = "Logged Packets : 0";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(68, 133);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(56, 20);
            this.clearButton.TabIndex = 13;
            this.clearButton.Text = "Clear All";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // processButton
            // 
            this.processButton.Location = new System.Drawing.Point(12, 211);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(111, 43);
            this.processButton.TabIndex = 14;
            this.processButton.Text = "Process Permutations";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // accessoryCount
            // 
            this.accessoryCount.AutoSize = true;
            this.accessoryCount.Location = new System.Drawing.Point(113, 71);
            this.accessoryCount.Name = "accessoryCount";
            this.accessoryCount.Size = new System.Drawing.Size(13, 13);
            this.accessoryCount.TabIndex = 15;
            this.accessoryCount.Text = "0";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(12, 133);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(56, 20);
            this.refreshButton.TabIndex = 16;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Loaded Necklaces:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Loaded Earrings:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Loaded Rings:";
            // 
            // earringCount
            // 
            this.earringCount.AutoSize = true;
            this.earringCount.Location = new System.Drawing.Point(113, 27);
            this.earringCount.Name = "earringCount";
            this.earringCount.Size = new System.Drawing.Size(10, 13);
            this.earringCount.TabIndex = 21;
            this.earringCount.Text = "-";
            // 
            // ringCount
            // 
            this.ringCount.AutoSize = true;
            this.ringCount.Location = new System.Drawing.Point(113, 49);
            this.ringCount.Name = "ringCount";
            this.ringCount.Size = new System.Drawing.Size(10, 13);
            this.ringCount.TabIndex = 22;
            this.ringCount.Text = "-";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 159);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(113, 20);
            this.saveButton.TabIndex = 23;
            this.saveButton.Text = "Save All Accs";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(12, 185);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(112, 20);
            this.loadButton.TabIndex = 24;
            this.loadButton.Text = "Load Accs";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // engraving1Choice
            // 
            this.engraving1Choice.FormattingEnabled = true;
            this.engraving1Choice.Location = new System.Drawing.Point(751, 42);
            this.engraving1Choice.Name = "engraving1Choice";
            this.engraving1Choice.Size = new System.Drawing.Size(142, 21);
            this.engraving1Choice.TabIndex = 25;
            // 
            // engraving1Label
            // 
            this.engraving1Label.AutoSize = true;
            this.engraving1Label.Location = new System.Drawing.Point(751, 27);
            this.engraving1Label.Name = "engraving1Label";
            this.engraving1Label.Size = new System.Drawing.Size(64, 13);
            this.engraving1Label.TabIndex = 26;
            this.engraving1Label.Text = "Engraving 1";
            // 
            // engraving1QuantityLabel
            // 
            this.engraving1QuantityLabel.AutoSize = true;
            this.engraving1QuantityLabel.Location = new System.Drawing.Point(902, 25);
            this.engraving1QuantityLabel.Name = "engraving1QuantityLabel";
            this.engraving1QuantityLabel.Size = new System.Drawing.Size(189, 13);
            this.engraving1QuantityLabel.TabIndex = 27;
            this.engraving1QuantityLabel.Text = "Minimum amount of engraving required";
            // 
            // engraving1Quantity_1
            // 
            this.engraving1Quantity_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.engraving1Quantity_1.Location = new System.Drawing.Point(905, 42);
            this.engraving1Quantity_1.Name = "engraving1Quantity_1";
            this.engraving1Quantity_1.Size = new System.Drawing.Size(30, 20);
            this.engraving1Quantity_1.TabIndex = 28;
            this.engraving1Quantity_1.Text = "0";
            this.engraving1Quantity_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving2Quantity_1
            // 
            this.engraving2Quantity_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.engraving2Quantity_1.Location = new System.Drawing.Point(905, 87);
            this.engraving2Quantity_1.Name = "engraving2Quantity_1";
            this.engraving2Quantity_1.Size = new System.Drawing.Size(30, 20);
            this.engraving2Quantity_1.TabIndex = 32;
            this.engraving2Quantity_1.Text = "0";
            this.engraving2Quantity_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(751, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Engraving 2";
            // 
            // engraving3Quantity_1
            // 
            this.engraving3Quantity_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.engraving3Quantity_1.Location = new System.Drawing.Point(905, 131);
            this.engraving3Quantity_1.Name = "engraving3Quantity_1";
            this.engraving3Quantity_1.Size = new System.Drawing.Size(30, 20);
            this.engraving3Quantity_1.TabIndex = 36;
            this.engraving3Quantity_1.Text = "0";
            this.engraving3Quantity_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(751, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Engraving 3";
            // 
            // engraving3Choice
            // 
            this.engraving3Choice.FormattingEnabled = true;
            this.engraving3Choice.Location = new System.Drawing.Point(751, 131);
            this.engraving3Choice.Name = "engraving3Choice";
            this.engraving3Choice.Size = new System.Drawing.Size(142, 21);
            this.engraving3Choice.TabIndex = 33;
            // 
            // engraving4Quantity_1
            // 
            this.engraving4Quantity_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.engraving4Quantity_1.Location = new System.Drawing.Point(905, 175);
            this.engraving4Quantity_1.Name = "engraving4Quantity_1";
            this.engraving4Quantity_1.Size = new System.Drawing.Size(30, 20);
            this.engraving4Quantity_1.TabIndex = 40;
            this.engraving4Quantity_1.Text = "0";
            this.engraving4Quantity_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(751, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Engraving 4";
            // 
            // engraving4Choice
            // 
            this.engraving4Choice.FormattingEnabled = true;
            this.engraving4Choice.Location = new System.Drawing.Point(751, 175);
            this.engraving4Choice.Name = "engraving4Choice";
            this.engraving4Choice.Size = new System.Drawing.Size(142, 21);
            this.engraving4Choice.TabIndex = 37;
            // 
            // engraving5Quantity_1
            // 
            this.engraving5Quantity_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.engraving5Quantity_1.Location = new System.Drawing.Point(905, 219);
            this.engraving5Quantity_1.Name = "engraving5Quantity_1";
            this.engraving5Quantity_1.Size = new System.Drawing.Size(30, 20);
            this.engraving5Quantity_1.TabIndex = 44;
            this.engraving5Quantity_1.Text = "0";
            this.engraving5Quantity_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(751, 204);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 42;
            this.label11.Text = "Engraving 5";
            // 
            // engraving5Choice
            // 
            this.engraving5Choice.FormattingEnabled = true;
            this.engraving5Choice.Location = new System.Drawing.Point(751, 219);
            this.engraving5Choice.Name = "engraving5Choice";
            this.engraving5Choice.Size = new System.Drawing.Size(142, 21);
            this.engraving5Choice.TabIndex = 41;
            // 
            // engraving6Quantity_1
            // 
            this.engraving6Quantity_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.engraving6Quantity_1.Location = new System.Drawing.Point(905, 263);
            this.engraving6Quantity_1.Name = "engraving6Quantity_1";
            this.engraving6Quantity_1.Size = new System.Drawing.Size(30, 20);
            this.engraving6Quantity_1.TabIndex = 48;
            this.engraving6Quantity_1.Text = "0";
            this.engraving6Quantity_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(751, 248);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 46;
            this.label13.Text = "Engraving 6";
            // 
            // engraving6Choice
            // 
            this.engraving6Choice.FormattingEnabled = true;
            this.engraving6Choice.Location = new System.Drawing.Point(751, 263);
            this.engraving6Choice.Name = "engraving6Choice";
            this.engraving6Choice.Size = new System.Drawing.Size(142, 21);
            this.engraving6Choice.TabIndex = 45;
            // 
            // engraving2Choice
            // 
            this.engraving2Choice.FormattingEnabled = true;
            this.engraving2Choice.Location = new System.Drawing.Point(751, 87);
            this.engraving2Choice.Name = "engraving2Choice";
            this.engraving2Choice.Size = new System.Drawing.Size(142, 21);
            this.engraving2Choice.TabIndex = 50;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(170, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(145, 13);
            this.label14.TabIndex = 52;
            this.label14.Text = "Maximum Individual Acc Cost";
            // 
            // maxCost
            // 
            this.maxCost.Location = new System.Drawing.Point(319, 63);
            this.maxCost.Name = "maxCost";
            this.maxCost.Size = new System.Drawing.Size(61, 20);
            this.maxCost.TabIndex = 53;
            this.maxCost.Text = "15001";
            this.maxCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving6Quantity_2
            // 
            this.engraving6Quantity_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.engraving6Quantity_2.Location = new System.Drawing.Point(949, 263);
            this.engraving6Quantity_2.Name = "engraving6Quantity_2";
            this.engraving6Quantity_2.Size = new System.Drawing.Size(30, 20);
            this.engraving6Quantity_2.TabIndex = 59;
            this.engraving6Quantity_2.Text = "0";
            this.engraving6Quantity_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving5Quantity_2
            // 
            this.engraving5Quantity_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.engraving5Quantity_2.Location = new System.Drawing.Point(949, 219);
            this.engraving5Quantity_2.Name = "engraving5Quantity_2";
            this.engraving5Quantity_2.Size = new System.Drawing.Size(30, 20);
            this.engraving5Quantity_2.TabIndex = 58;
            this.engraving5Quantity_2.Text = "0";
            this.engraving5Quantity_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving4Quantity_2
            // 
            this.engraving4Quantity_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.engraving4Quantity_2.Location = new System.Drawing.Point(949, 175);
            this.engraving4Quantity_2.Name = "engraving4Quantity_2";
            this.engraving4Quantity_2.Size = new System.Drawing.Size(30, 20);
            this.engraving4Quantity_2.TabIndex = 57;
            this.engraving4Quantity_2.Text = "0";
            this.engraving4Quantity_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving3Quantity_2
            // 
            this.engraving3Quantity_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.engraving3Quantity_2.Location = new System.Drawing.Point(949, 131);
            this.engraving3Quantity_2.Name = "engraving3Quantity_2";
            this.engraving3Quantity_2.Size = new System.Drawing.Size(30, 20);
            this.engraving3Quantity_2.TabIndex = 56;
            this.engraving3Quantity_2.Text = "0";
            this.engraving3Quantity_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving2Quantity_2
            // 
            this.engraving2Quantity_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.engraving2Quantity_2.Location = new System.Drawing.Point(949, 87);
            this.engraving2Quantity_2.Name = "engraving2Quantity_2";
            this.engraving2Quantity_2.Size = new System.Drawing.Size(30, 20);
            this.engraving2Quantity_2.TabIndex = 55;
            this.engraving2Quantity_2.Text = "0";
            this.engraving2Quantity_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving1Quantity_2
            // 
            this.engraving1Quantity_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.engraving1Quantity_2.Location = new System.Drawing.Point(949, 42);
            this.engraving1Quantity_2.Name = "engraving1Quantity_2";
            this.engraving1Quantity_2.Size = new System.Drawing.Size(30, 20);
            this.engraving1Quantity_2.TabIndex = 54;
            this.engraving1Quantity_2.Text = "0";
            this.engraving1Quantity_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving6Quantity_3
            // 
            this.engraving6Quantity_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.engraving6Quantity_3.Location = new System.Drawing.Point(993, 263);
            this.engraving6Quantity_3.Name = "engraving6Quantity_3";
            this.engraving6Quantity_3.Size = new System.Drawing.Size(30, 20);
            this.engraving6Quantity_3.TabIndex = 65;
            this.engraving6Quantity_3.Text = "0";
            this.engraving6Quantity_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving5Quantity_3
            // 
            this.engraving5Quantity_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.engraving5Quantity_3.Location = new System.Drawing.Point(993, 219);
            this.engraving5Quantity_3.Name = "engraving5Quantity_3";
            this.engraving5Quantity_3.Size = new System.Drawing.Size(30, 20);
            this.engraving5Quantity_3.TabIndex = 64;
            this.engraving5Quantity_3.Text = "0";
            this.engraving5Quantity_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving4Quantity_3
            // 
            this.engraving4Quantity_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.engraving4Quantity_3.Location = new System.Drawing.Point(993, 175);
            this.engraving4Quantity_3.Name = "engraving4Quantity_3";
            this.engraving4Quantity_3.Size = new System.Drawing.Size(30, 20);
            this.engraving4Quantity_3.TabIndex = 63;
            this.engraving4Quantity_3.Text = "0";
            this.engraving4Quantity_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving3Quantity_3
            // 
            this.engraving3Quantity_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.engraving3Quantity_3.Location = new System.Drawing.Point(993, 131);
            this.engraving3Quantity_3.Name = "engraving3Quantity_3";
            this.engraving3Quantity_3.Size = new System.Drawing.Size(30, 20);
            this.engraving3Quantity_3.TabIndex = 62;
            this.engraving3Quantity_3.Text = "0";
            this.engraving3Quantity_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving2Quantity_3
            // 
            this.engraving2Quantity_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.engraving2Quantity_3.Location = new System.Drawing.Point(993, 87);
            this.engraving2Quantity_3.Name = "engraving2Quantity_3";
            this.engraving2Quantity_3.Size = new System.Drawing.Size(30, 20);
            this.engraving2Quantity_3.TabIndex = 61;
            this.engraving2Quantity_3.Text = "0";
            this.engraving2Quantity_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving1Quantity_3
            // 
            this.engraving1Quantity_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.engraving1Quantity_3.Location = new System.Drawing.Point(993, 42);
            this.engraving1Quantity_3.Name = "engraving1Quantity_3";
            this.engraving1Quantity_3.Size = new System.Drawing.Size(30, 20);
            this.engraving1Quantity_3.TabIndex = 60;
            this.engraving1Quantity_3.Text = "0";
            this.engraving1Quantity_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // necklaceCount
            // 
            this.necklaceCount.AutoSize = true;
            this.necklaceCount.Location = new System.Drawing.Point(113, 5);
            this.necklaceCount.Name = "necklaceCount";
            this.necklaceCount.Size = new System.Drawing.Size(10, 13);
            this.necklaceCount.TabIndex = 20;
            this.necklaceCount.Text = "-";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.necklaceCount);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.earringCount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ringCount);
            this.panel1.Controls.Add(this.accessoryCount);
            this.panel1.Location = new System.Drawing.Point(13, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 94);
            this.panel1.TabIndex = 66;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 71);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 13);
            this.label15.TabIndex = 67;
            this.label15.Text = "Total Loaded Accs:";
            // 
            // desiredStatType1
            // 
            this.desiredStatType1.FormattingEnabled = true;
            this.desiredStatType1.Location = new System.Drawing.Point(250, 88);
            this.desiredStatType1.Name = "desiredStatType1";
            this.desiredStatType1.Size = new System.Drawing.Size(130, 21);
            this.desiredStatType1.TabIndex = 67;
            // 
            // desiredStatType2
            // 
            this.desiredStatType2.FormattingEnabled = true;
            this.desiredStatType2.Location = new System.Drawing.Point(250, 137);
            this.desiredStatType2.Name = "desiredStatType2";
            this.desiredStatType2.Size = new System.Drawing.Size(130, 21);
            this.desiredStatType2.TabIndex = 68;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(170, 92);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 13);
            this.label16.TabIndex = 69;
            this.label16.Text = "Desired Stat 1";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(170, 141);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 13);
            this.label17.TabIndex = 70;
            this.label17.Text = "Desired Stat 2";
            // 
            // engraving6Quantity_4
            // 
            this.engraving6Quantity_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.engraving6Quantity_4.Location = new System.Drawing.Point(1037, 263);
            this.engraving6Quantity_4.Name = "engraving6Quantity_4";
            this.engraving6Quantity_4.Size = new System.Drawing.Size(30, 20);
            this.engraving6Quantity_4.TabIndex = 76;
            this.engraving6Quantity_4.Text = "0";
            this.engraving6Quantity_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving5Quantity_4
            // 
            this.engraving5Quantity_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.engraving5Quantity_4.Location = new System.Drawing.Point(1037, 219);
            this.engraving5Quantity_4.Name = "engraving5Quantity_4";
            this.engraving5Quantity_4.Size = new System.Drawing.Size(30, 20);
            this.engraving5Quantity_4.TabIndex = 75;
            this.engraving5Quantity_4.Text = "0";
            this.engraving5Quantity_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving4Quantity_4
            // 
            this.engraving4Quantity_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.engraving4Quantity_4.Location = new System.Drawing.Point(1037, 175);
            this.engraving4Quantity_4.Name = "engraving4Quantity_4";
            this.engraving4Quantity_4.Size = new System.Drawing.Size(30, 20);
            this.engraving4Quantity_4.TabIndex = 74;
            this.engraving4Quantity_4.Text = "0";
            this.engraving4Quantity_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving3Quantity_4
            // 
            this.engraving3Quantity_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.engraving3Quantity_4.Location = new System.Drawing.Point(1037, 131);
            this.engraving3Quantity_4.Name = "engraving3Quantity_4";
            this.engraving3Quantity_4.Size = new System.Drawing.Size(30, 20);
            this.engraving3Quantity_4.TabIndex = 73;
            this.engraving3Quantity_4.Text = "0";
            this.engraving3Quantity_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving2Quantity_4
            // 
            this.engraving2Quantity_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.engraving2Quantity_4.Location = new System.Drawing.Point(1037, 87);
            this.engraving2Quantity_4.Name = "engraving2Quantity_4";
            this.engraving2Quantity_4.Size = new System.Drawing.Size(30, 20);
            this.engraving2Quantity_4.TabIndex = 72;
            this.engraving2Quantity_4.Text = "0";
            this.engraving2Quantity_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving1Quantity_4
            // 
            this.engraving1Quantity_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.engraving1Quantity_4.Location = new System.Drawing.Point(1037, 42);
            this.engraving1Quantity_4.Name = "engraving1Quantity_4";
            this.engraving1Quantity_4.Size = new System.Drawing.Size(30, 20);
            this.engraving1Quantity_4.TabIndex = 71;
            this.engraving1Quantity_4.Text = "0";
            this.engraving1Quantity_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving6Quantity_5
            // 
            this.engraving6Quantity_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.engraving6Quantity_5.Location = new System.Drawing.Point(1081, 263);
            this.engraving6Quantity_5.Name = "engraving6Quantity_5";
            this.engraving6Quantity_5.Size = new System.Drawing.Size(30, 20);
            this.engraving6Quantity_5.TabIndex = 82;
            this.engraving6Quantity_5.Text = "0";
            this.engraving6Quantity_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving5Quantity_5
            // 
            this.engraving5Quantity_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.engraving5Quantity_5.Location = new System.Drawing.Point(1081, 219);
            this.engraving5Quantity_5.Name = "engraving5Quantity_5";
            this.engraving5Quantity_5.Size = new System.Drawing.Size(30, 20);
            this.engraving5Quantity_5.TabIndex = 81;
            this.engraving5Quantity_5.Text = "0";
            this.engraving5Quantity_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving4Quantity_5
            // 
            this.engraving4Quantity_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.engraving4Quantity_5.Location = new System.Drawing.Point(1081, 175);
            this.engraving4Quantity_5.Name = "engraving4Quantity_5";
            this.engraving4Quantity_5.Size = new System.Drawing.Size(30, 20);
            this.engraving4Quantity_5.TabIndex = 80;
            this.engraving4Quantity_5.Text = "0";
            this.engraving4Quantity_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving3Quantity_5
            // 
            this.engraving3Quantity_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.engraving3Quantity_5.Location = new System.Drawing.Point(1081, 131);
            this.engraving3Quantity_5.Name = "engraving3Quantity_5";
            this.engraving3Quantity_5.Size = new System.Drawing.Size(30, 20);
            this.engraving3Quantity_5.TabIndex = 79;
            this.engraving3Quantity_5.Text = "0";
            this.engraving3Quantity_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving2Quantity_5
            // 
            this.engraving2Quantity_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.engraving2Quantity_5.Location = new System.Drawing.Point(1081, 87);
            this.engraving2Quantity_5.Name = "engraving2Quantity_5";
            this.engraving2Quantity_5.Size = new System.Drawing.Size(30, 20);
            this.engraving2Quantity_5.TabIndex = 78;
            this.engraving2Quantity_5.Text = "0";
            this.engraving2Quantity_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving1Quantity_5
            // 
            this.engraving1Quantity_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.engraving1Quantity_5.Location = new System.Drawing.Point(1081, 42);
            this.engraving1Quantity_5.Name = "engraving1Quantity_5";
            this.engraving1Quantity_5.Size = new System.Drawing.Size(30, 20);
            this.engraving1Quantity_5.TabIndex = 77;
            this.engraving1Quantity_5.Text = "0";
            this.engraving1Quantity_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving6Quantity_6
            // 
            this.engraving6Quantity_6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.engraving6Quantity_6.Location = new System.Drawing.Point(1125, 263);
            this.engraving6Quantity_6.Name = "engraving6Quantity_6";
            this.engraving6Quantity_6.Size = new System.Drawing.Size(30, 20);
            this.engraving6Quantity_6.TabIndex = 88;
            this.engraving6Quantity_6.Text = "0";
            this.engraving6Quantity_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving5Quantity_6
            // 
            this.engraving5Quantity_6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.engraving5Quantity_6.Location = new System.Drawing.Point(1125, 219);
            this.engraving5Quantity_6.Name = "engraving5Quantity_6";
            this.engraving5Quantity_6.Size = new System.Drawing.Size(30, 20);
            this.engraving5Quantity_6.TabIndex = 87;
            this.engraving5Quantity_6.Text = "0";
            this.engraving5Quantity_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving4Quantity_6
            // 
            this.engraving4Quantity_6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.engraving4Quantity_6.Location = new System.Drawing.Point(1125, 175);
            this.engraving4Quantity_6.Name = "engraving4Quantity_6";
            this.engraving4Quantity_6.Size = new System.Drawing.Size(30, 20);
            this.engraving4Quantity_6.TabIndex = 86;
            this.engraving4Quantity_6.Text = "0";
            this.engraving4Quantity_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving3Quantity_6
            // 
            this.engraving3Quantity_6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.engraving3Quantity_6.Location = new System.Drawing.Point(1125, 131);
            this.engraving3Quantity_6.Name = "engraving3Quantity_6";
            this.engraving3Quantity_6.Size = new System.Drawing.Size(30, 20);
            this.engraving3Quantity_6.TabIndex = 85;
            this.engraving3Quantity_6.Text = "0";
            this.engraving3Quantity_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving2Quantity_6
            // 
            this.engraving2Quantity_6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.engraving2Quantity_6.Location = new System.Drawing.Point(1125, 87);
            this.engraving2Quantity_6.Name = "engraving2Quantity_6";
            this.engraving2Quantity_6.Size = new System.Drawing.Size(30, 20);
            this.engraving2Quantity_6.TabIndex = 84;
            this.engraving2Quantity_6.Text = "0";
            this.engraving2Quantity_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engraving1Quantity_6
            // 
            this.engraving1Quantity_6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.engraving1Quantity_6.Location = new System.Drawing.Point(1125, 42);
            this.engraving1Quantity_6.Name = "engraving1Quantity_6";
            this.engraving1Quantity_6.Size = new System.Drawing.Size(30, 20);
            this.engraving1Quantity_6.TabIndex = 83;
            this.engraving1Quantity_6.Text = "0";
            this.engraving1Quantity_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // saveLastEngravingsButton
            // 
            this.saveLastEngravingsButton.Location = new System.Drawing.Point(897, 293);
            this.saveLastEngravingsButton.Name = "saveLastEngravingsButton";
            this.saveLastEngravingsButton.Size = new System.Drawing.Size(117, 20);
            this.saveLastEngravingsButton.TabIndex = 89;
            this.saveLastEngravingsButton.Text = "Save Engraving Profile";
            this.saveLastEngravingsButton.UseVisualStyleBackColor = true;
            this.saveLastEngravingsButton.Click += new System.EventHandler(this.saveLastEngravingsButton_Click);
            // 
            // loadLastEngravingsButton
            // 
            this.loadLastEngravingsButton.Location = new System.Drawing.Point(1019, 293);
            this.loadLastEngravingsButton.Name = "loadLastEngravingsButton";
            this.loadLastEngravingsButton.Size = new System.Drawing.Size(141, 20);
            this.loadLastEngravingsButton.TabIndex = 90;
            this.loadLastEngravingsButton.Text = "Load Last Engraving Profile";
            this.loadLastEngravingsButton.UseVisualStyleBackColor = true;
            this.loadLastEngravingsButton.Click += new System.EventHandler(this.loadLastEngravingsButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage11);
            this.tabControl1.Location = new System.Drawing.Point(12, 317);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1156, 521);
            this.tabControl1.TabIndex = 92;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cheapest_Textbox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1148, 495);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cheapest";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cheapest_Textbox
            // 
            this.cheapest_Textbox.BackColor = System.Drawing.Color.Black;
            this.cheapest_Textbox.ForeColor = System.Drawing.Color.White;
            this.cheapest_Textbox.Location = new System.Drawing.Point(-3, -8);
            this.cheapest_Textbox.Multiline = true;
            this.cheapest_Textbox.Name = "cheapest_Textbox";
            this.cheapest_Textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cheapest_Textbox.Size = new System.Drawing.Size(1157, 513);
            this.cheapest_Textbox.TabIndex = 92;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.highestStat1_textBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1148, 495);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Highest Stat 1";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // highestStat1_textBox
            // 
            this.highestStat1_textBox.BackColor = System.Drawing.Color.Black;
            this.highestStat1_textBox.ForeColor = System.Drawing.Color.White;
            this.highestStat1_textBox.Location = new System.Drawing.Point(-3, -8);
            this.highestStat1_textBox.Multiline = true;
            this.highestStat1_textBox.Name = "highestStat1_textBox";
            this.highestStat1_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.highestStat1_textBox.Size = new System.Drawing.Size(1157, 513);
            this.highestStat1_textBox.TabIndex = 92;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.highestStat2_textBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1148, 495);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Highest Stat 2";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // highestStat2_textBox
            // 
            this.highestStat2_textBox.BackColor = System.Drawing.Color.Black;
            this.highestStat2_textBox.ForeColor = System.Drawing.Color.White;
            this.highestStat2_textBox.Location = new System.Drawing.Point(-3, -8);
            this.highestStat2_textBox.Multiline = true;
            this.highestStat2_textBox.Name = "highestStat2_textBox";
            this.highestStat2_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.highestStat2_textBox.Size = new System.Drawing.Size(1157, 513);
            this.highestStat2_textBox.TabIndex = 92;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cheapest500HighStat1_textBox);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1148, 495);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Cheapest 500 with Highest Stat 1";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cheapest500HighStat1_textBox
            // 
            this.cheapest500HighStat1_textBox.BackColor = System.Drawing.Color.Black;
            this.cheapest500HighStat1_textBox.ForeColor = System.Drawing.Color.White;
            this.cheapest500HighStat1_textBox.Location = new System.Drawing.Point(-3, -8);
            this.cheapest500HighStat1_textBox.Multiline = true;
            this.cheapest500HighStat1_textBox.Name = "cheapest500HighStat1_textBox";
            this.cheapest500HighStat1_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cheapest500HighStat1_textBox.Size = new System.Drawing.Size(1157, 513);
            this.cheapest500HighStat1_textBox.TabIndex = 92;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.cheapest500HighStat2_textBox);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1148, 495);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Cheapest 500 with Highest Stat 2";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // cheapest500HighStat2_textBox
            // 
            this.cheapest500HighStat2_textBox.BackColor = System.Drawing.Color.Black;
            this.cheapest500HighStat2_textBox.ForeColor = System.Drawing.Color.White;
            this.cheapest500HighStat2_textBox.Location = new System.Drawing.Point(-3, -8);
            this.cheapest500HighStat2_textBox.Multiline = true;
            this.cheapest500HighStat2_textBox.Name = "cheapest500HighStat2_textBox";
            this.cheapest500HighStat2_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cheapest500HighStat2_textBox.Size = new System.Drawing.Size(1157, 513);
            this.cheapest500HighStat2_textBox.TabIndex = 92;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.cheapestWithRelicNeck_textBox);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1148, 495);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Cheapest With Relic Neck";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // cheapestWithRelicNeck_textBox
            // 
            this.cheapestWithRelicNeck_textBox.BackColor = System.Drawing.Color.Black;
            this.cheapestWithRelicNeck_textBox.ForeColor = System.Drawing.Color.White;
            this.cheapestWithRelicNeck_textBox.Location = new System.Drawing.Point(-3, -8);
            this.cheapestWithRelicNeck_textBox.Multiline = true;
            this.cheapestWithRelicNeck_textBox.Name = "cheapestWithRelicNeck_textBox";
            this.cheapestWithRelicNeck_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cheapestWithRelicNeck_textBox.Size = new System.Drawing.Size(1157, 513);
            this.cheapestWithRelicNeck_textBox.TabIndex = 92;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.cheapest80Q_textBox);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(1148, 495);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Cheapest > 80Q";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // cheapest80Q_textBox
            // 
            this.cheapest80Q_textBox.BackColor = System.Drawing.Color.Black;
            this.cheapest80Q_textBox.ForeColor = System.Drawing.Color.White;
            this.cheapest80Q_textBox.Location = new System.Drawing.Point(-3, -8);
            this.cheapest80Q_textBox.Multiline = true;
            this.cheapest80Q_textBox.Name = "cheapest80Q_textBox";
            this.cheapest80Q_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cheapest80Q_textBox.Size = new System.Drawing.Size(1157, 513);
            this.cheapest80Q_textBox.TabIndex = 92;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.cheapest90Q_textBox);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(1148, 495);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "Cheapest > 90Q";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // cheapest90Q_textBox
            // 
            this.cheapest90Q_textBox.BackColor = System.Drawing.Color.Black;
            this.cheapest90Q_textBox.ForeColor = System.Drawing.Color.White;
            this.cheapest90Q_textBox.Location = new System.Drawing.Point(-3, -8);
            this.cheapest90Q_textBox.Multiline = true;
            this.cheapest90Q_textBox.Name = "cheapest90Q_textBox";
            this.cheapest90Q_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cheapest90Q_textBox.Size = new System.Drawing.Size(1157, 513);
            this.cheapest90Q_textBox.TabIndex = 92;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.cheapest95Q_textBox);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(1148, 495);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Text = "Cheapest > 95Q";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // cheapest95Q_textBox
            // 
            this.cheapest95Q_textBox.BackColor = System.Drawing.Color.Black;
            this.cheapest95Q_textBox.ForeColor = System.Drawing.Color.White;
            this.cheapest95Q_textBox.Location = new System.Drawing.Point(-3, -8);
            this.cheapest95Q_textBox.Multiline = true;
            this.cheapest95Q_textBox.Name = "cheapest95Q_textBox";
            this.cheapest95Q_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cheapest95Q_textBox.Size = new System.Drawing.Size(1157, 513);
            this.cheapest95Q_textBox.TabIndex = 92;
            // 
            // reuse_checkBox
            // 
            this.reuse_checkBox.AutoSize = true;
            this.reuse_checkBox.Location = new System.Drawing.Point(12, 262);
            this.reuse_checkBox.Name = "reuse_checkBox";
            this.reuse_checkBox.Size = new System.Drawing.Size(143, 17);
            this.reuse_checkBox.TabIndex = 93;
            this.reuse_checkBox.Text = "Use Stored Permutations";
            this.reuse_checkBox.UseVisualStyleBackColor = true;
            // 
            // message_Label
            // 
            this.message_Label.AutoSize = true;
            this.message_Label.Location = new System.Drawing.Point(13, 301);
            this.message_Label.Name = "message_Label";
            this.message_Label.Size = new System.Drawing.Size(42, 13);
            this.message_Label.TabIndex = 94;
            this.message_Label.Text = "Results";
            // 
            // filterWorryingNeg_checkBox
            // 
            this.filterWorryingNeg_checkBox.AutoSize = true;
            this.filterWorryingNeg_checkBox.Checked = true;
            this.filterWorryingNeg_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.filterWorryingNeg_checkBox.Location = new System.Drawing.Point(401, 38);
            this.filterWorryingNeg_checkBox.Name = "filterWorryingNeg_checkBox";
            this.filterWorryingNeg_checkBox.Size = new System.Drawing.Size(166, 17);
            this.filterWorryingNeg_checkBox.TabIndex = 95;
            this.filterWorryingNeg_checkBox.Text = "Filter >=5 Negative Engraving";
            this.filterWorryingNeg_checkBox.UseVisualStyleBackColor = true;
            // 
            // filterZeroNegEngraving_checkBox
            // 
            this.filterZeroNegEngraving_checkBox.AutoSize = true;
            this.filterZeroNegEngraving_checkBox.Checked = true;
            this.filterZeroNegEngraving_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.filterZeroNegEngraving_checkBox.Location = new System.Drawing.Point(401, 61);
            this.filterZeroNegEngraving_checkBox.Name = "filterZeroNegEngraving_checkBox";
            this.filterZeroNegEngraving_checkBox.Size = new System.Drawing.Size(197, 17);
            this.filterZeroNegEngraving_checkBox.TabIndex = 96;
            this.filterZeroNegEngraving_checkBox.Text = "Atleast one Negative Engraving at 0";
            this.filterZeroNegEngraving_checkBox.UseVisualStyleBackColor = true;
            // 
            // min_stat1
            // 
            this.min_stat1.Location = new System.Drawing.Point(319, 112);
            this.min_stat1.Name = "min_stat1";
            this.min_stat1.Size = new System.Drawing.Size(61, 20);
            this.min_stat1.TabIndex = 97;
            this.min_stat1.Text = "0";
            this.min_stat1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // min_stat2
            // 
            this.min_stat2.Location = new System.Drawing.Point(319, 162);
            this.min_stat2.Name = "min_stat2";
            this.min_stat2.Size = new System.Drawing.Size(61, 20);
            this.min_stat2.TabIndex = 98;
            this.min_stat2.Text = "0";
            this.min_stat2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(170, 116);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 13);
            this.label18.TabIndex = 99;
            this.label18.Text = "Min Amount";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(170, 166);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 13);
            this.label19.TabIndex = 100;
            this.label19.Text = "Min Amount";
            // 
            // sniffModeCheckbox
            // 
            this.sniffModeCheckbox.AutoSize = true;
            this.sniffModeCheckbox.Location = new System.Drawing.Point(291, 8);
            this.sniffModeCheckbox.Name = "sniffModeCheckbox";
            this.sniffModeCheckbox.Size = new System.Drawing.Size(75, 17);
            this.sniffModeCheckbox.TabIndex = 101;
            this.sniffModeCheckbox.Text = "Winpcap?";
            this.sniffModeCheckbox.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(539, 12);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(95, 13);
            this.label20.TabIndex = 102;
            this.label20.Text = "Parser by Shalzuth";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(635, 12);
            this.versionLabel.Name = "label22";
            this.versionLabel.Size = new System.Drawing.Size(69, 13);
            this.versionLabel.TabIndex = 103;
            this.versionLabel.Text = "Version X.X.X";
            // 
            // loggedAuctionPacketCountLabel
            // 
            this.loggedAuctionPacketCountLabel.AutoSize = true;
            this.loggedAuctionPacketCountLabel.Location = new System.Drawing.Point(121, 10);
            this.loggedAuctionPacketCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.loggedAuctionPacketCountLabel.Name = "loggedAuctionPacketCountLabel";
            this.loggedAuctionPacketCountLabel.Size = new System.Drawing.Size(139, 13);
            this.loggedAuctionPacketCountLabel.TabIndex = 104;
            this.loggedAuctionPacketCountLabel.Text = "Logged Auction Packets : 0";
            // 
            // manualNegativeEngravingInputsCheckBox
            // 
            this.manualNegativeEngravingInputsCheckBox.AutoSize = true;
            this.manualNegativeEngravingInputsCheckBox.Location = new System.Drawing.Point(400, 84);
            this.manualNegativeEngravingInputsCheckBox.Name = "manualNegativeEngravingInputsCheckBox";
            this.manualNegativeEngravingInputsCheckBox.Size = new System.Drawing.Size(190, 17);
            this.manualNegativeEngravingInputsCheckBox.TabIndex = 105;
            this.manualNegativeEngravingInputsCheckBox.Text = "Manual Negative Engraving Inputs";
            this.manualNegativeEngravingInputsCheckBox.UseVisualStyleBackColor = true;
            this.manualNegativeEngravingInputsCheckBox.CheckedChanged += new System.EventHandler(this.manualNegativeEngravingInputsCheckBox_CheckedChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(4, 26);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 13);
            this.label23.TabIndex = 107;
            this.label23.Text = "Atk Power";
            // 
            // atkPowMax
            // 
            this.atkPowMax.Location = new System.Drawing.Point(66, 22);
            this.atkPowMax.Name = "atkPowMax";
            this.atkPowMax.Size = new System.Drawing.Size(38, 20);
            this.atkPowMax.TabIndex = 108;
            this.atkPowMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // atkSpdMax
            // 
            this.atkSpdMax.Location = new System.Drawing.Point(66, 48);
            this.atkSpdMax.Name = "atkSpdMax";
            this.atkSpdMax.Size = new System.Drawing.Size(38, 20);
            this.atkSpdMax.TabIndex = 110;
            this.atkSpdMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(4, 52);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(57, 13);
            this.label24.TabIndex = 109;
            this.label24.Text = "Atk Speed";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(117, 26);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 13);
            this.label25.TabIndex = 111;
            this.label25.Text = "Move Speed";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(117, 52);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(48, 13);
            this.label26.TabIndex = 113;
            this.label26.Text = "Defence";
            // 
            // defMax
            // 
            this.defMax.Location = new System.Drawing.Point(191, 48);
            this.defMax.Name = "defMax";
            this.defMax.Size = new System.Drawing.Size(38, 20);
            this.defMax.TabIndex = 115;
            this.defMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // moveSpdMax
            // 
            this.moveSpdMax.Location = new System.Drawing.Point(191, 22);
            this.moveSpdMax.Name = "moveSpdMax";
            this.moveSpdMax.Size = new System.Drawing.Size(38, 20);
            this.moveSpdMax.TabIndex = 114;
            this.moveSpdMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(3, 4);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(206, 13);
            this.label27.TabIndex = 116;
            this.label27.Text = "Select maximum negative engraving value";
            // 
            // maxNegEngValuesPanel
            // 
            this.maxNegEngValuesPanel.Controls.Add(this.label27);
            this.maxNegEngValuesPanel.Controls.Add(this.label23);
            this.maxNegEngValuesPanel.Controls.Add(this.atkPowMax);
            this.maxNegEngValuesPanel.Controls.Add(this.defMax);
            this.maxNegEngValuesPanel.Controls.Add(this.label24);
            this.maxNegEngValuesPanel.Controls.Add(this.moveSpdMax);
            this.maxNegEngValuesPanel.Controls.Add(this.atkSpdMax);
            this.maxNegEngValuesPanel.Controls.Add(this.label26);
            this.maxNegEngValuesPanel.Controls.Add(this.label25);
            this.maxNegEngValuesPanel.Location = new System.Drawing.Point(400, 107);
            this.maxNegEngValuesPanel.Name = "maxNegEngValuesPanel";
            this.maxNegEngValuesPanel.Size = new System.Drawing.Size(239, 76);
            this.maxNegEngValuesPanel.TabIndex = 117;
            this.maxNegEngValuesPanel.Visible = false;
            // 
            // stat1CostChart
            // 
            chartArea2.Name = "ChartArea1";
            this.stat1CostChart.ChartAreas.Add(chartArea2);
            this.stat1CostChart.Location = new System.Drawing.Point(3, 3);
            this.stat1CostChart.Name = "stat1CostChart";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            this.stat1CostChart.Series.Add(series2);
            this.stat1CostChart.Size = new System.Drawing.Size(1145, 250);
            this.stat1CostChart.TabIndex = 118;
            this.stat1CostChart.Text = "chart1";
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.stat2CostChart);
            this.tabPage11.Controls.Add(this.stat1CostChart);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(1148, 495);
            this.tabPage11.TabIndex = 9;
            this.tabPage11.Text = "Charts";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // stat2CostChart
            // 
            chartArea1.Name = "ChartArea1";
            this.stat2CostChart.ChartAreas.Add(chartArea1);
            this.stat2CostChart.Location = new System.Drawing.Point(0, 247);
            this.stat2CostChart.Name = "stat2CostChart";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.stat2CostChart.Series.Add(series1);
            this.stat2CostChart.Size = new System.Drawing.Size(1145, 250);
            this.stat2CostChart.TabIndex = 119;
            this.stat2CostChart.Text = "chart1";
            // 
            // minCost
            // 
            this.minCost.Location = new System.Drawing.Point(319, 39);
            this.minCost.Name = "minCost";
            this.minCost.Size = new System.Drawing.Size(61, 20);
            this.minCost.TabIndex = 118;
            this.minCost.Text = "1";
            this.minCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 43);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 15);
            this.label4.TabIndex = 119;
            this.label4.Text = "Minimum Individual Acc Cost";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 847);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.minCost);
            this.Controls.Add(this.engraving5Choice);
            this.Controls.Add(this.engraving1Choice);
            this.Controls.Add(this.engraving1Label);
            this.Controls.Add(this.engraving1QuantityLabel);
            this.Controls.Add(this.maxNegEngValuesPanel);
            this.Controls.Add(this.engraving1Quantity_1);
            this.Controls.Add(this.manualNegativeEngravingInputsCheckBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.loggedAuctionPacketCountLabel);
            this.Controls.Add(this.engraving2Quantity_1);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.engraving3Choice);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.sniffModeCheckbox);
            this.Controls.Add(this.engraving3Quantity_1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.engraving4Choice);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.min_stat2);
            this.Controls.Add(this.engraving4Quantity_1);
            this.Controls.Add(this.min_stat1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.filterZeroNegEngraving_checkBox);
            this.Controls.Add(this.engraving5Quantity_1);
            this.Controls.Add(this.filterWorryingNeg_checkBox);
            this.Controls.Add(this.engraving6Choice);
            this.Controls.Add(this.message_Label);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.reuse_checkBox);
            this.Controls.Add(this.loadLastEngravingsButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.engraving6Quantity_1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.saveLastEngravingsButton);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.engraving2Choice);
            this.Controls.Add(this.desiredStatType2);
            this.Controls.Add(this.engraving6Quantity_6);
            this.Controls.Add(this.desiredStatType1);
            this.Controls.Add(this.engraving1Quantity_2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.engraving5Quantity_6);
            this.Controls.Add(this.maxCost);
            this.Controls.Add(this.engraving2Quantity_2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.engraving4Quantity_6);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.engraving3Quantity_2);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.engraving3Quantity_6);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.engraving4Quantity_2);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.engraving2Quantity_6);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.engraving5Quantity_2);
            this.Controls.Add(this.loggedPacketCountLabel);
            this.Controls.Add(this.engraving1Quantity_6);
            this.Controls.Add(this.engraving3Quantity_4);
            this.Controls.Add(this.engraving6Quantity_2);
            this.Controls.Add(this.engraving4Quantity_4);
            this.Controls.Add(this.engraving6Quantity_5);
            this.Controls.Add(this.engraving2Quantity_4);
            this.Controls.Add(this.engraving1Quantity_3);
            this.Controls.Add(this.engraving5Quantity_4);
            this.Controls.Add(this.engraving5Quantity_5);
            this.Controls.Add(this.engraving1Quantity_4);
            this.Controls.Add(this.engraving2Quantity_3);
            this.Controls.Add(this.engraving6Quantity_4);
            this.Controls.Add(this.engraving4Quantity_5);
            this.Controls.Add(this.engraving6Quantity_3);
            this.Controls.Add(this.engraving3Quantity_3);
            this.Controls.Add(this.engraving1Quantity_5);
            this.Controls.Add(this.engraving3Quantity_5);
            this.Controls.Add(this.engraving5Quantity_3);
            this.Controls.Add(this.engraving4Quantity_3);
            this.Controls.Add(this.engraving2Quantity_5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Lost Ark Accessory Optimizer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.maxNegEngValuesPanel.ResumeLayout(false);
            this.maxNegEngValuesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stat1CostChart)).EndInit();
            this.tabPage11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stat2CostChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label loggedPacketCountLabel;
        private Button clearButton;
        private Button processButton;
        private Label accessoryCount;
        private Button refreshButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label earringCount;
        private Label ringCount;
        private Button saveButton;
        private Button loadButton;
        private ComboBox engraving1Choice;
        private Label engraving1Label;
        private Label engraving1QuantityLabel;
        private TextBox engraving1Quantity_1;
        private TextBox engraving2Quantity_1;
        private Label label5;
        private TextBox engraving3Quantity_1;
        private Label label7;
        private ComboBox engraving3Choice;
        private TextBox engraving4Quantity_1;
        private Label label9;
        private ComboBox engraving4Choice;
        private TextBox engraving5Quantity_1;
        private Label label11;
        private ComboBox engraving5Choice;
        private TextBox engraving6Quantity_1;
        private Label label13;
        private ComboBox engraving6Choice;
        private ComboBox engraving2Choice;
        private Label label14;
        private TextBox maxCost;
        private TextBox engraving6Quantity_2;
        private TextBox engraving5Quantity_2;
        private TextBox engraving4Quantity_2;
        private TextBox engraving3Quantity_2;
        private TextBox engraving2Quantity_2;
        private TextBox engraving1Quantity_2;
        private TextBox engraving6Quantity_3;
        private TextBox engraving5Quantity_3;
        private TextBox engraving4Quantity_3;
        private TextBox engraving3Quantity_3;
        private TextBox engraving2Quantity_3;
        private TextBox engraving1Quantity_3;
        private Label necklaceCount;
        private Panel panel1;
        private Label label15;
        private ComboBox desiredStatType1;
        private ComboBox desiredStatType2;
        private Label label16;
        private Label label17;
        private TextBox engraving6Quantity_4;
        private TextBox engraving5Quantity_4;
        private TextBox engraving4Quantity_4;
        private TextBox engraving3Quantity_4;
        private TextBox engraving2Quantity_4;
        private TextBox engraving1Quantity_4;
        private TextBox engraving6Quantity_5;
        private TextBox engraving5Quantity_5;
        private TextBox engraving4Quantity_5;
        private TextBox engraving3Quantity_5;
        private TextBox engraving2Quantity_5;
        private TextBox engraving1Quantity_5;
        private TextBox engraving6Quantity_6;
        private TextBox engraving5Quantity_6;
        private TextBox engraving4Quantity_6;
        private TextBox engraving3Quantity_6;
        private TextBox engraving2Quantity_6;
        private TextBox engraving1Quantity_6;
        private Button saveLastEngravingsButton;
        private Button loadLastEngravingsButton;
        private TextBox results_textBox;
        private ContextMenuStrip contextMenuStrip1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox cheapest_Textbox;
        private TextBox highestStat1_textBox;
        private TabPage tabPage3;
        private TextBox highestStat2_textBox;
        private TabPage tabPage4;
        private TextBox cheapest500HighStat1_textBox;
        private TabPage tabPage5;
        private TextBox cheapest500HighStat2_textBox;
        private TabPage tabPage6;
        private TextBox cheapestWithRelicNeck_textBox;
        private TabPage tabPage7;
        private TextBox cheapest80Q_textBox;
        private TabPage tabPage8;
        private TextBox cheapest90Q_textBox;
        private TabPage tabPage9;
        private TextBox cheapest95Q_textBox;
        private CheckBox reuse_checkBox;
        private Label label18;
        private TabPage tabPage10;
        private TextBox highestSplit_textBox;
        private Label message_Label;
        private CheckBox filterWorryingNeg_checkBox;
        private CheckBox filterZeroNegEngraving_checkBox;
        private TextBox textBox1;
        private TextBox min_stat1;
        private TextBox min_stat2;
        private Label label19;
        private CheckBox sniffModeCheckbox;
        private LinkLabel linkLabel1;
        private Label label20;
        private Label label21;
        private Label versionLabel;
        public Label loggedAuctionPacketCountLabel;
        private CheckBox manualNegativeEngravingInputsCheckBox;
        private Label label23;
        private TextBox atkPowMax;
        private TextBox atkSpdMax;
        private Label label24;
        private Label label25;
        private Label label26;
        private TextBox defMax;
        private TextBox moveSpdMax;
        private Label label27;
        private Panel maxNegEngValuesPanel;
        private TabPage tabPage11;
        private System.Windows.Forms.DataVisualization.Charting.Chart stat1CostChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart stat2CostChart;
        private TextBox minCost;
        private Label label4;
    }
}
