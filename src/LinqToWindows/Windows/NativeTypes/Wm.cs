namespace Muyou.LinqToWindows.Windows.NativeTypes
{
	/// <summary>
	/// WM_* Constants and their definitions or descriptions and what can cause them to be sent.
	/// </summary>
	internal enum Wm : uint
	{
		/// <summary>
		/// Text / Caption changed on the control. An application sends a WM_SETTEXT message to set the text of a window.
		/// </summary>
		SetText = 0x000C,

		/// <summary>
		/// The WM_CLOSE message is sent as a signal that a window or an application should terminate.
		/// </summary>
		Close = 0x0010,

		/// <summary>
		/// A window receives this message when the user chooses a command from the Window menu (formerly known as the system or control menu) 
		/// or when the user chooses the maximize button, minimize button, restore button, or close button.
		/// </summary>
		Syscommand = 0x0112,

		/// <summary>
		/// Posted to the window with the keyboard focus when a nonsystem key is pressed. A nonsystem key is a key that is pressed when the ALT 
		/// key is not pressed.
		/// </summary>
		Keydown = 0x0100,

		/// <summary>
		/// Posted to the window with the keyboard focus when a nonsystem key is released. A nonsystem key is a key that is pressed when the ALT 
		/// key is not pressed, or a keyboard key that is pressed when a window has the keyboard focus.
		/// </summary>
		Keyup = 0x0101,
	}
}