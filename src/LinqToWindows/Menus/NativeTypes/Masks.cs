namespace Muyou.LinqToWindows.Menus.NativeTypes
{
	internal class Masks
	{
		/// <summary>
		/// Retrieves or sets the hbmpItem member
		/// </summary>
		public const uint MiimBitmap = 0x00000080;

		/// <summary>
		/// Retrieves or sets the hbmpChecked and hbmpUnchecked members
		/// </summary>
		public const uint MiimCheckmarks = 0x00000008;

		/// <summary>
		/// Retrieves or sets the dwItemData member.
		/// </summary>
		public const uint MiimData = 0x00000020;

		/// <summary>
		/// Retrieves or sets the fType member.
		/// </summary>
		public const uint MiimFtype = 0x00000100;

		/// <summary>
		/// Retrieves or sets the wID member.
		/// </summary>
		public const uint MiimId = 0x00000002;

		/// <summary>
		/// Retrieves or sets the fState member.
		/// </summary>
		public const uint MiimState = 0x00000001;

		/// <summary>
		/// Retrieves or sets the dwTypeData member.
		/// </summary>
		public const uint MiimString = 0x00000040;

		/// <summary>
		/// Retrieves or sets the hSubMenu member.
		/// </summary>
		public const uint MiimSubmenu = 0x00000004;

		/// <summary>
		/// Retrieves or sets the fType and dwTypeData members.
		/// MIIM_TYPE is replaced by MIIM_BITMAP, MIIM_FTYPE, and MIIM_STRING.
		/// </summary>
		public const uint MiimType = 0x00000010;
	}
}