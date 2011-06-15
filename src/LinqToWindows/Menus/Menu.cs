using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Muyou.LinqToWindows.Menus.Factory;
using Muyou.LinqToWindows.Menus.NativeTypes;

namespace Muyou.LinqToWindows.Menus
{
	public sealed class Menu : MenuBase
	{
		public IEnumerable<MenuElement> Items { get; private set; }

		public Menu(IntPtr handle)
			: base(handle)
		{
			var factory = new MenuElementFactory();

			Items = factory.CreateMenuElements(Handle);

//			var subMenus = GetSubMenus();
//			if (subMenus != null)
//				foreach (var subMenu in subMenus)
//					_items.Add(subMenu);
		}

		public IEnumerable<string> GetMenuInfos()
		{
			var itemsCount = GetMenuItemCount();

			if (itemsCount != -1)
				for (uint i = 0; i < itemsCount; i++)
				{
					var menuItemInfo = new MenuItemInfo
					                   	{
					                   		cbSize = MenuItemInfo.SizeOf,
					                   		fMask = Masks.MiimId | Masks.MiimString,
					                   		dwTypeData = new string(' ', 100),
					                   		cch = 100
					                   	};

					var result = GetMenuItemInfo(Handle, i, true, ref menuItemInfo);

					if (result)
						yield return menuItemInfo.dwTypeData;
				}
		}

		[DllImport("user32.dll")]
		private static extern IntPtr GetSubMenu(IntPtr handle, uint nPos);

		[DllImport("user32.dll")]
		private static extern bool GetMenuItemInfo(IntPtr handle, uint uItem, bool fByPosition, ref MenuItemInfo lpmii);
	}
}