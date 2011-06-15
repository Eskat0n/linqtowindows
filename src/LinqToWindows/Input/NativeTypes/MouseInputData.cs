using System;
using System.Runtime.InteropServices;

namespace Muyou.LinqToWindows.Input.NativeTypes
{
	/// <summary>
	/// The mouse data structure
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct MouseInputData
	{
		/// <summary>
		/// The x value, if ABSOLUTE is passed in the flag then this is an actual X and Y value
		/// otherwise it is a delta from the last position
		/// </summary>
		public int dx;
		/// <summary>
		/// The y value, if ABSOLUTE is passed in the flag then this is an actual X and Y value
		/// otherwise it is a delta from the last position
		/// </summary>
		public int dy;
		/// <summary>
		/// Wheel event data, X buttons
		/// </summary>
		public uint mouseData;
		/// <summary>
		/// ORable field with the various flags about buttons and nature of event
		/// </summary>
		public MouseEventFlags dwFlags;
		/// <summary>
		/// The timestamp for the event, if zero then the system will provide
		/// </summary>
		public uint time;
		/// <summary>
		/// Additional data obtained by calling app via GetMessageExtraInfo
		/// </summary>
		public IntPtr dwExtraInfo;
	}
}