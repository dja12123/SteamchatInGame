using SteamChat.Chat;
using SteamKit2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamChat
{
	public class ChatInterface
	{
		public delegate void ChatListenCallback(MessageLabel label);
		private static bool showInfo = true;
		public static readonly Color GroupChatFocusColor = Color.FromArgb(0xF0F0FA);
		public static readonly Color GroupChatunFocusColor = Color.FromArgb(0xBEBEC8);
		public static readonly Color UserChatFocusColor = Color.FromArgb(0xFF33FF);
		public static readonly Color UserChatunFocusColor = Color.FromArgb(0xC800C8);
		public static readonly Color SystemMessageColor = Color.FromArgb(0x04b431);

		public ChatMember FocusChatMember { get { return this.focusChatMember;} }
		private ChatMember focusChatMember;

		private BindingList<ChatMember> chattingRooms;
		public BindingList<ChatMember> ChattingRooms { get { return this.chattingRooms; } }
		private ListBindingList<SteamID> chatIOMembers;
		public ListBindingList<SteamID> ChatIOMembers { get { return this.chatIOMembers; } }
		private List<ChatMember> joinChatList;
		private SteamChatCore core;
		public ChatInterface(SteamChatCore core)
		{
			this.core = core;
			this.chatIOMembers = new ListBindingList<SteamID>();
			this.core.Steam.Manager.Subscribe<SteamFriends.ChatEnterCallback>(this.joinChatCallback);
			this.chattingRooms = new BindingList<ChatMember>();
			this.joinChatList = new List<ChatMember>();
			this.core.Steam.Manager.Subscribe<SteamFriends.FriendMsgCallback>(this.chatMessageCallback);
		}

		private void chatMessageCallback(SteamFriends.FriendMsgCallback callback)
		{
			foreach (ChatMember chattingRoom in this.chattingRooms)
			{
				if(chattingRoom.ID == callback.Sender)
				{
					return;
				}
			}
			this.core.ChatForm.Invoke(new MethodInvoker(delegate () {
				ChatMember member = new UserChatMember(this.core, callback.Sender);
				this.core.ChatForm.sendSystemMessage("new contact from " + member.Name);
				this.core.ChatForm.joinChat(member);
			}));
		}
		public void joinChat(ChatMember member, ChatListenCallback callback)
		{
			if(member is GroupChatMember)
			{
				bool flag = true;
				foreach(ChatMember cm in this.joinChatList)
				{
					if (cm.ID == member.ID) flag = false;
				}
				if(flag)
				{
					this.joinChatList.Add(member);
					this.core.Steam.SteamFriends.JoinChat(member.ID);
					member.ListenCallback = callback;
				}
			}
			else
			{
				this.chattingRooms.Add(member);
				this.chatIOMembers.addBindingList(member.ChattingMember);
				this.core.ChatForm.sendSystemMessage("join chat " + member.Name);
				member.ListenCallback = callback;
			}
			if (this.chattingRooms.Contains(member) && this.chattingRooms.Count == 1)
				this.setFocusChatMember(this.chattingRooms.IndexOf(member));
		}
		public void setFocusChatMember(int index)
		{
			try
			{
				ChatMember focusMember = this.chattingRooms[index];
				focusMember.Focus = true;
				this.focusChatMember = focusMember;
				this.core.MainForm.resetIOMemberList();
				foreach (ChatMember member in this.chattingRooms)
				{
					if(member != focusMember)
					{
						member.Focus = false;
					}
				}
			}
			catch
			{
				this.focusChatMember = null;
			}
		}
		public void leaveChat(params int[] indexs)
		{
			try
			{
				Array.Sort(indexs);
				for(int i = indexs.Length - 1; i >= 0; i--)
				{
					ChatMember member = this.chattingRooms[indexs[i]];
					member.Focus = false;
					this.core.ChatForm.sendSystemMessage("leave chat " + member.Name);
					this.core.Steam.SteamFriends.LeaveChat(member.ID);
					this.chattingRooms.Remove(member);
					this.chatIOMembers.removeBindingList(member.ChattingMember);
					member.Dispose();
				}
			}
			catch { }
		}
		private void joinChatCallback(SteamFriends.ChatEnterCallback callback)
		{
			for(int i = this.joinChatList.Count - 1; i >= 0; i--)
			{
				if (this.joinChatList[i].ID == callback.ClanID)
				{
					if(callback.EnterResponse == EChatRoomEnterResponse.Success)
					{
						this.chatIOMembers.addBindingList(joinChatList[i].ChattingMember);
						this.core.MainForm.Invoke(new MethodInvoker(delegate ()
						{
							this.chattingRooms.Add(joinChatList[i]);
							this.core.ChatForm.sendSystemMessage("join chat " + joinChatList[i].Name);
							if (showInfo)
							{
								//joinChatList[i].sendMessage("using steamchat in game " + SteamChatCore.VERSION);
								showInfo = false;
							}
						}));
					}
					this.joinChatList.RemoveAt(i);
				}
			}
		}
		public List<SteamID> getIOUserList()
		{
			List<SteamID> list = new List<SteamID>();
			
			return list;
		}
		public IEnumerator<ChatMember> GetChatMemberEnumerator()
		{
			return this.chattingRooms.GetEnumerator();
		}
		public class ListBindingList<T> : BindingList<T>
		{//바인딩 리스트 묶음을 관리하는 클래스
			private List<BindingList<T>> bindingList;
			private Dictionary<BindingList<T>, BindingList<T>> bindingListClone;
			public ListBindingList() : base()
			{
				this.bindingList = new List<BindingList<T>>();
				this.bindingListClone = new Dictionary<BindingList<T>, BindingList<T>>();
			}
			public void addBindingList(BindingList<T> list)
			{
				this.bindingList.Add(list);
				BindingList<T> cloneList = new BindingList<T>();
				foreach (T listMember in list)
				{
					cloneList.Add(listMember);
					this.itemAdd(listMember);
				}
				this.bindingListClone.Add(list, cloneList);
				list.ListChanged += bindingListChanged;
			}
			private void bindingListChanged(object sender, ListChangedEventArgs e)
			{
				BindingList<T> listSender = sender as BindingList<T>;
				switch (e.ListChangedType)
				{
					case ListChangedType.ItemAdded:
						T addItem = listSender[e.NewIndex];
						this.bindingListClone[listSender].Add(addItem);
						this.itemAdd(addItem);
						break;
					case ListChangedType.ItemDeleted:
						T removeItem = this.bindingListClone[listSender][e.NewIndex];
						this.bindingListClone[listSender].Remove(removeItem);
						this.itemRemove(listSender, removeItem);
						break;
				}
			}
			public void removeBindingList(BindingList<T> list)
			{
				foreach(T removeItem in list)
				{
					this.itemRemove(list, removeItem);
				}
				this.bindingList.Remove(list);
				this.bindingListClone.Remove(list);
				list.ListChanged -= this.bindingListChanged;
			}
			private void itemRemove(BindingList<T> sender, T removeItem)
			{
				bool removeFlag = true;
				foreach (BindingList<T> list in this.bindingList)
				{
					if (list != sender && list.Contains(removeItem))
						removeFlag = false;
				}
				if (removeFlag) base.Remove(removeItem);
			}
			private void itemAdd(T addItem)
			{
				if (!base.Contains(addItem))
					base.Add(addItem);
			}
		}
	}
}
