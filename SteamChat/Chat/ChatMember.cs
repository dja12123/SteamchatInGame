using SteamKit2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SteamChat.ChatInterface;

namespace SteamChat.Chat
{
	public abstract class ChatMember : IDisposable
	{
		protected BindingList<SteamID> chattingUserList;
		protected ChatListenCallback listenCallback;
		public ChatListenCallback ListenCallback
		{
			get
			{
				return this.listenCallback;
			}
			set
			{
				this.listenCallback = value;
			}
		}
		private bool focus;
		public bool Focus
		{
			get
			{
				return this.focus;
			}
			set
			{
				if(value != this.focus)
				{
					this.focus = value;
					foreach(MessageLabel label in this.messages)
					{
						label.ForeColor = (value ? this.focusColor : this.unFocusColor);
					}
				}
			}
		}
		public string Name { get { return this.getName(); } }
		public SteamID ID { get { return id; } }
		protected SteamID id;
		protected SteamChatCore core;
		protected List<MessageLabel> messages;
		protected List<IDisposable> callbackDispose;
		private Color focusColor;
		public Color FocusColor { get { return this.focusColor; } }
		private Color unFocusColor;
		public Color UnFocusColor { get { return this.unFocusColor; } }
		public BindingList<SteamID> ChattingMember { get { return this.chattingUserList; } }
		protected ChatMember(SteamChatCore core, SteamID id, Color focusColor, Color unFocusColor)
		{
			this.chattingUserList = new BindingList<SteamID>();
			this.id = id;
			this.core = core;
			this.messages = new List<MessageLabel>();
			this.focusColor = focusColor;
			this.unFocusColor = unFocusColor;
			this.callbackDispose = new List<IDisposable>();
		}
		public override string ToString()
		{
			return this.getName();
		}
		public void sendMessage(string msg)
		{
			this.doSendMessage(msg);
			this.core.ChatForm.showMessage(this.createMessageLabel(this.getPrifix(this.core.Steam.SteamClient.SteamID) + msg));
		}
		public abstract string getName();
		protected abstract void doSendMessage(string msg);
		private void msgLabelDisposed(object sender, EventArgs e)
		{
			this.messages.Remove((MessageLabel)sender);
		}
		protected MessageLabel createMessageLabel(string str)
		{
			MessageLabel messageLabel = new MessageLabel(str, this.focus ? this.focusColor : this.unFocusColor, this.core.ChatForm.ChatInput);
			this.messages.Add(messageLabel);
			messageLabel.Disposed += msgLabelDisposed;
			return messageLabel;
		}
		public void Dispose()
		{
			foreach(IDisposable dispose in this.callbackDispose)
			{
				dispose.Dispose();
			}
		}
		protected abstract string getPrifix(SteamID id);
	}
}
