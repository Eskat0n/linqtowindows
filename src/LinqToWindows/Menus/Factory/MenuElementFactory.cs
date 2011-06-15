using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Muyou.LinqToWindows.Menus.NativeTypes;

namespace Muyou.LinqToWindows.Menus.Factory
{
	internal class MenuElementFactory
	{
		internal IEnumerable<MenuElement> CreateMenuElements(IntPtr menuHandle)
		{
			var itemsCount = GetMenuItemCount(menuHandle);

			if (itemsCount != -1)
				for (uint i = 0; i < itemsCount; i++)
				{
					var id = GetMenuItemID(menuHandle, i);

					var menuItemInfo = new MenuItemInfo
					{
						cbSize = MenuItemInfo.SizeOf,
						fMask = Masks.MiimId | Masks.MiimString | Masks.MiimSubmenu,
						dwTypeData = new string(' ', 100),
						cch = 100
					};

					var result = GetMenuItemInfo(menuHandle, i, true, ref menuItemInfo);
					
					if (result)
						yield return id == -1
						             	? CreateSubMenuElement(menuHandle, menuItemInfo)
						             	: CreateMenuItemElement(menuHandle, menuItemInfo);
				}
		}

		private MenuElement CreateSubMenuElement(IntPtr menuHandle, MenuItemInfo info)
		{
			return new SubMenu(menuHandle, 0, info.dwTypeData, CreateMenuElements(info.hSubMenu));
		}

		private MenuElement CreateMenuItemElement(IntPtr menuHandle, MenuItemInfo info)
		{
			return new MenuItem(menuHandle, info.wID, info.dwTypeData);
		}

		[DllImport("user32.dll")]
		private static extern int GetMenuItemCount(IntPtr handle);

		[DllImport("user32.dll")]
		private static extern bool GetMenuItemInfo(IntPtr handle, uint uItem, bool fByPosition, ref MenuItemInfo lpmii);

		[DllImport("user32.dll")]
		private static extern int GetMenuItemID(IntPtr handle, uint itemPosition);

		[DllImport("user32.dll")]
		private static extern int GetMenuString(IntPtr handle, int itemId, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder text, int textMaxLength, uint flag);
	}
}