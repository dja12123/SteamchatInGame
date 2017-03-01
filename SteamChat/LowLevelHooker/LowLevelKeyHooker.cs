using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SteamChat
{
	class LowLevelKeyHooker
	{
		//WindowHook
		public delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

		[DllImport("user32.dll")]
		public static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

		//KeyBoardHook
		private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
		[DllImport("user32.dll")]
		static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);
		[DllImport("user32.dll")]
		static extern bool UnhookWindowsHookEx(IntPtr hInstance);
		[DllImport("user32.dll")]
		static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);
		[DllImport("user32.dll")]
		public static extern int MapVirtualKey(int wCode, int wMapType);
		[DllImport("kernel32.dll")]
		static extern IntPtr LoadLibrary(string lpFileName);
		const int WH_KEYBOARD_LL = 13;
		const int WM_KEYDOWN = 0x100;

		public delegate void KeyEventListener(int keyCode);
		public static KeyEventListener KeyBoardHook { get; set; }

		private static LowLevelKeyboardProc _proc = hookProc;

		private static IntPtr hhook = IntPtr.Zero;

		private LowLevelKeyHooker() { }
		public static void SetHook()
		{
			IntPtr hInstance = LoadLibrary("User32");
			hhook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hInstance, 0);
		}
		public static void UnHook()
		{
			UnhookWindowsHookEx(hhook);
		}
		private static IntPtr hookProc(int code, IntPtr wParam, IntPtr lParam)
		{
			if (KeyBoardHook != null && code >= 0 && wParam == (IntPtr)WM_KEYDOWN)
			{
				int vkCode = Marshal.ReadInt32(lParam);
				KeyBoardHook(vkCode);
			}
			return CallNextHookEx(hhook, code, (int)wParam, lParam);
		}

	}
}
