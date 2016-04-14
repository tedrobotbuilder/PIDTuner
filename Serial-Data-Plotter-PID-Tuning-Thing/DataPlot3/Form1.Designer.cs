namespace DataPlot3
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
            this.ComPortGroupBox = new System.Windows.Forms.GroupBox();
            this.COMPortStatusLight = new PolyMonControls.StatusLight();
            this.COMPortComboBox = new System.Windows.Forms.ComboBox();
            this.COMBaudComboBox = new System.Windows.Forms.ComboBox();
            this.COMConnectButton = new System.Windows.Forms.Button();
            this.SerialPort = new System.IO.Ports.SerialPort(this.components);
            this.RawTextBox = new System.Windows.Forms.TextBox();
            this.ZedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.OptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.YTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SeriesLineSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.COMPortSendStatusLight = new PolyMonControls.StatusLight();
            this.SpeedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.DTermNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DTermLabel = new System.Windows.Forms.Label();
            this.ITermNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ITermLabel = new System.Windows.Forms.Label();
            this.PTermNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PTermLabel = new System.Windows.Forms.Label();
            this.COMSendButton = new System.Windows.Forms.Button();
            this.NoOfDataNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.XTextBox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ComPortGroupBox.SuspendLayout();
            this.OptionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeriesLineSizeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTermNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ITermNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTermNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoOfDataNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ComPortGroupBox
            // 
            this.ComPortGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ComPortGroupBox.Controls.Add(this.COMPortStatusLight);
            this.ComPortGroupBox.Controls.Add(this.COMPortComboBox);
            this.ComPortGroupBox.Controls.Add(this.COMBaudComboBox);
            this.ComPortGroupBox.Controls.Add(this.COMConnectButton);
            this.ComPortGroupBox.Location = new System.Drawing.Point(826, 556);
            this.ComPortGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.ComPortGroupBox.Name = "ComPortGroupBox";
            this.ComPortGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.ComPortGroupBox.Size = new System.Drawing.Size(105, 93);
            this.ComPortGroupBox.TabIndex = 0;
            this.ComPortGroupBox.TabStop = false;
            this.ComPortGroupBox.Text = "COM Port";
            // 
            // COMPortStatusLight
            // 
            this.COMPortStatusLight.BackgroundImage = System.Drawing.Color.Empty;
            this.COMPortStatusLight.BackgroundImageLayout = System.Drawing.Color.Empty;
            this.COMPortStatusLight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.COMPortStatusLight.Location = new System.Drawing.Point(0, 62);
            this.COMPortStatusLight.Margin = new System.Windows.Forms.Padding(2);
            this.COMPortStatusLight.Name = "COMPortStatusLight";
            this.COMPortStatusLight.OffColor = System.Drawing.Color.Red;
            this.COMPortStatusLight.Size = new System.Drawing.Size(30, 30);
            this.COMPortStatusLight.TabIndex = 3;
            this.COMPortStatusLight.Text = "COMPortStatusLight";
            // 
            // COMPortComboBox
            // 
            this.COMPortComboBox.FormattingEnabled = true;
            this.COMPortComboBox.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM12",
            "COM13",
            "COM14"});
            this.COMPortComboBox.Location = new System.Drawing.Point(4, 41);
            this.COMPortComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.COMPortComboBox.Name = "COMPortComboBox";
            this.COMPortComboBox.Size = new System.Drawing.Size(97, 21);
            this.COMPortComboBox.TabIndex = 2;
            // 
            // COMBaudComboBox
            // 
            this.COMBaudComboBox.FormattingEnabled = true;
            this.COMBaudComboBox.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "14400",
            "28800",
            "38400",
            "57600",
            "115200"});
            this.COMBaudComboBox.Location = new System.Drawing.Point(4, 17);
            this.COMBaudComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.COMBaudComboBox.Name = "COMBaudComboBox";
            this.COMBaudComboBox.Size = new System.Drawing.Size(97, 21);
            this.COMBaudComboBox.TabIndex = 1;
            this.COMBaudComboBox.Text = "9600";
            // 
            // COMConnectButton
            // 
            this.COMConnectButton.Location = new System.Drawing.Point(32, 67);
            this.COMConnectButton.Margin = new System.Windows.Forms.Padding(2);
            this.COMConnectButton.Name = "COMConnectButton";
            this.COMConnectButton.Size = new System.Drawing.Size(68, 22);
            this.COMConnectButton.TabIndex = 0;
            this.COMConnectButton.Text = "Connect";
            this.COMConnectButton.UseVisualStyleBackColor = true;
            this.COMConnectButton.Click += new System.EventHandler(this.COMConnectBtn_Click);
            // 
            // SerialPort
            // 
            this.SerialPort.ReadBufferSize = 1024;
            this.SerialPort.ReadTimeout = 2000;
            this.SerialPort.ReceivedBytesThreshold = 2;
            this.SerialPort.WriteBufferSize = 1024;
            this.SerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort_DataReceived);
            // 
            // RawTextBox
            // 
            this.RawTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RawTextBox.Location = new System.Drawing.Point(9, 326);
            this.RawTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.RawTextBox.MaxLength = 1000;
            this.RawTextBox.Multiline = true;
            this.RawTextBox.Name = "RawTextBox";
            this.RawTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.RawTextBox.Size = new System.Drawing.Size(185, 210);
            this.RawTextBox.TabIndex = 1;
            // 
            // ZedGraphControl1
            // 
            this.ZedGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ZedGraphControl1.AutoSize = true;
            this.ZedGraphControl1.BackColor = System.Drawing.SystemColors.InfoText;
            this.ZedGraphControl1.IsAutoScrollRange = true;
            this.ZedGraphControl1.Location = new System.Drawing.Point(9, 11);
            this.ZedGraphControl1.Name = "ZedGraphControl1";
            this.ZedGraphControl1.ScrollGrace = 0D;
            this.ZedGraphControl1.ScrollMaxX = 0D;
            this.ZedGraphControl1.ScrollMaxY = 0D;
            this.ZedGraphControl1.ScrollMaxY2 = 0D;
            this.ZedGraphControl1.ScrollMinX = 0D;
            this.ZedGraphControl1.ScrollMinY = 0D;
            this.ZedGraphControl1.ScrollMinY2 = 0D;
            this.ZedGraphControl1.Size = new System.Drawing.Size(718, 638);
            this.ZedGraphControl1.TabIndex = 2;
            // 
            // OptionsGroupBox
            // 
            this.OptionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.OptionsGroupBox.Controls.Add(this.label5);
            this.OptionsGroupBox.Controls.Add(this.YTextBox);
            this.OptionsGroupBox.Controls.Add(this.RawTextBox);
            this.OptionsGroupBox.Controls.Add(this.label4);
            this.OptionsGroupBox.Controls.Add(this.SeriesLineSizeNumericUpDown);
            this.OptionsGroupBox.Controls.Add(this.COMPortSendStatusLight);
            this.OptionsGroupBox.Controls.Add(this.SpeedNumericUpDown);
            this.OptionsGroupBox.Controls.Add(this.label3);
            this.OptionsGroupBox.Controls.Add(this.DTermNumericUpDown);
            this.OptionsGroupBox.Controls.Add(this.DTermLabel);
            this.OptionsGroupBox.Controls.Add(this.ITermNumericUpDown);
            this.OptionsGroupBox.Controls.Add(this.ITermLabel);
            this.OptionsGroupBox.Controls.Add(this.PTermNumericUpDown);
            this.OptionsGroupBox.Controls.Add(this.PTermLabel);
            this.OptionsGroupBox.Controls.Add(this.COMSendButton);
            this.OptionsGroupBox.Controls.Add(this.NoOfDataNumericUpDown);
            this.OptionsGroupBox.Controls.Add(this.label2);
            this.OptionsGroupBox.Controls.Add(this.label1);
            this.OptionsGroupBox.Controls.Add(this.XTextBox);
            this.OptionsGroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OptionsGroupBox.Location = new System.Drawing.Point(732, 11);
            this.OptionsGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.OptionsGroupBox.Name = "OptionsGroupBox";
            this.OptionsGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.OptionsGroupBox.Size = new System.Drawing.Size(199, 540);
            this.OptionsGroupBox.TabIndex = 3;
            this.OptionsGroupBox.TabStop = false;
            this.OptionsGroupBox.Text = "Options";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 64);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 26);
            this.label5.TabIndex = 18;
            this.label5.Text = "Y Scale";
            // 
            // YTextBox
            // 
            this.YTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YTextBox.Location = new System.Drawing.Point(94, 61);
            this.YTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.YTextBox.Name = "YTextBox";
            this.YTextBox.Size = new System.Drawing.Size(77, 32);
            this.YTextBox.TabIndex = 17;
            this.YTextBox.Text = "1000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(154, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Size";
            // 
            // SeriesLineSizeNumericUpDown
            // 
            this.SeriesLineSizeNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeriesLineSizeNumericUpDown.Location = new System.Drawing.Point(157, 37);
            this.SeriesLineSizeNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.SeriesLineSizeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SeriesLineSizeNumericUpDown.Name = "SeriesLineSizeNumericUpDown";
            this.SeriesLineSizeNumericUpDown.Size = new System.Drawing.Size(31, 20);
            this.SeriesLineSizeNumericUpDown.TabIndex = 15;
            this.SeriesLineSizeNumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // COMPortSendStatusLight
            // 
            this.COMPortSendStatusLight.BackgroundImage = System.Drawing.Color.Empty;
            this.COMPortSendStatusLight.BackgroundImageLayout = System.Drawing.Color.Empty;
            this.COMPortSendStatusLight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.COMPortSendStatusLight.Location = new System.Drawing.Point(8, 291);
            this.COMPortSendStatusLight.Margin = new System.Windows.Forms.Padding(2);
            this.COMPortSendStatusLight.Name = "COMPortSendStatusLight";
            this.COMPortSendStatusLight.OffColor = System.Drawing.Color.Red;
            this.COMPortSendStatusLight.Size = new System.Drawing.Size(45, 30);
            this.COMPortSendStatusLight.TabIndex = 4;
            this.COMPortSendStatusLight.Text = "statusLight1";
            this.COMPortSendStatusLight.Value = 0D;
            // 
            // SpeedNumericUpDown
            // 
            this.SpeedNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpeedNumericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.SpeedNumericUpDown.Location = new System.Drawing.Point(93, 251);
            this.SpeedNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.SpeedNumericUpDown.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.SpeedNumericUpDown.Name = "SpeedNumericUpDown";
            this.SpeedNumericUpDown.Size = new System.Drawing.Size(95, 35);
            this.SpeedNumericUpDown.TabIndex = 14;
            this.SpeedNumericUpDown.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 253);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 29);
            this.label3.TabIndex = 13;
            this.label3.Text = "Speed";
            // 
            // DTermNumericUpDown
            // 
            this.DTermNumericUpDown.DecimalPlaces = 2;
            this.DTermNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTermNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.DTermNumericUpDown.Location = new System.Drawing.Point(31, 212);
            this.DTermNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.DTermNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.DTermNumericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.DTermNumericUpDown.Name = "DTermNumericUpDown";
            this.DTermNumericUpDown.Size = new System.Drawing.Size(93, 35);
            this.DTermNumericUpDown.TabIndex = 12;
            this.DTermNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // DTermLabel
            // 
            this.DTermLabel.AutoSize = true;
            this.DTermLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTermLabel.Location = new System.Drawing.Point(3, 214);
            this.DTermLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DTermLabel.Name = "DTermLabel";
            this.DTermLabel.Size = new System.Drawing.Size(30, 29);
            this.DTermLabel.TabIndex = 11;
            this.DTermLabel.Text = "D";
            // 
            // ITermNumericUpDown
            // 
            this.ITermNumericUpDown.DecimalPlaces = 2;
            this.ITermNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ITermNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.ITermNumericUpDown.Location = new System.Drawing.Point(31, 173);
            this.ITermNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.ITermNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ITermNumericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.ITermNumericUpDown.Name = "ITermNumericUpDown";
            this.ITermNumericUpDown.Size = new System.Drawing.Size(93, 35);
            this.ITermNumericUpDown.TabIndex = 10;
            this.ITermNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ITermLabel
            // 
            this.ITermLabel.AutoSize = true;
            this.ITermLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ITermLabel.Location = new System.Drawing.Point(8, 175);
            this.ITermLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ITermLabel.Name = "ITermLabel";
            this.ITermLabel.Size = new System.Drawing.Size(19, 29);
            this.ITermLabel.TabIndex = 9;
            this.ITermLabel.Text = "I";
            // 
            // PTermNumericUpDown
            // 
            this.PTermNumericUpDown.DecimalPlaces = 2;
            this.PTermNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PTermNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.PTermNumericUpDown.Location = new System.Drawing.Point(31, 134);
            this.PTermNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.PTermNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PTermNumericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.PTermNumericUpDown.Name = "PTermNumericUpDown";
            this.PTermNumericUpDown.Size = new System.Drawing.Size(93, 35);
            this.PTermNumericUpDown.TabIndex = 8;
            this.PTermNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // PTermLabel
            // 
            this.PTermLabel.AutoSize = true;
            this.PTermLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PTermLabel.Location = new System.Drawing.Point(4, 136);
            this.PTermLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PTermLabel.Name = "PTermLabel";
            this.PTermLabel.Size = new System.Drawing.Size(29, 29);
            this.PTermLabel.TabIndex = 7;
            this.PTermLabel.Text = "P";
            // 
            // COMSendButton
            // 
            this.COMSendButton.CausesValidation = false;
            this.COMSendButton.Enabled = false;
            this.COMSendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.COMSendButton.Location = new System.Drawing.Point(49, 291);
            this.COMSendButton.Name = "COMSendButton";
            this.COMSendButton.Size = new System.Drawing.Size(75, 30);
            this.COMSendButton.TabIndex = 6;
            this.COMSendButton.Text = "Send";
            this.COMSendButton.UseVisualStyleBackColor = true;
            this.COMSendButton.Click += new System.EventHandler(this.COMSendButton_Click);
            // 
            // NoOfDataNumericUpDown
            // 
            this.NoOfDataNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoOfDataNumericUpDown.Location = new System.Drawing.Point(94, 25);
            this.NoOfDataNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.NoOfDataNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NoOfDataNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NoOfDataNumericUpDown.Name = "NoOfDataNumericUpDown";
            this.NoOfDataNumericUpDown.Size = new System.Drawing.Size(56, 32);
            this.NoOfDataNumericUpDown.TabIndex = 5;
            this.NoOfDataNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "X Scale";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "# Series";
            // 
            // XTextBox
            // 
            this.XTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XTextBox.Location = new System.Drawing.Point(94, 97);
            this.XTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.XTextBox.Name = "XTextBox";
            this.XTextBox.Size = new System.Drawing.Size(77, 32);
            this.XTextBox.TabIndex = 1;
            this.XTextBox.Text = "1000";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 659);
            this.Controls.Add(this.OptionsGroupBox);
            this.Controls.Add(this.ZedGraphControl1);
            this.Controls.Add(this.ComPortGroupBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Serial-Data-Plotter-PID-Tuning-Thing 1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ComPortGroupBox.ResumeLayout(false);
            this.OptionsGroupBox.ResumeLayout(false);
            this.OptionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeriesLineSizeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTermNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ITermNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTermNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoOfDataNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox ComPortGroupBox;
        private System.Windows.Forms.ComboBox COMPortComboBox;
        private System.Windows.Forms.ComboBox COMBaudComboBox;
        private System.Windows.Forms.Button COMConnectButton;
        private PolyMonControls.StatusLight COMPortStatusLight;
        private System.IO.Ports.SerialPort SerialPort;
        private System.Windows.Forms.TextBox RawTextBox;
        private ZedGraph.ZedGraphControl ZedGraphControl1;
        private System.Windows.Forms.GroupBox OptionsGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox XTextBox;
        private System.Windows.Forms.NumericUpDown NoOfDataNumericUpDown;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button COMSendButton;
        private System.Windows.Forms.NumericUpDown PTermNumericUpDown;
        private System.Windows.Forms.Label PTermLabel;
        private System.Windows.Forms.NumericUpDown DTermNumericUpDown;
        private System.Windows.Forms.Label DTermLabel;
        private System.Windows.Forms.NumericUpDown ITermNumericUpDown;
        private System.Windows.Forms.Label ITermLabel;
        private System.Windows.Forms.NumericUpDown SpeedNumericUpDown;
        private System.Windows.Forms.Label label3;
        private PolyMonControls.StatusLight COMPortSendStatusLight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown SeriesLineSizeNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox YTextBox;
    }
}

