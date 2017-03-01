using System;
using System.Drawing;

namespace SteamChat
{
	partial class LoginForm
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
			Action action = delegate ()
			{
				if (disposing && (components != null))
				{
					components.Dispose();
				}
				base.Dispose(disposing);
			};
			if (this.InvokeRequired) this.BeginInvoke(new Action(action));
			else action();
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
			this.idTextBox = new System.Windows.Forms.TextBox();
			this.pwTextBox = new System.Windows.Forms.TextBox();
			this.steamGuardTextBox = new System.Windows.Forms.TextBox();
			this.idLabel = new System.Windows.Forms.Label();
			this.pwLabel = new System.Windows.Forms.Label();
			this.steamGuardLabel = new System.Windows.Forms.Label();
			this.loginButton = new System.Windows.Forms.Button();
			this.messageLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// idTextBox
			// 
			this.idTextBox.Location = new System.Drawing.Point(45, 12);
			this.idTextBox.Name = "idTextBox";
			this.idTextBox.Size = new System.Drawing.Size(166, 21);
			this.idTextBox.TabIndex = 0;
			// 
			// pwTextBox
			// 
			this.pwTextBox.Location = new System.Drawing.Point(45, 39);
			this.pwTextBox.Name = "pwTextBox";
			this.pwTextBox.PasswordChar = '*';
			this.pwTextBox.Size = new System.Drawing.Size(166, 21);
			this.pwTextBox.TabIndex = 1;
			// 
			// steamGuardTextBox
			// 
			this.steamGuardTextBox.Location = new System.Drawing.Point(90, 66);
			this.steamGuardTextBox.Name = "steamGuardTextBox";
			this.steamGuardTextBox.Size = new System.Drawing.Size(121, 21);
			this.steamGuardTextBox.TabIndex = 2;
			this.steamGuardTextBox.Visible = false;
			// 
			// idLabel
			// 
			this.idLabel.AutoSize = true;
			this.idLabel.Location = new System.Drawing.Point(5, 15);
			this.idLabel.Name = "idLabel";
			this.idLabel.Size = new System.Drawing.Size(16, 12);
			this.idLabel.TabIndex = 3;
			this.idLabel.Text = "ID";
			// 
			// pwLabel
			// 
			this.pwLabel.AutoSize = true;
			this.pwLabel.Location = new System.Drawing.Point(5, 42);
			this.pwLabel.Name = "pwLabel";
			this.pwLabel.Size = new System.Drawing.Size(34, 12);
			this.pwLabel.TabIndex = 4;
			this.pwLabel.Text = "Pass";
			// 
			// steamGuardLabel
			// 
			this.steamGuardLabel.AutoSize = true;
			this.steamGuardLabel.Location = new System.Drawing.Point(5, 69);
			this.steamGuardLabel.Name = "steamGuardLabel";
			this.steamGuardLabel.Size = new System.Drawing.Size(79, 12);
			this.steamGuardLabel.TabIndex = 5;
			this.steamGuardLabel.Text = "Steam Guard";
			this.steamGuardLabel.Visible = false;
			// 
			// loginButton
			// 
			this.loginButton.Location = new System.Drawing.Point(217, 12);
			this.loginButton.Name = "loginButton";
			this.loginButton.Size = new System.Drawing.Size(47, 47);
			this.loginButton.TabIndex = 6;
			this.loginButton.Text = "Login";
			this.loginButton.UseVisualStyleBackColor = true;
			this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
			// 
			// messageLabel
			// 
			this.messageLabel.AutoSize = true;
			this.messageLabel.Location = new System.Drawing.Point(5, 96);
			this.messageLabel.MaximumSize = new System.Drawing.Size(250, 0);
			this.messageLabel.Name = "messageLabel";
			this.messageLabel.Size = new System.Drawing.Size(0, 12);
			this.messageLabel.TabIndex = 7;
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(270, 131);
			this.Controls.Add(this.messageLabel);
			this.Controls.Add(this.loginButton);
			this.Controls.Add(this.steamGuardLabel);
			this.Controls.Add(this.pwLabel);
			this.Controls.Add(this.idLabel);
			this.Controls.Add(this.steamGuardTextBox);
			this.Controls.Add(this.pwTextBox);
			this.Controls.Add(this.idTextBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LoginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Steam Login";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox idTextBox;
		private System.Windows.Forms.TextBox pwTextBox;
		private System.Windows.Forms.TextBox steamGuardTextBox;
		private System.Windows.Forms.Label idLabel;
		private System.Windows.Forms.Label pwLabel;
		private System.Windows.Forms.Label steamGuardLabel;
		private System.Windows.Forms.Button loginButton;
		private System.Windows.Forms.Label messageLabel;
	}
}