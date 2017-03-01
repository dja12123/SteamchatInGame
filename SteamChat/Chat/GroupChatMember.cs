using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamKit2;
using System.Windows.Forms;

namespace SteamChat.Chat
{
	public class GroupChatMember : ChatMember
	{
		
		public GroupChatMember(SteamChatCore core, SteamID id) : base(core, id, ChatInterface.GroupChatFocusColor, ChatInterface.GroupChatunFocusColor)
		{
			base.callbackDispose.Add(this.core.Steam.Manager.Subscribe<SteamFriends.ChatMsgCallback>(this.chatMessageCallback));
			base.callbackDispose.Add(this.core.Steam.Manager.Subscribe<SteamFriends.ChatMemberInfoCallback>(this.chatMemberInfoCallback));
			base.callbackDispose.Add(this.core.Steam.Manager.Subscribe<SteamFriends.ChatEnterCallback>(this.chatEnterCallback));
		}
		public override string getName()
		{
			return base.core.Steam.SteamFriends.GetClanName(base.ID);
		}

		protected override void doSendMessage(string msg)
		{
			base.core.Steam.SteamFriends.SendChatRoomMessage(base.ID, EChatEntryType.ChatMsg, msg);
		}

		protected override string getPrifix(SteamID id)
		{
			string groupName = (this.getName().Length < 13 ? this.getName() : (this.getName().Substring(0, 10) + "..")) + "/";
			return groupName + this.core.Steam.SteamFriends.GetFriendPersonaName(id) + ": ";
		}
		private void chatMessageCallback(SteamFriends.ChatMsgCallback callback)
		{
			if (base.listenCallback != null && callback.ChatRoomID.AccountID == this.id.AccountID)
			{
				base.ListenCallback(base.createMessageLabel(this.getPrifix(callback.ChatterID) + callback.Message));
			}
		}
		private void chatEnterCallback(SteamFriends.ChatEnterCallback callback)
		{
			if (base.listenCallback != null && callback.ChatID.AccountID == this.id.AccountID)
			{
				foreach (SteamFriends.ChatMemberInfo info in callback.ChatMembers)
				{
					base.chattingUserList.Add(info.SteamID);
				}
			}
		}
		private void chatMemberInfoCallback(SteamFriends.ChatMemberInfoCallback callback)
		{
			if (base.listenCallback != null && callback.ChatRoomID.AccountID == this.id.AccountID)
			{
				switch (callback.StateChangeInfo.StateChange)
				{
					case EChatMemberStateChange.Banned:
					case EChatMemberStateChange.Disconnected:
					case EChatMemberStateChange.Kicked:
					case EChatMemberStateChange.Left:
						base.chattingUserList.Remove(callback.StateChangeInfo.ChatterActedOn);
						base.ListenCallback(base.createMessageLabel("[" + this.getName() + ": " +
						callback.StateChangeInfo.StateChange + " Event, by " +
						base.core.Steam.SteamFriends.GetFriendPersonaName(callback.StateChangeInfo.ChatterActedOn) + "]"));
						break;
					case EChatMemberStateChange.Entered:
						base.chattingUserList.Add(callback.StateChangeInfo.ChatterActedOn);
						base.ListenCallback(base.createMessageLabel("[" + this.getName() + ": " + base.core.Steam.SteamFriends.GetFriendPersonaName(callback.StateChangeInfo.ChatterActedOn)
							+ " joined the chat]"));
						break;
				}
			}
		}
	}
}
