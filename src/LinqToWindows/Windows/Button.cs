using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Muyou.LinqToWindows.Menus;

namespace Muyou.LinqToWindows.Windows
{
    public sealed class Button : Window
    {
        public Button(IntPtr handle, string className, string text, IEnumerable<Window> childWindows, Menu menu)
            : base(handle, className, text, childWindows)
        {
            Text = Text.Replace("&", string.Empty);
        }

        public void Press()
        {
            SendMessage(Handle, BmClick, IntPtr.Zero, IntPtr.Zero);
        }

		public void PressViaPost()
		{
			PostMessage(Handle, BmClick, IntPtr.Zero, IntPtr.Zero);
		}

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr windowHandle, uint messageCode, IntPtr wParam, IntPtr lParam);

		[return: MarshalAs(UnmanagedType.Bool)]
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool PostMessage(IntPtr windowHandle, uint messageCode, IntPtr wParam, IntPtr lParam);
    }
}