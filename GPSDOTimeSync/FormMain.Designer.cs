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
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.latestLogMessage});
			this.statusStrip.Location = new System.Drawing.Point(0, 119);
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
			this.start.Location = new System.Drawing.Point(12, 52);
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
			this.stop.Location = new System.Drawing.Point(93, 52);
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
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 141);
			this.Controls.Add(this.currentDate);
			this.Controls.Add(this.currentTime);
			this.Controls.Add(this.deviceNames);
			this.Controls.Add(this.deviceLabel);
			this.Controls.Add(this.stop);
			this.Controls.Add(this.start);
			this.Controls.Add(this.serialPortNamesLabel);
			this.Controls.Add(this.serialPortNames);
			this.Controls.Add(this.statusStrip);
			this.MinimumSize = new System.Drawing.Size(550, 180);
			this.Name = "FormMain";
			this.Text = "GPSDO Time Sync";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
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
	}
}

