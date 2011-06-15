namespace Muyou.LinqToWindows.Input.NativeTypes
{
	/// <summary>
    /// The event type contained in the union field
    /// </summary>
	public enum SendInputEventType
	{
		/// <summary>
		/// Contains Mouse event data
		/// </summary>
		InputMouse,
		/// <summary>
		/// Contains Keyboard event data
		/// </summary>
		InputKeyboard,
		/// <summary>
		/// Contains Hardware event data
		/// </summary>
		InputHardware	
	}
}