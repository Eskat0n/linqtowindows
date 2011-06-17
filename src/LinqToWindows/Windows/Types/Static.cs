﻿using System;
using System.Collections.Generic;
using Muyou.LinqToWindows.Menus;

namespace Muyou.LinqToWindows.Windows.Types
{
	public class Static : Window
	{
		public Static(IntPtr handle, string className, string text, IEnumerable<Window> childWindows, Menu menu)
			: base(handle, className, text, childWindows, menu)
		{
		}
	}
}