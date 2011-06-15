using System;
using System.Collections.Generic;
using Muyou.LinqToWindows.Menus;

namespace Muyou.LinqToWindows.Windows
{
    public sealed class Edit : Window
    {
        public Edit(IntPtr handle, string className, string text, IEnumerable<Window> childWindows, Menu menu)
            : base(handle, className, text, childWindows)
        {
        }
    }
}