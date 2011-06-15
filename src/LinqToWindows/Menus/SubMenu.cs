using System;
using System.Collections.Generic;

namespace Muyou.LinqToWindows.Menus
{
	public sealed class SubMenu : MenuElement
	{
		public IEnumerable<MenuElement> Items { get; private set; }

		public SubMenu(IntPtr root, int id, string text, IEnumerable<MenuElement> items)
			: base(root, id, text)
		{
			Items = items;
		}
	}
}