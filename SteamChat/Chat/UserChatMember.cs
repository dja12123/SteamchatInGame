using SteamKit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamChat.Chat
{
	public class UserChatMember : ChatMember
	{
		public UserChatMember(SteamChatCore core, SteamID id) : base(core, id, ChatInterface.UserChatFocusColor, ChatInterface.UserChatunFocusColor)
		{
			base.callbackDispose.Add(this.core.Steam.Manager.Subscribe<SteamFriends.FriendMsgCallback>(this.chatMessageCallback));
			base.chattingUserList.Add(id);
			
		}
		public override string getName()
		{
			return base.core.Steam.SteamFriends.GetFriendPersonaName(new SteamID(base.ID));
		}
		protected override void doSendMessage(string msg)
		{
			base.core.Steam.SteamFriends.SendChatMessage(base.ID, EChatEntryType.ChatMsg, msg);
		}

		protected override string getPrifix(SteamID id)
		{
	
			if(id == this.id)
				return this.core.Steam.SteamFriends.GetFriendPersonaName(this.id) + ">>: ";
			return "<<" + this.core.Steam.SteamFriends.GetFriendPersonaName(this.id) + ": ";
		}
		private void chatMessageCallback(SteamFriends.FriendMsgCallback callback)
		{
			if (base.listenCallback != null && callback.Sender == this.id && callback.EntryType == EChatEntryType.ChatMsg)
			{
				base.ListenCallback(base.createMessageLabel(this.getPrifix(callback.Sender) + callback.Message));
			}
		}
	}
}
