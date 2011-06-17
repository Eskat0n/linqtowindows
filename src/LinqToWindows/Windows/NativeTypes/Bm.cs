namespace Muyou.LinqToWindows.Windows.NativeTypes
{
	/// <summary>
	/// Button Messages
	/// </summary>
	internal enum Bm : uint
	{
		/// <summary>
		/// Simulates the user clicking a button. This message causes the button to receive the WM_LBUTTONDOWN and WM_LBUTTONUP messages, 
		/// and the button's parent window to receive a BN_CLICKED notification code.
		/// </summary>
		Click = 0x00F5,
	}
}