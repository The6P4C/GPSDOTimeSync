namespace GPSDOTimeSync {
	partial class FormMain {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.labelLatestLogMessage = new System.Windows.Forms.ToolStripStatusLabel();
			this.comboBoxSerialPortNames = new System.Windows.Forms.ComboBox();
			this.labelSerialPortNames = new System.Windows.Forms.Label();
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.labelDevice = new System.Windows.Forms.Label();
			this.comboBoxDeviceNames = new System.Windows.Forms.ComboBox();
			this.labelCurrentTime = new System.Windows.Forms.Label();
			this.labelCurrentDate = new System.Windows.Forms.Label();
			this.timerClockDisplayUpdate = new System.Windows.Forms.Timer(this.components);
			this.labelMaximumCorrection = new System.Windows.Forms.Label();
			this.checkBoxMaximumCorrectionEnabled = new System.Windows.Forms.CheckBox();
			this.comboBoxMaximumCorrectionUnit = new System.Windows.Forms.ComboBox();
			this.numericUpDownMaximumCorrection = new System.Windows.Forms.NumericUpDown();
			this.labelMinimumUpdateInterval = new System.Windows.Forms.Label();
			this.numericUpDownMimimumUpdateInterval = new System.Windows.Forms.NumericUpDown();
			this.labelMinimumUpdateIntervalSeconds = new System.Windows.Forms.Label();
			this.statusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaximumCorrection)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMimimumUpdateInterval)).BeginInit();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelLatestLogMessage});
			this.statusStrip.Location = new System.Drawing.Point(0, 164);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(534, 22);
			this.statusStrip.SizingGrip = false;
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
			// 
			// labelLatestLogMessage
			// 
			this.labelLatestLogMessage.ForeColor = System.Drawing.Color.Black;
			this.labelLatestLogMessage.Name = "labelLatestLogMessage";
			this.labelLatestLogMessage.Size = new System.Drawing.Size(488, 17);
			this.labelLatestLogMessage.Spring = true;
			this.labelLatestLogMessage.Text = "{RUNTIME}";
			// 
			// comboBoxSerialPortNames
			// 
			this.comboBoxSerialPortNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSerialPortNames.FormattingEnabled = true;
			this.comboBoxSerialPortNames.Location = new System.Drawing.Point(139, 25);
			this.comboBoxSerialPortNames.Name = "comboBoxSerialPortNames";
			this.comboBoxSerialPortNames.Size = new System.Drawing.Size(121, 21);
			this.comboBoxSerialPortNames.TabIndex = 2;
			// 
			// labelSerialPortNames
			// 
			this.labelSerialPortNames.AutoSize = true;
			this.labelSerialPortNames.Location = new System.Drawing.Point(136, 9);
			this.labelSerialPortNames.Name = "labelSerialPortNames";
			this.labelSerialPortNames.Size = new System.Drawing.Size(55, 13);
			this.labelSerialPortNames.TabIndex = 3;
			this.labelSerialPortNames.Text = "Serial Port";
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(12, 128);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 4;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// buttonStop
			// 
			this.buttonStop.Enabled = false;
			this.buttonStop.Location = new System.Drawing.Point(93, 128);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(75, 23);
			this.buttonStop.TabIndex = 5;
			this.buttonStop.Text = "Stop";
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
			// 
			// labelDevice
			// 
			this.labelDevice.AutoSize = true;
			this.labelDevice.Location = new System.Drawing.Point(9, 9);
			this.labelDevice.Name = "labelDevice";
			this.labelDevice.Size = new System.Drawing.Size(41, 13);
			this.labelDevice.TabIndex = 6;
			this.labelDevice.Text = "Device";
			// 
			// comboBoxDeviceNames
			// 
			this.comboBoxDeviceNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDeviceNames.FormattingEnabled = true;
			this.comboBoxDeviceNames.Location = new System.Drawing.Point(12, 25);
			this.comboBoxDeviceNames.Name = "comboBoxDeviceNames";
			this.comboBoxDeviceNames.Size = new System.Drawing.Size(121, 21);
			this.comboBoxDeviceNames.TabIndex = 7;
			// 
			// labelCurrentTime
			// 
			this.labelCurrentTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
			this.labelCurrentTime.Location = new System.Drawing.Point(266, 9);
			this.labelCurrentTime.Name = "labelCurrentTime";
			this.labelCurrentTime.Size = new System.Drawing.Size(256, 50);
			this.labelCurrentTime.TabIndex = 8;
			this.labelCurrentTime.Text = "{RUNTIME}";
			this.labelCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelCurrentDate
			// 
			this.labelCurrentDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCurrentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
			this.labelCurrentDate.Location = new System.Drawing.Point(266, 59);
			this.labelCurrentDate.Name = "labelCurrentDate";
			this.labelCurrentDate.Size = new System.Drawing.Size(256, 50);
			this.labelCurrentDate.TabIndex = 9;
			this.labelCurrentDate.Text = "{RUNTIME}";
			this.labelCurrentDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timerClockDisplayUpdate
			// 
			this.timerClockDisplayUpdate.Interval = 50;
			this.timerClockDisplayUpdate.Tick += new System.EventHandler(this.timerClockDisplayUpdate_Tick);
			// 
			// labelMaximumCorrection
			// 
			this.labelMaximumCorrection.AutoSize = true;
			this.labelMaximumCorrection.Location = new System.Drawing.Point(9, 49);
			this.labelMaximumCorrection.Name = "labelMaximumCorrection";
			this.labelMaximumCorrection.Size = new System.Drawing.Size(102, 13);
			this.labelMaximumCorrection.TabIndex = 10;
			this.labelMaximumCorrection.Text = "Maximum Correction";
			// 
			// checkBoxMaximumCorrectionEnabled
			// 
			this.checkBoxMaximumCorrectionEnabled.AutoSize = true;
			this.checkBoxMaximumCorrectionEnabled.Location = new System.Drawing.Point(12, 65);
			this.checkBoxMaximumCorrectionEnabled.Name = "checkBoxMaximumCorrectionEnabled";
			this.checkBoxMaximumCorrectionEnabled.Size = new System.Drawing.Size(15, 14);
			this.checkBoxMaximumCorrectionEnabled.TabIndex = 11;
			this.checkBoxMaximumCorrectionEnabled.UseVisualStyleBackColor = true;
			this.checkBoxMaximumCorrectionEnabled.CheckedChanged += new System.EventHandler(this.checkBoxMaximumCorrectionEnabled_CheckedChanged);
			// 
			// comboBoxMaximumCorrectionUnit
			// 
			this.comboBoxMaximumCorrectionUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxMaximumCorrectionUnit.Enabled = false;
			this.comboBoxMaximumCorrectionUnit.FormattingEnabled = true;
			this.comboBoxMaximumCorrectionUnit.Items.AddRange(new object[] {
            "hour(s)",
            "minute(s)",
            "second(s)"});
			this.comboBoxMaximumCorrectionUnit.Location = new System.Drawing.Point(86, 62);
			this.comboBoxMaximumCorrectionUnit.Name = "comboBoxMaximumCorrectionUnit";
			this.comboBoxMaximumCorrectionUnit.Size = new System.Drawing.Size(79, 21);
			this.comboBoxMaximumCorrectionUnit.TabIndex = 12;
			// 
			// numericUpDownMaximumCorrection
			// 
			this.numericUpDownMaximumCorrection.Enabled = false;
			this.numericUpDownMaximumCorrection.Location = new System.Drawing.Point(33, 63);
			this.numericUpDownMaximumCorrection.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownMaximumCorrection.Name = "numericUpDownMaximumCorrection";
			this.numericUpDownMaximumCorrection.Size = new System.Drawing.Size(47, 20);
			this.numericUpDownMaximumCorrection.TabIndex = 13;
			this.numericUpDownMaximumCorrection.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// labelMinimumUpdateInterval
			// 
			this.labelMinimumUpdateInterval.AutoSize = true;
			this.labelMinimumUpdateInterval.Location = new System.Drawing.Point(9, 86);
			this.labelMinimumUpdateInterval.Name = "labelMinimumUpdateInterval";
			this.labelMinimumUpdateInterval.Size = new System.Drawing.Size(124, 13);
			this.labelMinimumUpdateInterval.TabIndex = 14;
			this.labelMinimumUpdateInterval.Text = "Minimum Update Interval";
			// 
			// numericUpDownMimimumUpdateInterval
			// 
			this.numericUpDownMimimumUpdateInterval.Location = new System.Drawing.Point(12, 102);
			this.numericUpDownMimimumUpdateInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownMimimumUpdateInterval.Name = "numericUpDownMimimumUpdateInterval";
			this.numericUpDownMimimumUpdateInterval.Size = new System.Drawing.Size(47, 20);
			this.numericUpDownMimimumUpdateInterval.TabIndex = 16;
			this.numericUpDownMimimumUpdateInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// labelMinimumUpdateIntervalSeconds
			// 
			this.labelMinimumUpdateIntervalSeconds.AutoSize = true;
			this.labelMinimumUpdateIntervalSeconds.Location = new System.Drawing.Point(64, 104);
			this.labelMinimumUpdateIntervalSeconds.Name = "labelMinimumUpdateIntervalSeconds";
			this.labelMinimumUpdateIntervalSeconds.Size = new System.Drawing.Size(47, 13);
			this.labelMinimumUpdateIntervalSeconds.TabIndex = 17;
			this.labelMinimumUpdateIntervalSeconds.Text = "seconds";
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 186);
			this.Controls.Add(this.labelMinimumUpdateIntervalSeconds);
			this.Controls.Add(this.numericUpDownMimimumUpdateInterval);
			this.Controls.Add(this.labelMinimumUpdateInterval);
			this.Controls.Add(this.numericUpDownMaximumCorrection);
			this.Controls.Add(this.comboBoxMaximumCorrectionUnit);
			this.Controls.Add(this.checkBoxMaximumCorrectionEnabled);
			this.Controls.Add(this.labelMaximumCorrection);
			this.Controls.Add(this.labelCurrentDate);
			this.Controls.Add(this.labelCurrentTime);
			this.Controls.Add(this.comboBoxDeviceNames);
			this.Controls.Add(this.labelDevice);
			this.Controls.Add(this.buttonStop);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.labelSerialPortNames);
			this.Controls.Add(this.comboBoxSerialPortNames);
			this.Controls.Add(this.statusStrip);
			this.MinimumSize = new System.Drawing.Size(550, 225);
			this.Name = "FormMain";
			this.Text = "GPSDO Time Sync";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaximumCorrection)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMimimumUpdateInterval)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel labelLatestLogMessage;
		private System.Windows.Forms.ComboBox comboBoxSerialPortNames;
		private System.Windows.Forms.Label labelSerialPortNames;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Label labelDevice;
		private System.Windows.Forms.ComboBox comboBoxDeviceNames;
		private System.Windows.Forms.Label labelCurrentTime;
		private System.Windows.Forms.Label labelCurrentDate;
		private System.Windows.Forms.Timer timerClockDisplayUpdate;
		private System.Windows.Forms.Label labelMaximumCorrection;
		private System.Windows.Forms.CheckBox checkBoxMaximumCorrectionEnabled;
		private System.Windows.Forms.ComboBox comboBoxMaximumCorrectionUnit;
		private System.Windows.Forms.NumericUpDown numericUpDownMaximumCorrection;
		private System.Windows.Forms.Label labelMinimumUpdateInterval;
		private System.Windows.Forms.NumericUpDown numericUpDownMimimumUpdateInterval;
		private System.Windows.Forms.Label labelMinimumUpdateIntervalSeconds;
	}
}

