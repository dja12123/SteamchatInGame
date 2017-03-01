using SteamKit2;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using SteamKit2.Unified.Internal;
using System.Runtime.CompilerServices;

namespace SteamChat
{
	public class SteamInterface
	{
		public SteamClient SteamClient { get; set; }
		public CallbackManager Manager { get; set; }

		private ManualResetEvent steamResetEvent;
		public ManualResetEvent SteamResetEvent { get { return this.steamResetEvent; } }

		private SteamUser steamUser;
		public SteamUser SteamUser { get { return this.steamUser; } }

		private bool isRunning;

		private SteamFriends steamFriends;
		public SteamFriends SteamFriends { get { return this.steamFriends; } }

		public SteamInterface()
		{
			this.steamResetEvent = new ManualResetEvent(false);

			this.SteamClient = new SteamClient();

			this.Manager = new CallbackManager(this.SteamClient);

			this.steamUser = SteamClient.GetHandler<SteamUser>();
			this.steamFriends = SteamClient.GetHandler<SteamFriends>();

			this.Manager.Subscribe<SteamUser.AccountInfoCallback>(this.OnAccountInfo);
		}
		public void run()
		{
			this.isRunning = true;
			while (this.isRunning)
			{
				Manager.RunWaitCallbacks(TimeSpan.FromSeconds(1));
			}
		}
		public void stop()
		{
			this.isRunning = false;
			this.SteamClient.Disconnect();
		}
		
		private void OnAccountInfo(SteamUser.AccountInfoCallback callback)
		{
			steamFriends.SetPersonaState(EPersonaState.Online);
		}
	}
}
