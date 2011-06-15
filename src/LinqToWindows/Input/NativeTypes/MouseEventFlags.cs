using System;

namespace Muyou.LinqToWindows.Input.NativeTypes
{
	/// <summary>
	/// The flags that a MouseInputData.dwFlags can contain
	/// </summary>
	[Flags]
	public enum MouseEventFlags : uint
	{
		/// <summary>
		/// Movement occured
		/// </summary>
		MOUSEEVENTF_MOVE = 0x0001,
		/// <summary>
		/// button down (pair with an up to create a full click)
		/// </summary>
		MOUSEEVENTF_LEFTDOWN = 0x0002,
		/// <summary>
		/// button up (pair with a down to create a full click)
		/// </summary>
		MOUSEEVENTF_LEFTUP = 0x0004,
		/// <summary>
		/// button down (pair with an up to create a full click)
		/// </summary>
		MOUSEEVENTF_RIGHTDOWN = 0x0008,
		/// <summary>
		/// button up (pair with a down to create a full click)
		/// </summary>
		MOUSEEVENTF_RIGHTUP = 0x0010,
		/// <summary>
		/// button down (pair with an up to create a full click)
		/// </summary>
		MOUSEEVENTF_MIDDLEDOWN = 0x0020,
		/// <summary>
		/// button up (pair with a down to create a full click)
		/// </summary>
		MOUSEEVENTF_MIDDLEUP = 0x0040,
		/// <summary>
		/// button down (pair with an up to create a full click)
		/// </summary>
		MOUSEEVENTF_XDOWN = 0x0080,
		/// <summary>
		/// button up (pair with a down to create a full click)
		/// </summary>
		MOUSEEVENTF_XUP = 0x0100,
		/// <summary>
		/// Wheel was moved, the value of mouseData is the number of movement values
		/// </summary>
		MOUSEEVENTF_WHEEL = 0x0800,
		/// <summary>
		/// Map X,Y to entire desktop, must be used with MOUSEEVENT_ABSOLUTE
		/// </summary>
		MOUSEEVENTF_VIRTUALDESK = 0x4000,
		/// <summary>
		/// The X and Y members contain normalised Absolute Co-Ords. If not set X and Y are relative
		/// data to the last position (i.e. change in position from last event)
		/// </summary>
		MOUSEEVENTF_ABSOLUTE = 0x8000
	}
}