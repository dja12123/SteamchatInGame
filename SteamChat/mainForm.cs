using SteamChat.Chat;
using SteamKit2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamChat
{
	public partial class MainForm : Form
	{
		public static readonly Color UserStateOfflineColor = Color.FromArgb(0x919191);
		public static readonly Color UserStateOnlineColor = Color.FromArgb(0x1111FF);
		public static readonly Color UserStateGamingColor = Color.FromArgb(0x116411);
		public static readonly Color FocusIOUserColor = Color.LightBlue;

		private SteamChatCore core;
		private List<Process> processes;
		private List<SteamID> userList;
		public MainForm(SteamChatCore core)
		{
			this.core = core;
			this.core.ChatForm.Show();
			this.core.SettingForm.Show();
			this.core.SettingForm.Visible = false;
			this.userList = new List<SteamID>();
			this.InitializeComponent();
			this.Text = "Steamchat in game " + SteamChatCore.VERSION;
			this.ProcessSelectCombo.DropDown += this.processComboDropDownEvent;
			this.ProcessSelectCombo.SelectedIndexChanged += this.processSelectChangeEvent;
			this.SelectChatObjCombo.DropDown += this.chatObjDropDownEvent;
			this.SelectChatObjCombo.SelectedIndexChanged += this.chatObjSelectChangeEvent;
			this.ChatObjListbox.DataSource = this.core.ChatInterface.ChattingRooms;
			this.ChatObjListbox.SelectedValueChanged += chatObjListboxSelectedValueChanged;
			this.nameLabel.Text = this.core.Steam.SteamFriends.GetPersonaName();
			this.friendsLabel.Text = this.core.Steam.SteamFriends.GetFriendCount().ToString();
			this.groupsLabel.Text = this.core.Steam.SteamFriends.GetClanCount().ToString();
			this.IOUserGridView.ColumnCount = 2;
			this.IOUserGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			this.IOUserGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			this.IOUserGridView.Columns[1].Width = 120;
			this.core.ChatInterface.ChatIOMembers.ListChanged += this.chatIOMembersListChanged;
			this.core.Steam.Manager.Subscribe<SteamFriends.PersonaStateCallback>(this.personaStateCallback);
		}
		private void personaStateCallback(SteamFriends.PersonaStateCallback callback)
		{
			if(this.core.ChatInterface.ChatIOMembers.Contains(callback.FriendID))
				this.resetIOMemberList();
		}
		private void chatIOMembersListChanged(object sender, ListChangedEventArgs e)
		{
			this.resetIOMemberList();
		}
		public void resetIOMemberList()
		{//fixit!
			this.Invoke(new MethodInvoker(delegate ()
			{
				SteamFriends steamFriends = this.core.Steam.SteamFriends;
				this.IOUserGridView.Rows.Clear();
				this.focusChatRoomLabel.Text = "To. " + (this.core.ChatInterface.FocusChatMember != null ? this.core.ChatInterface.FocusChatMember.Name : "");
				foreach (SteamID member in this.core.ChatInterface.ChatIOMembers)
				{
					Color foreColor = UserStateOnlineColor;
					string[] temp = new string[2];
					temp[0] = steamFriends.GetFriendPersonaName(member);
					if (steamFriends.GetFriendGamePlayedName(member) == null || steamFriends.GetFriendGamePlayedName(member).Equals(""))
					{
						temp[1] = steamFriends.GetFriendPersonaState(member).ToString();
						if (steamFriends.GetFriendPersonaState(member) == EPersonaState.Offline)
						{
							foreColor = UserStateOfflineColor;
						}
					}
					else
					{
						temp[1] = steamFriends.GetFriendGamePlayedName(member);
						foreColor = UserStateGamingColor;
					}
					int index = this.IOUserGridView.Rows.Add(temp);
					if (steamFriends.GetFriendRelationship(member) == EFriendRelationship.Friend)
					{
						this.IOUserGridView[0, index].Style.Font = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
					}
					this.IOUserGridView[1, index].Style.ForeColor = foreColor;
					if (this.core.ChatInterface.FocusChatMember != null && this.core.ChatInterface.FocusChatMember.ChattingMember.Contains(member))
					{
						this.IOUserGridView[0, index].Style.BackColor = FocusIOUserColor;
						this.IOUserGridView[1, index].Style.BackColor = FocusIOUserColor;
					}
					this.IOUserGridView.ClearSelection();
				}
			}));
		}
		private void chatObjListboxSelectedValueChanged(object sender, EventArgs e)
		{
			if (this.ChatObjListbox.SelectedItems.Count > 0) this.ChatListRemoveButton.Enabled = true;
			else this.ChatListRemoveButton.Enabled = false;
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.core.ChatForm.Dispose();
				if (this.components != null)
				{
					this.components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		private void processComboDropDownEvent(object sender, EventArgs e)
		{
			Dictionary<Process, string> nameTemp = new Dictionary<Process, string>();
			foreach(Process p in Process.GetProcesses())
			{
				if(p.MainWindowHandle != IntPtr.Zero && p.Id != Process.GetCurrentProcess().Id)
				{
					if(p.MainWindowTitle.Equals("")) nameTemp.Add(p, p.ProcessName);
					else nameTemp.Add(p, p.MainWindowTitle);
				}
			}
			this.processes = nameTemp.Keys.ToList();
			this.ProcessSelectCombo.DataSource = nameTemp.Values.ToList();
		}
		private void processSelectChangeEvent(object sender, EventArgs e)
		{
			if (this.isProcessVailable() != null) this.ProcessSelectOKButton.Enabled = true;
			else this.ProcessSelectOKButton.Enabled = false;
		}
		private void processSelectOKButtonClick(object sender, EventArgs e)
		{
			Process process = this.isProcessVailable();
			if (process != null)
			{
				this.core.ChatForm.HookProcess = process;
				this.processRefreshButton.Enabled = true;
			}
			else
			{
				this.ProcessSelectCombo.SelectedIndex = -1;
				this.processRefreshButton.Enabled = false;
			}
			this.ProcessSelectOKButton.Enabled = false;
		}
		private Process isProcessVailable()
		{
			Process process = null;
			try
			{
				process = this.processes[this.ProcessSelectCombo.SelectedIndex];
				if (!this.processes[this.ProcessSelectCombo.SelectedIndex].HasExited) return process;
			}
			catch { }
			return null;
		}
		private void chatObjDropDownEvent(object sender, EventArgs e)
		{
			SteamFriends steamFriend = this.core.Steam.SteamFriends;
			BindingList<string> chatObjSrc = new BindingList<string>();
			this.userList.Clear();
			this.userList.Add(null);
			chatObjSrc.Add("######## Groups #######");
			for (int i = 0; i < steamFriend.GetClanCount(); i++)
			{
				this.userList.Add(steamFriend.GetClanByIndex(i));
				chatObjSrc.Add(steamFriend.GetClanName(steamFriend.GetClanByIndex(i)));
			}
			this.userList.Add(null);
			chatObjSrc.Add("####### online friends #######");
			for (int i = 0; i < this.core.Steam.SteamFriends.GetFriendCount(); i++)
			{
				if (this.core.Steam.SteamFriends.GetFriendPersonaState(steamFriend.GetFriendByIndex(i)) != EPersonaState.Offline)
				{
					this.userList.Add(steamFriend.GetFriendByIndex(i));
					chatObjSrc.Add(steamFriend.GetFriendPersonaName(this.core.Steam.SteamFriends.GetFriendByIndex(i)));
				}
			}
			if(this.showOfflineFriendCheck.Checked)
			{
				this.userList.Add(null);
				chatObjSrc.Add("####### offline friends #######");
				for (int i = 0; i < this.core.Steam.SteamFriends.GetFriendCount(); i++)
				{
					if (this.core.Steam.SteamFriends.GetFriendPersonaState(steamFriend.GetFriendByIndex(i)) == EPersonaState.Offline)
					{
						this.userList.Add(steamFriend.GetFriendByIndex(i));
						chatObjSrc.Add(steamFriend.GetFriendPersonaName(this.core.Steam.SteamFriends.GetFriendByIndex(i)));
					}
				}
			}
			this.SelectChatObjCombo.DataSource = chatObjSrc;
		}
		private void chatObjSelectChangeEvent(object sender, EventArgs e)
		{
			if(this.isChatMemberVailable() != null) this.ChatListAddButton.Enabled = true;
			else this.ChatListAddButton.Enabled = false;
		}
		private void chatListAddButtonClick(object sender, EventArgs e)
		{
			SteamID factory = this.isChatMemberVailable();
			if (factory != null)
			{
				if(factory.IsClanAccount)
				{
					this.core.ChatForm.joinChat(new GroupChatMember(this.core, factory));
				}
				else
				{
					this.core.ChatForm.joinChat(new UserChatMember(this.core, factory));
				}
			}
			else this.SelectChatObjCombo.SelectedIndex = -1;
			this.ChatListAddButton.Enabled = false;
		}
		private SteamID isChatMemberVailable()
		{
			SteamID member = null;
			try
			{
				member = this.userList[this.SelectChatObjCombo.SelectedIndex];
				if (member != null)
				{//유효성 검사 필요
					IEnumerator<ChatMember> enumerator = this.core.ChatInterface.GetChatMemberEnumerator();
					while(enumerator.MoveNext())
					{
						if (enumerator.Current.ID == member) return null;
					}
					return member;
				}
			}
			catch { }
			return null;
		}
		private void ChatListRemoveButton_Click(object sender, EventArgs e)
		{
			int[] temp = new int[this.ChatObjListbox.SelectedIndices.Count];
			for(int i = 0; i < this.ChatObjListbox.SelectedIndices.Count; i++)
			{
				temp[i] = this.ChatObjListbox.SelectedIndices[i];
			}
			this.core.ChatInterface.leaveChat(temp);
			if(this.ChatObjListbox.SelectedIndex == -1)
			{
				this.ChatListRemoveButton.Enabled = false;
			}
		}
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Enter)
			{
				if(this.ProcessSelectCombo.ContainsFocus)
				{
					this.ProcessSelectOKButton.PerformClick();
					return true;
				}
				else if (this.SelectChatObjCombo.ContainsFocus)
				{
					this.ChatListAddButton.PerformClick();
					return true;
				}
			}
			else if(keyData == Keys.Delete)
			{
				if(this.ChatObjListbox.ContainsFocus)
				{
					this.ChatListRemoveButton.PerformClick();
					return true;
				}
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void refreshButtonClick(object sender, EventArgs e)
		{
			this.core.ChatForm.UpdateChatFormLocation();
		}

		private void settingButtonClick(object sender, EventArgs e)
		{
			this.core.SettingForm.Visible = !this.core.SettingForm.Visible;
			if(this.core.SettingForm.Visible)
			{
				this.core.SettingForm.Location = this.Location;
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://github.com/dja12123/SteamchatInGame");
		}
		private void IOUserGridViewCellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			SteamID id = this.core.ChatInterface.ChatIOMembers[e.RowIndex];
			if (this.core.Steam.SteamFriends.GetFriendRelationship(id) == EFriendRelationship.Friend)
			{
				this.core.ChatForm.joinChat(new UserChatMember(this.core, id));
			}
			else
			{
				this.core.ChatForm.sendSystemMessage("Add friends to him first");
			}
			
		}
	}
}
