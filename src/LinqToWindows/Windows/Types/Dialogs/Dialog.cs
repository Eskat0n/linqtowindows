using System;
using System.Collections.Generic;
using Muyou.LinqToWindows.Menus;

namespace Muyou.LinqToWindows.Windows.Types.Dialogs
{
	public class Dialog : Window
	{
		public Dialog(IntPtr handle, string className, string text, IEnumerable<Window> childWindows, Menu menu)
			: base(handle, className, text, childWindows, menu)
		{
		}

		public TDialog Cast<TDialog>()
			where TDialog : Dialog
		{
			return (TDialog) Activator.CreateInstance(typeof (TDialog), Handle, ClassName, Text, ChildWindows, Menu);
		}
	}
}