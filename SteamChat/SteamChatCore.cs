using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SteamChat
{
	public class SteamChatCore
	{
		public static readonly string VERSION = "v0.1.9 beta";
		public static readonly string DIR = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
		private static SteamChatCore core;
		private ManualResetEvent coreResetEvent;
		private SteamInterface steam;
		public SteamInterface Steam { get { return this.steam; } }
		private LoginForm loginForm;
		private MainForm mainForm;
		public MainForm MainForm { get { return this.mainForm; } }
		private ChatForm chatForm;
		public ChatForm ChatForm { get { return this.chatForm; } }
		private SettingForm settinForm;
		public SettingForm SettingForm { get { return this.settinForm; } }
		private ChatInterface chatInterface;
		public ChatInterface ChatInterface { get { return this.chatInterface; } }
		private Thread steamThread;
		[STAThread]
		static void Main()
		{
			Console.WriteLine(DIR);
			LowLevelKeyHooker.SetHook();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			core = new SteamChatCore();
			LowLevelKeyHooker.UnHook();
		}
		private SteamChatCore()
		{
			this.steamThread = new Thread(delegate ()
			{
				SteamInterface steam = new SteamInterface();
				this.steam = steam;
				this.coreResetEvent.Set();
				steam.run();
				Console.WriteLine("스팀 스레드 종료");
			});
			this.coreResetEvent = new ManualResetEvent(false);
			this.steamThread.Start();
			this.coreResetEvent.WaitOne();
			this.chatInterface = new ChatInterface(this);
			this.loginForm = new LoginForm(this);
			Application.Run(this.loginForm);
			if(this.loginForm.IsLoginSuccess)
			{
				this.chatForm = new ChatForm(this);
				this.settinForm = new SettingForm(this);
				this.mainForm = new MainForm(this);
				Application.Run(this.mainForm);
			}
			this.steam.stop();
		}

	}
}