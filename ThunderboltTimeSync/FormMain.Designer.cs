namespace ThunderboltTimeSync {
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
			this.labelTimestamps = new System.Windows.Forms.Label();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.latestLogMessage = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelTimestamps
			// 
			this.labelTimestamps.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelTimestamps.Location = new System.Drawing.Point(0, 0);
			this.labelTimestamps.Name = "labelTimestamps";
			this.labelTimestamps.Size = new System.Drawing.Size(486, 358);
			this.labelTimestamps.TabIndex = 0;
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.latestLogMessage});
			this.statusStrip.Location = new System.Drawing.Point(0, 336);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(486, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
			// 
			// latestLogMessage
			// 
			this.latestLogMessage.ForeColor = System.Drawing.Color.Black;
			this.latestLogMessage.Name = "latestLogMessage";
			this.latestLogMessage.Size = new System.Drawing.Size(66, 17);
			this.latestLogMessage.Text = "{RUNTIME}";
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(486, 358);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.labelTimestamps);
			this.Name = "FormMain";
			this.Text = "Thunderbolt Time Sync";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelTimestamps;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel latestLogMessage;
	}
}

