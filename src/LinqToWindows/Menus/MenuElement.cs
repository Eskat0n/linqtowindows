using System;

namespace Muyou.LinqToWindows.Menus
{
	public abstract class MenuElement : MenuBase
	{
		protected readonly IntPtr Root;
		protected readonly int Id;

		public string Text { get; private set; }
		public string ClearText { get; private set; }

		protected MenuElement(IntPtr root, int id, string text)
			: base(root)
		{
			Root = root;
			Id = id;
			Text = text;
			ClearText = Text.Replace("&", string.Empty);
		}
	}
}