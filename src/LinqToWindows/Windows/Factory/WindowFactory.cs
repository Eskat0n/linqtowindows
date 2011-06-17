using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Muyou.LinqToWindows.Extensibility;
using Muyou.LinqToWindows.Menus;
using Muyou.LinqToWindows.Windows.Types;
using Muyou.LinqToWindows.Windows.Types.Dialogs;

namespace Muyou.LinqToWindows.Windows.Factory
{
	internal class WindowFactory
    {
        private readonly Dictionary<string, Type> _windowClassTypes
            = new Dictionary<string, Type>
                                    {
                                        {"#32770", typeof(Dialog)},
										{"Button", typeof(Button)},
										{"ComboBox", typeof(ComboBox)},
                                        {"Edit", typeof(Edit)},                                        										
										{"ListBox", typeof(ListBox)},
										{"ScrollBar", typeof(ScrollBar)},
										{"Static", typeof(Static)}
                                    };

    	internal WindowFactory()
    	{
    	}

    	internal WindowFactory(WindowsProfile profile)
    	{
    		var newConfigurations = profile.Configurations
    			.Where(x => _windowClassTypes.ContainsKey(x.ClassName) == false);

    		foreach (var configuration in newConfigurations)
    			_windowClassTypes.Add(configuration.ClassName, configuration.WindowType);
    	}

		internal Window CreateWindow(IntPtr handle, IEnumerable<Window> childWindows = null)
        {
            var buffer = new StringBuilder(1024);

            GetClassName(handle, buffer, buffer.Capacity);
            var className = buffer.ToString();

            buffer = new StringBuilder(1024);

            GetWindowText(handle, buffer, buffer.Capacity);
            var text = buffer.ToString();

    		var menu = new Menu(GetMenu(handle));
			
    		return _windowClassTypes.ContainsKey(className)
                       ? (Window) Activator.CreateInstance(_windowClassTypes[className], handle, className, text, childWindows, menu)
                       : new Window(handle, className, text, childWindows, menu);
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		[DllImport("user32.dll")]
		private static extern IntPtr GetMenu(IntPtr hWnd);
    }
}