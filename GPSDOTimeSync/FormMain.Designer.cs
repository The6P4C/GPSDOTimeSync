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
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.latestLogMessage = new System.Windows.Forms.ToolStripStatusLabel();
			this.serialPortNames = new System.Windows.Forms.ComboBox();
			this.serialPortNamesLabel = new System.Windows.Forms.Label();
			this.start = new System.Windows.Forms.Button();
			this.stop = new System.Windows.Forms.Button();
			this.deviceLabel = new System.Windows.Forms.Label();
			this.deviceNames = new System.Windows.Forms.ComboBox();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.latestLogMessage});
			this.statusStrip.Location = new System.Drawing.Point(0, 99);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(224, 22);
			this.statusStrip.SizingGrip = false;
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
			// 
			// latestLogMessage
			// 
			this.latestLogMessage.ForeColor = System.Drawing.Color.Black;
			this.latestLogMessage.Name = "latestLogMessage";
			this.latestLogMessage.Size = new System.Drawing.Size(178, 17);
			this.latestLogMessage.Spring = true;
			this.latestLogMessage.Text = "{RUNTIME}";
			// 
			// serialPortNames
			// 
			this.serialPortNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.serialPortNames.FormattingEnabled = true;
			this.serialPortNames.Location = new System.Drawing.Point(76, 39);
			this.serialPortNames.Name = "serialPortNames";
			this.serialPortNames.Size = new System.Drawing.Size(121, 21);
			this.serialPortNames.TabIndex = 2;
			// 
			// serialPortNamesLabel
			// 
			this.serialPortNamesLabel.AutoSize = true;
			this.serialPortNamesLabel.Location = new System.Drawing.Point(12, 42);
			this.serialPortNamesLabel.Name = "serialPortNamesLabel";
			this.serialPortNamesLabel.Size = new System.Drawing.Size(55, 13);
			this.serialPortNamesLabel.TabIndex = 3;
			this.serialPortNamesLabel.Text = "Serial Port";
			// 
			// start
			// 
			this.start.Location = new System.Drawing.Point(12, 66);
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
			this.stop.Location = new System.Drawing.Point(93, 66);
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
			this.deviceLabel.Location = new System.Drawing.Point(12, 15);
			this.deviceLabel.Name = "deviceLabel";
			this.deviceLabel.Size = new System.Drawing.Size(41, 13);
			this.deviceLabel.TabIndex = 6;
			this.deviceLabel.Text = "Device";
			// 
			// deviceNames
			// 
			this.deviceNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.deviceNames.FormattingEnabled = true;
			this.deviceNames.Location = new System.Drawing.Point(76, 12);
			this.deviceNames.Name = "deviceNames";
			this.deviceNames.Size = new System.Drawing.Size(121, 21);
			this.deviceNames.TabIndex = 7;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(224, 121);
			this.Controls.Add(this.deviceNames);
			this.Controls.Add(this.deviceLabel);
			this.Controls.Add(this.stop);
			this.Controls.Add(this.start);
			this.Controls.Add(this.serialPortNamesLabel);
			this.Controls.Add(this.serialPortNames);
			this.Controls.Add(this.statusStrip);
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
	}
}

