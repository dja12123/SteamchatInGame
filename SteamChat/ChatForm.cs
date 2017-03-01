using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using static SteamChat.LowLevelWindowHooker;
using SteamChat.Chat;
using System.Configuration;

namespace SteamChat
{
	public partial class ChatForm : Form
	{
		private SteamChatCore core;

		public const int MARGIN = 5;
		public int ShortCut { get; set; } = (int)Keys.LControlKey;
		private bool activeChatInput = true;
		public bool ChatInput { get { return this.activeChatInput; } }
		private Panel inputPanel;
		private ComboBox chatListCombo;
		private Label infoLabel;
		private InputTextBox mainTextBox;
		private Button sendButton;

		public int MaxChatMessageSize { get; set; } = 10;
		private List<MessageLabel> messageList;
		private Label textZone;
		private IntPtr beforeFocusWindow;

		private List<LowLevelWindowHooker> whookList;
		private Process hookProcess;
		public Process HookProcess
		{
			get
			{
				return this.hookProcess;
			}
			set
			{
				//0x000A 리사이즈시작 0x000B 리사이즈 완료
				//0x0016 최소화 0x0017 복구
				//0x8005 포커스
				if (this.hookProcess != null)
				{
					this.WindowUnHook();
				}
				this.hookProcess = value;
				this.whookList.Add(new LowLevelWindowHooker(value, 0x000A, 0x000B, this.WindowCallBack));
				this.whookList.Add(new LowLevelWindowHooker(value, 0x0016, 0x0017, this.WindowCallBack));
				this.whookList.Add(new LowLevelWindowHooker(value, 0x8005, 0x8005, this.WindowCallBack));
				this.UpdateChatFormLocation();
			}
		}
		private Point chatFormLocation;
		public Point ChatFormLocation
		{
			get
			{
				return this.chatFormLocation;
			}
			set
			{
				if (value.X >= 0 && value.X <= 100 && value.Y >= 0 && value.Y <= 100)
				{
					this.chatFormLocation = value;
					if (this.hookProcess != null) this.UpdateChatFormLocation();
				}
			}
		}
		public ChatForm(SteamChatCore core)
		{
			this.core = core;
			this.InitializeComponent();
			this.BackColor = Color.LightGray;
			this.TransparencyKey = Color.LightGray;
			this.messageList = new List<MessageLabel>();
			this.whookList = new List<LowLevelWindowHooker>();
			this.ChatFormLocation = new Point(int.Parse(ConfigurationManager.AppSettings["ScreenPositionX"]), int.Parse(ConfigurationManager.AppSettings["ScreenPositionY"]));

			this.inputPanel = new Panel();
			this.inputPanel.BackColor = Color.FromArgb(220, 220, 220);
			this.inputPanel.Width = 615;
			this.Controls.Add(this.inputPanel);

			this.chatListCombo = new ComboBox();
			this.chatListCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.chatListCombo.Location = new Point(5, MARGIN);
			this.chatListCombo.Width = 115;
			this.inputPanel.Controls.Add(this.chatListCombo);

			this.infoLabel = new Label();
			this.infoLabel.SetBounds(5, MARGIN + this.chatListCombo.Height + 5, 115, 20);
			this.infoLabel.TextAlign = ContentAlignment.TopCenter;
			this.inputPanel.Controls.Add(this.infoLabel);

			this.mainTextBox = new InputTextBox(this.infoLabel);
			this.mainTextBox.Location = new Point(125, MARGIN);
			this.mainTextBox.SetBounds(125, MARGIN, 435, 40);
			this.mainTextBox.Font = new Font(this.mainTextBox.Font.FontFamily, 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(129)));
			this.mainTextBox.Multiline = true;
			this.inputPanel.Controls.Add(this.mainTextBox);

			this.sendButton = new Button();
			this.sendButton.SetBounds(565, MARGIN, 45, this.mainTextBox.Height);
			this.sendButton.Text = "Send";
			this.sendButton.BackColor = Color.FromArgb(220, 220, 220);
			this.sendButton.Click += this.SendButton_Click;
			this.inputPanel.Controls.Add(this.sendButton);
			this.inputPanel.Height = this.mainTextBox.Height + (MARGIN * 2);

			this.textZone = new Label();

			this.Controls.Add(this.textZone);

			this.setChatAreaHeight(int.Parse(ConfigurationManager.AppSettings["MsgHeight"]));
			this.Deactivate += chatFormFocusLoseEvent;
			LowLevelKeyHooker.KeyBoardHook += this.keyEventListener;

