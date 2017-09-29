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
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(486, 358);
			this.Controls.Add(this.labelTimestamps);
			this.Name = "FormMain";
			this.Text = "Thunderbolt Time Sync";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label labelTimestamps;
	}
}

