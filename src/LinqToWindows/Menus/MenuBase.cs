using System;
using System.Runtime.InteropServices;

namespace Muyou.LinqToWindows.Menus
{
	public class MenuBase
	{
		protected IntPtr Handle;

		public MenuBase(IntPtr handle)
		{
			Handle = handle;
		}

		protected int GetMenuItemCount()
		{
			return GetMenuItemCount(Handle);
		}

		[DllImport("user32.dll")]
		private static extern int GetMenuItemCount(IntPtr handle);
	}
}