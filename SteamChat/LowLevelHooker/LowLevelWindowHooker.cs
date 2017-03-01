using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamChat
{
	public class LowLevelWindowHooker : IDisposable
	{

		public delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType,
			IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public RECT(int left, int top, int right, int buttom)
			{
				this.Left = left;
				this.Top = top;
				this.Right = right;
				this.Bottom = buttom;
			}
			public int Left, Top, Right, Bottom;
		}
		[DllImport("user32.dll")]
		private static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr
		   hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess,
		   uint idThread, uint dwFlags);
		[DllImport("user32.dll")]
		public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);
		[DllImport("user32.dll")]
		private static extern bool UnhookWinEvent(IntPtr hWinEventHook);
		[DllImport("user32.dll")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);
		[DllImport("user32.dll")]
		public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);
		[DllImport("user32.dll")]
		public static extern IntPtr GetForegroundWindow();
		[DllImport("user32.dll")]
		public static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);
		[DllImport("kernel32.dll")]
		public static extern uint GetCurrentThreadId();

		private IntPtr listener;
		//public WinEventDelegate WindowHook { get; set; }
		private WinEventDelegate hook;
		public LowLevelWindowHooker(Process process, uint eventMin, uint eventMax, WinEventDelegate hook)
		{
			this.hook = hook;
			this.listener = SetWinEventHook(eventMin, eventMax, IntPtr.Zero,
					hook, (uint)process.Id, 0, 0);
		}
		public void Dispose()
		{
			UnhookWinEvent(this.listener);
		}
	
	}
}
