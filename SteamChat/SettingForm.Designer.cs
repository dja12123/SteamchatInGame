namespace SteamChat
{
	partial class SettingForm
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
			System.Windows.Forms.GroupBox positionGroupBox;
			System.Windows.Forms.GroupBox messagegroupBox;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
			this.screenYlabel = new System.Windows.Forms.Label();
			this.screenXlabel = new System.Windows.Forms.Label();
			this.screenYnumberBox = new System.Windows.Forms.NumericUpDown();
			this.screenXnumberBox = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.MsgShowtimeNumbox = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.MsgFontsizeNumbox = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.pixelLabel = new System.Windows.Forms.Label();
			this.MsgHeightNumbox = new System.Windows.Forms.NumericUpDown();
			this.shortcutGroupBox = new System.Windows.Forms.GroupBox();
			this.shortcutTextbox = new System.Windows.Forms.TextBox();
			this.applyButton = new System.Windows.Forms.Button();
			this.restoreButton = new System.Windows.Forms.Button();
			positionGroupBox = new System.Windows.Forms.GroupBox();
			messagegroupBox = new System.Windows.Forms.GroupBox();
			positionGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.screenYnumberBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.screenXnumberBox)).BeginInit();
			messagegroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MsgShowtimeNumbox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MsgFontsizeNumbox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MsgHeightNumbox)).BeginInit();
			this.shortcutGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// positionGroupBox
			// 
			positionGroupBox.Controls.Add(this.screenYlabel);
			positionGroupBox.Controls.Add(this.screenXlabel);
			positionGroupBox.Controls.Add(this.screenYnumberBox);
			positionGroupBox.Controls.Add(this.screenXnumberBox);
			positionGroupBox.Location = new System.Drawing.Point(12, 12);
			positionGroupBox.Name = "positionGroupBox";
			positionGroupBox.Size = new System.Drawing.Size(142, 44);
			positionGroupBox.TabIndex = 0;
			positionGroupBox.TabStop = false;
			positionGroupBox.Text = "Screen position(%)";
			// 
			// screenYlabel
			// 
			this.screenYlabel.AutoSize = true;
			this.screenYlabel.Location = new System.Drawing.Point(72, 19);
			this.screenYlabel.Name = "screenYlabel";
			this.screenYlabel.Size = new System.Drawing.Size(17, 12);
			this.screenYlabel.TabIndex = 3;
			this.screenYlabel.Text = "Y:";
			// 
			// screenXlabel
			// 
			this.screenXlabel.AutoSize = true;
			this.screenXlabel.Location = new System.Drawing.Point(4, 19);
			this.screenXlabel.Name = "screenXlabel";
			this.screenXlabel.Size = new System.Drawing.Size(17, 12);
			this.screenXlabel.TabIndex = 2;
			this.screenXlabel.Text = "X:";
			// 
			// screenYnumberBox
			// 
			this.screenYnumberBox.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.screenYnumberBox.Location = new System.Drawing.Point(95, 17);
			this.screenYnumberBox.Name = "screenYnumberBox";
			this.screenYnumberBox.Size = new System.Drawing.Size(40, 21);
			this.screenYnumberBox.TabIndex = 1;
			// 
			// screenXnumberBox
			// 
			this.screenXnumberBox.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.screenXnumberBox.Location = new System.Drawing.Point(26, 17);
			this.screenXnumberBox.Name = "screenXnumberBox";
			this.screenXnumberBox.Size = new System.Drawing.Size(40, 21);
			this.screenXnumberBox.TabIndex = 0;
			// 
			// messagegroupBox
			// 
			messagegroupBox.Controls.Add(this.label4);
			messagegroupBox.Controls.Add(this.label5);
			messagegroupBox.Controls.Add(this.MsgShowtimeNumbox);
			messagegroupBox.Controls.Add(this.label2);
			messagegroupBox.Controls.Add(this.label3);
			messagegroupBox.Controls.Add(this.MsgFontsizeNumbox);
			messagegroupBox.Controls.Add(this.label1);
			messagegroupBox.Controls.Add(this.pixelLabel);
			messagegroupBox.Controls.Add(this.MsgHeightNumbox);
			messagegroupBox.Location = new System.Drawing.Point(12, 62);
			messagegroupBox.Name = "messagegroupBox";
			messagegroupBox.Size = new System.Drawing.Size(229, 102);
			messagegroupBox.TabIndex = 4;
			messagegroupBox.TabStop = false;
			messagegroupBox.Text = "Messagebox";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 73);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(97, 12);
			this.label4.TabIndex = 9;
			this.label4.Text = "msg show time:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(177, 73);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(26, 12);
			this.label5.TabIndex = 8;
			this.label5.Text = "sec";
			// 
			// MsgShowtimeNumbox
			// 
			this.MsgShowtimeNumbox.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.MsgShowtimeNumbox.Location = new System.Drawing.Point(111, 71);
			this.MsgShowtimeNumbox.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.MsgShowtimeNumbox.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.MsgShowtimeNumbox.Name = "MsgShowtimeNumbox";
			this.MsgShowtimeNumbox.Size = new System.Drawing.Size(63, 21);
			this.MsgShowtimeNumbox.TabIndex = 7;
			this.MsgShowtimeNumbox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 12);
			this.label2.TabIndex = 6;
			this.label2.Text = "font size:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(177, 46);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 12);
			this.label3.TabIndex = 5;
			this.label3.Text = "point";
			// 
			// MsgFontsizeNumbox
			// 
			this.MsgFontsizeNumbox.Location = new System.Drawing.Point(111, 44);
			this.MsgFontsizeNumbox.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
			this.MsgFontsizeNumbox.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.MsgFontsizeNumbox.Name = "MsgFontsizeNumbox";
			this.MsgFontsizeNumbox.Size = new System.Drawing.Size(63, 21);
			this.MsgFontsizeNumbox.TabIndex = 4;
			this.MsgFontsizeNumbox.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 12);
			this.label1.TabIndex = 3;
			this.label1.Text = "height:";
			// 
			// pixelLabel
			// 
			this.pixelLabel.AutoSize = true;
			this.pixelLabel.Location = new System.Drawing.Point(177, 19);
			this.pixelLabel.Name = "pixelLabel";
			this.pixelLabel.Size = new System.Drawing.Size(32, 12);
			this.pixelLabel.TabIndex = 2;
			this.pixelLabel.Text = "pixel";
			// 
			// MsgHeightNumbox
			// 
			this.MsgHeightNumbox.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.MsgHeightNumbox.Location = new System.Drawing.Point(111, 17);
			this.MsgHeightNumbox.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.MsgHeightNumbox.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.MsgHeightNumbox.Name = "MsgHeightNumbox";
			this.MsgHeightNumbox.Size = new System.Drawing.Size(63, 21);
			this.MsgHeightNumbox.TabIndex = 0;
			this.MsgHeightNumbox.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
			// 
			// shortcutGroupBox
			// 
			this.shortcutGroupBox.Controls.Add(this.shortcutTextbox);
			this.shortcutGroupBox.Location = new System.Drawing.Point(165, 12);
			this.shortcutGroupBox.Name = "shortcutGroupBox";
			this.shortcutGroupBox.Size = new System.Drawing.Size(76, 44);
			this.shortcutGroupBox.TabIndex = 1;
			this.shortcutGroupBox.TabStop = false;
			this.shortcutGroupBox.Text = "Shortcut";
			// 
			// shortcutTextbox
			// 
			this.shortcutTextbox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.shortcutTextbox.Location = new System.Drawing.Point(6, 17);
			this.shortcutTextbox.Name = "shortcutTextbox";
			this.shortcutTextbox.ReadOnly = true;
			this.shortcutTextbox.Size = new System.Drawing.Size(64, 21);
			this.shortcutTextbox.TabIndex = 0;
			this.shortcutTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// applyButton
			// 
			this.applyButton.Location = new System.Drawing.Point(180, 170);
			this.applyButton.Name = "applyButton";
			this.applyButton.Size = new System.Drawing.Size(61, 20);
			this.applyButton.TabIndex = 5;
			this.applyButton.Text = "Apply";
			this.applyButton.UseVisualStyleBackColor = true;
			this.applyButton.Click += new System.EventHandler(this.applyButtonClick);
			// 
			// restoreButton
			// 
			this.restoreButton.Location = new System.Drawing.Point(107, 170);
			this.restoreButton.Name = "restoreButton";
			this.restoreButton.Size = new System.Drawing.Size(61, 20);
			this.restoreButton.TabIndex = 6;
			this.restoreButton.Text = "Restore";
			this.restoreButton.UseVisualStyleBackColor = true;
			this.restoreButton.Click += new System.EventHandler(this.restoreButtonClick);
			// 
			// SettingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(253, 200);
			this.Controls.Add(this.restoreButton);
			this.Controls.Add(this.applyButton);
			this.Controls.Add(messagegroupBox);
			this.Controls.Add(this.shortcutGroupBox);
			this.Controls.Add(positionGroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "SettingForm";
			this.Text = "Setting";
			positionGroupBox.ResumeLayout(false);
			positionGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.screenYnumberBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.screenXnumberBox)).EndInit();
			messagegroupBox.ResumeLayout(false);
			messagegroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.MsgShowtimeNumbox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MsgFontsizeNumbox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MsgHeightNumbox)).EndInit();
			this.shortcutGroupBox.ResumeLayout(false);
			this.shortcutGroupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label screenYlabel;
		private System.Windows.Forms.Label screenXlabel;
		private System.Windows.Forms.NumericUpDown screenYnumberBox;
		private System.Windows.Forms.NumericUpDown screenXnumberBox;
		private System.Windows.Forms.GroupBox shortcutGroupBox;
		private System.Windows.Forms.TextBox shortcutTextbox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown MsgShowtimeNumbox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown MsgFontsizeNumbox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label pixelLabel;
		private System.Windows.Forms.NumericUpDown MsgHeightNumbox;
		private System.Windows.Forms.Button applyButton;
		private System.Windows.Forms.Button restoreButton;
	}
}