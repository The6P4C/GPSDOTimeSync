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
			this.latestLogMessage = new System.Windows.Forms.ToolStripStatusLabel();
			this.serialPortNames = new System.Windows.Forms.ComboBox();
			this.serialPortNamesLabel = new System.Windows.Forms.Label();
			this.start = new System.Windows.Forms.Button();
			this.stop = new System.Windows.Forms.Button();
			this.deviceLabel = new System.Windows.Forms.Label();
			this.deviceNames = new System.Windows.Forms.ComboBox();
			this.currentTime = new System.Windows.Forms.Label();
			this.currentDate = new System.Windows.Forms.Label();
			this.timeAndDateDisplayUpdate = new System.Windows.Forms.Timer(this.components);
			this.maximumCorrectionLabel = new System.Windows.Forms.Label();
			this.maximumCorrectionEnabled = new System.Windows.Forms.CheckBox();
			this.maximumCorrectionUnit = new System.Windows.Forms.ComboBox();
			this.maximumCorrection = new System.Windows.Forms.NumericUpDown();
			this.minimumUpdateIntervalLabel = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.minimumUpdateInterval = new System.Windows.Forms.NumericUpDown();
			this.minimumUpdateIntervalSecondsLabel = new System.Windows.Forms.Label();
			this.statusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.maximumCorrection)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.minimumUpdateInterval)).BeginInit();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.latestLogMessage});
			this.statusStrip.Location = new System.Drawing.Point(0, 164);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(534, 22);
			this.statusStrip.SizingGrip = false;
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
			// 
			// latestLogMessage
			// 
			this.latestLogMessage.ForeColor = System.Drawing.Color.Black;
			this.latestLogMessage.Name = "latestLogMessage";
			this.latestLogMessage.Size = new System.Drawing.Size(519, 17);
			this.latestLogMessage.Spring = true;
			this.latestLogMessage.Text = "{RUNTIME}";
			// 
			// serialPortNames
			// 
			this.serialPortNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.serialPortNames.FormattingEnabled = true;
			this.serialPortNames.Location = new System.Drawing.Point(139, 25);
			this.serialPortNames.Name = "serialPortNames";
			this.serialPortNames.Size = new System.Drawing.Size(121, 21);
			this.serialPortNames.TabIndex = 2;
			// 
			// serialPortNamesLabel
			// 
			this.serialPortNamesLabel.AutoSize = true;
			this.serialPortNamesLabel.Location = new System.Drawing.Point(136, 9);
			this.serialPortNamesLabel.Name = "serialPortNamesLabel";
			this.serialPortNamesLabel.Size = new System.Drawing.Size(55, 13);
			this.serialPortNamesLabel.TabIndex = 3;
			this.serialPortNamesLabel.Text = "Serial Port";
			// 
			// start
			// 
			this.start.Location = new System.Drawing.Point(12, 128);
			this.start.Name = "start";
			this.start.Size = new System.Drawing.Size(75, 23);
			this.start.TabIndex = 4;
			this.start.Text = "Start";
			this.start.UseVisualStyleBackColor = true;
			this.start.Click += new System.EventHandler(this.start_Click);
			// 
			// stop
			// 
			this.stop.Enabled = false;
			this.stop.Location = new System.Drawing.Point(93, 128);
			this.stop.Name = "stop";
			this.stop.Size = new System.Drawing.Size(75, 23);
			this.stop.TabIndex = 5;
			this.stop.Text = "Stop";
			this.stop.UseVisualStyleBackColor = true;
			this.stop.Click += new System.EventHandler(this.stop_Click);
			// 
			// deviceLabel
			// 
			this.deviceLabel.AutoSize = true;
			this.deviceLabel.Location = new System.Drawing.Point(9, 9);
			this.deviceLabel.Name = "deviceLabel";
			this.deviceLabel.Size = new System.Drawing.Size(41, 13);
			this.deviceLabel.TabIndex = 6;
			this.deviceLabel.Text = "Device";
			// 
			// deviceNames
			// 
			this.deviceNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.deviceNames.FormattingEnabled = true;
			this.deviceNames.Location = new System.Drawing.Point(12, 25);
			this.deviceNames.Name = "deviceNames";
			this.deviceNames.Size = new System.Drawing.Size(121, 21);
			this.deviceNames.TabIndex = 7;
			// 
			// currentTime
			// 
			this.currentTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.currentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
			this.currentTime.Location = new System.Drawing.Point(266, 9);
			this.currentTime.Name = "currentTime";
			this.currentTime.Size = new System.Drawing.Size(256, 50);
			this.currentTime.TabIndex = 8;
			this.currentTime.Text = "{RUNTIME}";
			this.currentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// currentDate
			// 
			this.currentDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.currentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
			this.currentDate.Location = new System.Drawing.Point(266, 59);
			this.currentDate.Name = "currentDate";
			this.currentDate.Size = new System.Drawing.Size(256, 50);
			this.currentDate.TabIndex = 9;
			this.currentDate.Text = "{RUNTIME}";
			this.currentDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timeAndDateDisplayUpdate
			// 
			this.timeAndDateDisplayUpdate.Interval = 50;
			this.timeAndDateDisplayUpdate.Tick += new System.EventHandler(this.timeAndDateDisplayUpdate_Tick);
			// 
			// maximumCorrectionLabel
			// 
			this.maximumCorrectionLabel.AutoSize = true;
			this.maximumCorrectionLabel.Location = new System.Drawing.Point(9, 49);
			this.maximumCorrectionLabel.Name = "maximumCorrectionLabel";
			this.maximumCorrectionLabel.Size = new System.Drawing.Size(102, 13);
			this.maximumCorrectionLabel.TabIndex = 10;
			this.maximumCorrectionLabel.Text = "Maximum Correction";
			// 
			// maximumCorrectionEnabled
			// 
			this.maximumCorrectionEnabled.AutoSize = true;
			this.maximumCorrectionEnabled.Location = new System.Drawing.Point(12, 65);
			this.maximumCorrectionEnabled.Name = "maximumCorrectionEnabled";
			this.maximumCorrectionEnabled.Size = new System.Drawing.Size(15, 14);
			this.maximumCorrectionEnabled.TabIndex = 11;
			this.maximumCorrectionEnabled.UseVisualStyleBackColor = true;
			this.maximumCorrectionEnabled.CheckedChanged += new System.EventHandler(this.maximumCorrectionEnabled_CheckedChanged);
			// 
			// maximumCorrectionUnit
			// 
			this.maximumCorrectionUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.maximumCorrectionUnit.Enabled = false;
			this.maximumCorrectionUnit.FormattingEnabled = true;
			this.maximumCorrectionUnit.Items.AddRange(new object[] {
            "hour(s)",
            "minute(s)",
            "second(s)"});
			this.maximumCorrectionUnit.Location = new System.Drawing.Point(86, 62);
			this.maximumCorrectionUnit.Name = "maximumCorrectionUnit";
			this.maximumCorrectionUnit.Size = new System.Drawing.Size(79, 21);
			this.maximumCorrectionUnit.TabIndex = 12;
			// 
			// maximumCorrection
			// 
			this.maximumCorrection.Enabled = false;
			this.maximumCorrection.Location = new System.Drawing.Point(33, 63);
			this.maximumCorrection.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.maximumCorrection.Name = "maximumCorrection";
			this.maximumCorrection.Size = new System.Drawing.Size(47, 20);
			this.maximumCorrection.TabIndex = 13;
			this.maximumCorrection.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// minimumUpdateIntervalLabel
			// 
			this.minimumUpdateIntervalLabel.AutoSize = true;
			this.minimumUpdateIntervalLabel.Location = new System.Drawing.Point(9, 86);
			this.minimumUpdateIntervalLabel.Name = "minimumUpdateIntervalLabel";
			this.minimumUpdateIntervalLabel.Size = new System.Drawing.Size(124, 13);
			this.minimumUpdateIntervalLabel.TabIndex = 14;
			this.minimumUpdateIntervalLabel.Text = "Minimum Update Interval";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Enabled = false;
			this.numericUpDown1.Location = new System.Drawing.Point(171, 63);
			this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(47, 20);
			this.numericUpDown1.TabIndex = 15;
			this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// minimumUpdateInterval
			// 
			this.minimumUpdateInterval.Location = new System.Drawing.Point(12, 102);
			this.minimumUpdateInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.minimumUpdateInterval.Name = "minimumUpdateInterval";
			this.minimumUpdateInterval.Size = new System.Drawing.Size(47, 20);
			this.minimumUpdateInterval.TabIndex = 16;
			this.minimumUpdateInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// minimumUpdateIntervalSecondsLabel
			// 
			this.minimumUpdateIntervalSecondsLabel.AutoSize = true;
			this.minimumUpdateIntervalSecondsLabel.Location = new System.Drawing.Point(64, 104);
			this.minimumUpdateIntervalSecondsLabel.Name = "minimumUpdateIntervalSecondsLabel";
			this.minimumUpdateIntervalSecondsLabel.Size = new System.Drawing.Size(47, 13);
			this.minimumUpdateIntervalSecondsLabel.TabIndex = 17;
			this.minimumUpdateIntervalSecondsLabel.Text = "seconds";
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 186);
			this.Controls.Add(this.minimumUpdateIntervalSecondsLabel);
			this.Controls.Add(this.minimumUpdateInterval);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.minimumUpdateIntervalLabel);
			this.Controls.Add(this.maximumCorrection);
			this.Controls.Add(this.maximumCorrectionUnit);
			this.Controls.Add(this.maximumCorrectionEnabled);
			this.Controls.Add(this.maximumCorrectionLabel);
			this.Controls.Add(this.currentDate);
			this.Controls.Add(this.currentTime);
			this.Controls.Add(this.deviceNames);
			this.Controls.Add(this.deviceLabel);
			this.Controls.Add(this.stop);
			this.Controls.Add(this.start);
			this.Controls.Add(this.serialPortNamesLabel);
			this.Controls.Add(this.serialPortNames);
			this.Controls.Add(this.statusStrip);
			this.MinimumSize = new System.Drawing.Size(550, 225);
			this.Name = "FormMain";
			this.Text = "GPSDO Time Sync";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.maximumCorrection)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.minimumUpdateInterval)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel latestLogMessage;
		private System.Windows.Forms.ComboBox serialPortNames;
		private System.Windows.Forms.Label serialPortNamesLabel;
		private System.Windows.Forms.Button start;
		private System.Windows.Forms.Button stop;
		private System.Windows.Forms.Label deviceLabel;
		private System.Windows.Forms.ComboBox deviceNames;
		private System.Windows.Forms.Label currentTime;
		private System.Windows.Forms.Label currentDate;
		private System.Windows.Forms.Timer timeAndDateDisplayUpdate;
		private System.Windows.Forms.Label maximumCorrectionLabel;
		private System.Windows.Forms.CheckBox maximumCorrectionEnabled;
		private System.Windows.Forms.ComboBox maximumCorrectionUnit;
		private System.Windows.Forms.NumericUpDown maximumCorrection;
		private System.Windows.Forms.Label minimumUpdateIntervalLabel;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.NumericUpDown minimumUpdateInterval;
		private System.Windows.Forms.Label minimumUpdateIntervalSecondsLabel;
	}
}

