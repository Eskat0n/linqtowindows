using System;

namespace Muyou.LinqToWindows.Menus
{
	public class MenuItem : MenuElement
	{
		public MenuItem(IntPtr root, int id, string text)
			: base(root, id, text)
		{
		}
	}
}