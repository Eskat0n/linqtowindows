namespace Muyou.LinqToWindows.Windows.NativeTypes
{
	/// <summary>
	/// System command values used in the WM_SYSCOMMAND notification
	/// </summary>
	internal enum Sc : uint
	{
		Size = 0xF000,
		Move = 0xF010,
		Minimize = 0xF020,
		Maximize = 0xF030,
		Nextwindow = 0xF040,
		Prevwindow = 0xF050,
		Close = 0xF060,
		Vscroll = 0xF070,
		Hscroll = 0xF080,
		Mousemenu = 0xF090,
		Keymenu = 0xF100,
		Arrange = 0xF110,
		Restore = 0xF120,
		Tasklist = 0xF130,
		Screensave = 0xF140,
		Hotkey = 0xF150,
	}
}