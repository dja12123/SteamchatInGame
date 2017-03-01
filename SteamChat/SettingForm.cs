using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamChat
{
	public partial class SettingForm : Form
	{
		private SteamChatCore core;
		public SettingForm(SteamChatCore core)
		{
			this.InitializeComponent();
			this.core = core;
			LowLevelKeyHooker.KeyBoardHook += this.keyboardHook;
		}
		private void keyboardHook(int keyCode)
		{
			if (this.shortcutTextbox.Focused)
			{
				this.Invoke(new MethodInvoker(delegate () { this.shortcutTextbox.Text = ((Keys)Enum.ToObject(typeof(Keys), keyCode)).ToString(); }));
			}
		}
		protected override void OnClosing(CancelEventArgs e)
		{
			e.Cancel = true;
			this.Visible = false;
			base.OnClosing(e);
		}
		protected override void OnVisibleChanged(EventArgs e)
		{
			if(this.Visible)
			{
				this.loadSetting();
			}
			base.OnVisibleChanged(e);
		}
		private void applyButtonClick(object sender, EventArgs e)
		{
			Configuration configuration = ConfigurationManager.OpenExeConfiguration(SteamChatCore.DIR + "\\SteamChat.exe.config");
			int x = (int)this.screenXnumberBox.Value;
			int y = (int)this.screenYnumberBox.Value;
			configuration.AppSettings.Settings["ScreenPositionX"].Value = x.ToString();
			configuration.AppSettings.Settings["ScreenPositionY"].Value = y.ToString();
			this.core.ChatForm.ChatFormLocation = new Point(x, y);
			Keys key;
			Enum.TryParse<Keys>(this.shortcutTextbox.Text, out key);
			this.core.ChatForm.ShortCut = (int)key;
			configuration.AppSettings.Settings["Shotcut"].Value = this.shortcutTextbox.Text;
			configuration.AppSettings.Settings["MsgFontSize"].Value = this.MsgFontsizeNumbox.Value.ToString();
			configuration.AppSettings.Settings["MsgHeight"].Value = this.MsgHeightNumbox.Value.ToString();
			configuration.AppSettings.Settings["MsgShowtime"].Value = this.MsgShowtimeNumbox.Value.ToString();
			configuration.Save(ConfigurationSaveMode.Full, true);
			ConfigurationManager.RefreshSection("appSettings");
		}
		private void restoreButtonClick(object sender, EventArgs e)
		{
			this.screenXnumberBox.Value = 50;
			this.screenYnumberBox.Value = 20;
			this.MsgFontsizeNumbox.Value = 14;
			this.MsgHeightNumbox.Value = 760;
			this.MsgShowtimeNumbox.Value = 20;
			this.shortcutTextbox.Text = Keys.LControlKey.ToString();
		}
		private void loadSetting()
		{
			this.screenXnumberBox.Value = int.Parse(ConfigurationManager.AppSettings["ScreenPositionX"]);
			this.screenYnumberBox.Value = int.Parse(ConfigurationManager.AppSettings["ScreenPositionY"]);
			this.shortcutTextbox.Text = ConfigurationManager.AppSettings["Shotcut"];
			this.MsgFontsizeNumbox.Value = int.Parse(ConfigurationManager.AppSettings["MsgFontSize"]);
			this.MsgHeightNumbox.Value = int.Parse(ConfigurationManager.AppSettings["MsgHeight"]);
			this.core.ChatForm.setChatAreaHeight(int.Parse(ConfigurationManager.AppSettings["MsgHeight"]));
			this.MsgShowtimeNumbox.Value = int.Parse(ConfigurationManager.AppSettings["MsgShowtime"]);
		}
	}
}
