﻿using System;
using System.Collections.Generic;
using Muyou.LinqToWindows.Menus;

namespace Muyou.LinqToWindows.Windows.Types
{
	public class ListBox : Window
	{
		public ListBox(IntPtr handle, string className, string text, IEnumerable<Window> childWindows, Menu menu)
			: base(handle, className, text, childWindows, menu)
		{
		}
	}
}