			this.chatListCombo.DataSource = this.core.ChatInterface.ChattingRooms;
			this.chatListCombo.SelectedValueChanged += this.selectChange;
		}
		public void setChatAreaHeight(int height)
		{
			this.Height = height;
			this.inputPanel.Location = new Point(10, this.Height - 145);
			this.textZone.SetBounds(MARGIN, 0, this.Width - (MARGIN * 2), this.inputPanel.Location.Y - MARGIN);
		}
		private void selectChange(object sender, EventArgs e)
		{
			this.core.ChatInterface.setFocusChatMember(this.chatListCombo.SelectedIndex);
		}
		private void chatFormFocusLoseEvent(object sender, EventArgs e)
		{
			this.ActiveChatInput(false);
		}
		KeysConverter kc = new KeysConverter();
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
				{
					this.components.Dispose();
				}
				Console.WriteLine("unhook");
				this.WindowUnHook();
			}
			base.Dispose(disposing);
		}
		private void keyEventListener(int keyCode)
		{
			if (keyCode == this.ShortCut)
			{
				if (this.ChatInput) this.SendMessage();
				this.Invoke(new MethodInvoker(delegate () { this.ActiveChatInput(!this.ChatInput); }));
			}
		}
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Tab && this.activeChatInput)
			{
				if (this.chatListCombo.Items.Count - 1 > this.chatListCombo.SelectedIndex)
				{
					this.chatListCombo.SelectedIndex += 1;
				}
				else
				{
					try
					{
						this.chatListCombo.SelectedIndex = 0;
					}
					catch { }
				}
				return true;
			}
			if (keyData == Keys.Enter)
			{
				this.sendButton.PerformClick();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}
		private void SendButton_Click(object sender, EventArgs e)
		{
			this.SendMessage();
		}
		private void SendMessage()
		{
			if (this.mainTextBox.Text != "")
			{
				if (this.chatListCombo.SelectedIndex != -1)
				{
					this.core.ChatInterface.ChattingRooms[this.chatListCombo.SelectedIndex].sendMessage(this.mainTextBox.Text);
					this.mainTextBox.Clear();
				}
				else
				{
					this.sendSystemMessage("select a target");
				}
			}
		}
		private void ActiveChatInput(bool option)
		{
			if (this.activeChatInput != option)
			{
				this.activeChatInput = option;
				foreach (MessageLabel label in this.messageList)
				{
					label.setForcedShow(option);
				}
				this.inputPanel.Visible = option;
				if (option)
				{
					uint foreThread = GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero);
					uint appThread = GetCurrentThreadId();
					this.beforeFocusWindow = GetForegroundWindow();
					this.Activate();
					SetForegroundWindow(this.Handle);
					AttachThreadInput(foreThread, appThread, true);
					this.BringToFront();
					this.Focus();
					AttachThreadInput(foreThread, appThread, false);
					this.mainTextBox.Clear();
					this.mainTextBox.Select();
				}
				else
				{
					SetForegroundWindow(this.beforeFocusWindow);
					this.TopMost = true;
				}
			}
		}
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			e.Graphics.FillRectangle(Brushes.LightGray, e.ClipRectangle);
		}
		public void joinChat(ChatMember member)
		{
			foreach(ChatMember chatListMember in this.core.ChatInterface.ChattingRooms)
			{
				if(chatListMember.ID == member.ID)
				{
					this.sendSystemMessage("You are already in a chat");
					return;
				}
			}
			this.core.ChatInterface.joinChat(member, this.messageListenCallback);
		}
		private void messageListenCallback(MessageLabel label)
		{
			this.Invoke(new MethodInvoker(delegate ()
			{
				this.showMessage(label);
			}));
		}
		public void sendSystemMessage(string str)
		{
			this.core.ChatForm.showMessage(new MessageLabel("system: " + str, ChatInterface.SystemMessageColor, this.ChatInput));
		}
		public void showMessage(MessageLabel nowTaskLabel)
		{
			nowTaskLabel.MaximumSize = new Size(this.textZone.Width, 0);
			this.messageList.Add(nowTaskLabel);
			this.textZone.Controls.Add(nowTaskLabel);
			int messageLocation = this.textZone.Height;
			for (int i = this.messageList.Count - 1; i >= 0; i--)
			{
				messageLocation -= this.messageList[i].Height;
				if (messageLocation > 0)
				{
					this.messageList[i].Location = new Point(0, messageLocation);
				}
				else
				{
					this.messageList[i].Dispose();
					this.messageList.RemoveAt(i);
				}
			}
		}
		private void WindowCallBack(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
		{
			this.UpdateChatFormLocation();
		}
		public void WindowUnHook()
		{
			foreach (LowLevelWindowHooker hooker in this.whookList)
			{
				hooker.Dispose();
			}
			this.whookList.Clear();
		}
		public void UpdateChatFormLocation()
		{
			RECT r = new RECT();
			LowLevelWindowHooker.GetWindowRect(this.HookProcess.MainWindowHandle, out r);
			Console.WriteLine(r.Left + " " + r.Top + " " + (r.Right - r.Left) + " " + (r.Bottom - r.Top) + " " + this.inputPanel.Location.Y);
			Point windowLocation = new Point(r.Left - (this.Width / 2) + ((r.Right - r.Left) * this.chatFormLocation.X / 100)
				, r.Bottom - this.inputPanel.Location.Y - (this.inputPanel.Height / 2) - ((r.Bottom - r.Top) * this.chatFormLocation.Y / 100));
			this.Invoke(new MethodInvoker(delegate ()
			{
				this.SetDesktopLocation(windowLocation.X, windowLocation.Y);
				this.TopMost = true;
			}));
		}
	}
}