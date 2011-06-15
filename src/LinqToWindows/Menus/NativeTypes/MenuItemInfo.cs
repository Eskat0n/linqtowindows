using System;
using System.Runtime.InteropServices;

namespace Muyou.LinqToWindows.Menus.NativeTypes
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct MenuItemInfo
	{
		public uint cbSize;
		public uint fMask;
		public uint fType;
		public uint fState;
		public int wID;
		public IntPtr hSubMenu;
		public int hbmpChecked;
		public int hbmpUnchecked;
		public int dwItemData;
		public string dwTypeData;
		public uint cch;
		public int hbmpItem;		

		public static uint SizeOf
		{
			get { return (uint) Marshal.SizeOf(typeof (MenuItemInfo)); }
		}
	}
}