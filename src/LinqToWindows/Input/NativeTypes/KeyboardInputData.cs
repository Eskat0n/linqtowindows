using System;
using System.Runtime.InteropServices;

namespace Muyou.LinqToWindows.Input.NativeTypes
{
	[StructLayout(LayoutKind.Sequential)]
	public struct KeyboardInputData
	{
		public ushort wVk;
		public ushort wScan;
		public uint dwFlags;
		public uint time;
		public IntPtr dwExtraInfo;
	}
}