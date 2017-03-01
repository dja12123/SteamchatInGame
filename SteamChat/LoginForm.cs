using SteamKit2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using SteamKit2.Unified.Internal;
using System.Runtime.CompilerServices;

namespace SteamChat
{
	public partial class LoginForm : Form
	{
		private bool isLoginSuccess = false;
		public bool IsLoginSuccess { get { return this.isLoginSuccess; } }
		private SteamChatCore core;
		private bool is2FA = false;
		private bool steamGuardInput = false;
		private bool SteamGuardInput
		{
			get
			{
				return this.steamGuardInput;
			}
			set
			{
				this.Invoke(new MethodInvoker(delegate ()
				{
					this.steamGuardInput = value;
					this.steamGuardLabel.Visible = value;
					this.steamGuardTextBox.Visible = value;
				}));
			}
		}
		public LoginForm(SteamChatCore core)
		{
			this.core = core;
			this.core.Steam.Manager.Subscribe<SteamClient.ConnectedCallback>(this.onConnected);
			this.core.Steam.Manager.Subscribe<SteamUser.LoggedOnCallback>(this.onLoggedOn);
			this.core.Steam.Manager.Subscribe<SteamUser.UpdateMachineAuthCallback>(this.onMachineAuth);
			this.InitializeComponent();
		}
		private void loginButton_Click(object sender, EventArgs e)
		{
			this.messageLabel.Text = ("login in " + this.idTextBox.Text);
			this.core.Steam.SteamClient.Connect();
		}
		private void onConnected(SteamClient.ConnectedCallback callback)
		{
			byte[] sentryHash = null;
			if (File.Exists(SteamChatCore.DIR + "\\sentry.bin"))
			{
				// if we have a saved sentry file, read and SHA1 hash it
				byte[] sentryFile = File.ReadAllBytes(SteamChatCore.DIR + "\\sentry.bin");
				sentryHash = CryptoHelper.SHAHash(sentryFile);
			}
			SteamUser.LogOnDetails logonDetails = new SteamUser.LogOnDetails
			{
				Username = this.idTextBox.Text,
				Password = this.pwTextBox.Text,
				LoginID = (uint)this.core.Steam.SteamClient.GetHashCode(),
				SentryFileHash = sentryHash,
			};
			if (this.is2FA) logonDetails.TwoFactorCode = this.steamGuardTextBox.Text;
			else logonDetails.AuthCode = this.steamGuardTextBox.Text;
			try
			{
				this.core.Steam.SteamUser.LogOn(logonDetails);
			}
			catch(Exception e)
			{
				this.setMessageText(e.ToString());
			}
			if (callback.Result == EResult.OK)
			{
				this.setMessageText("Connect to Steam...");
			}
			else
			{
				this.setMessageText("Unable to connect to Steam" + callback.Result);
			}
		}
		private void onLoggedOn(SteamUser.LoggedOnCallback callback)
		{
			bool isSteamGuard = callback.Result == EResult.AccountLogonDenied;
			this.is2FA = callback.Result == EResult.AccountLoginDeniedNeedTwoFactor;

			if (isSteamGuard || this.is2FA)
			{
				if (this.is2FA)
				{
					this.setMessageText("Check your authenticator app: ");
				}
				else
				{
					this.setMessageText("Sent to the email at " + callback.EmailDomain);
				}
				this.SteamGuardInput = true;
			}
			else if (callback.Result != EResult.OK)
			{
				this.setMessageText("Unable to logon: " + callback.Result + " / " + callback.ExtendedResult);
			}
			else
			{
				this.setMessageText("Login success");
				this.isLoginSuccess = true;
				this.Dispose();
			}
		}
		private void onMachineAuth(SteamUser.UpdateMachineAuthCallback callback)
		{
			Console.WriteLine("Updating sentryfile...");

			// write out our sentry file
			// ideally we'd want to write to the filename specified in the callback
			// but then this sample would require more code to find the correct sentry file to read during logon
			// for the sake of simplicity, we'll just use "sentry.bin"

			int fileSize;
			byte[] sentryHash;
			using (var fs = File.Open(SteamChatCore.DIR + "\\sentry.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite))
			{
				fs.Seek(callback.Offset, SeekOrigin.Begin);
				fs.Write(callback.Data, 0, callback.BytesToWrite);
				fileSize = (int)fs.Length;

				fs.Seek(0, SeekOrigin.Begin);
				using (var sha = new SHA1CryptoServiceProvider())
				{
					sentryHash = sha.ComputeHash(fs);
				}
			}
			// inform the steam servers that we're accepting this sentry file
			this.core.Steam.SteamUser.SendMachineAuthResponse(new SteamUser.MachineAuthDetails
			{
				JobID = callback.JobID,

				FileName = callback.FileName,

				BytesWritten = callback.BytesToWrite,
				FileSize = fileSize,
				Offset = callback.Offset,

				Result = EResult.OK,
				LastError = 0,

				OneTimePassword = callback.OneTimePassword,

				SentryFileHash = sentryHash,
			});
			Console.WriteLine("Done!");
		}
		private void setMessageText(string str)
		{
			this.Invoke(new MethodInvoker(delegate ()
			{
				this.messageLabel.Text = str;
			}));
		}
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Enter)
			{
				this.loginButton.PerformClick();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}
	}
}
