using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Muyou.LinqToWindows.Extensibility;
using Muyou.LinqToWindows.Windows;
using Muyou.LinqToWindows.Windows.Factory;

namespace Muyou.LinqToWindows
{
    public sealed class Shell
    {
        private delegate bool Win32Callback(IntPtr handle, IntPtr lParam);

    	private readonly WindowFactory _windowFactory;
        private ICollection<Window> _windows;
        private ICollection<Window> _childWindows;

        public IEnumerable<Window> Windows { get { return EnumerateWindows(); } }

    	public Shell()
    	{
			_windowFactory = new WindowFactory();
    	}

    	public Shell(WindowsProfile profile)
    	{
			_windowFactory = new WindowFactory(profile);
    	}

    	private IEnumerable<Window> EnumerateWindows()
        {
            _windows = new List<Window>();
            EnumWindows(EnumerationCallback, IntPtr.Zero);

            return _windows;
        }

        private bool EnumerationCallback(IntPtr handle, IntPtr lparam)
        {
            _childWindows = new List<Window>();
            EnumChildWindows(handle, ChildEnumerationCallback, IntPtr.Zero);

            _windows.Add(_windowFactory.CreateWindow(handle, _childWindows));

            return true;
        }

        private bool ChildEnumerationCallback(IntPtr handle, IntPtr lparam)
        {
            _childWindows.Add(_windowFactory.CreateWindow(handle));

            return true;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumWindows(Win32Callback callback, IntPtr lParam);

        [DllImport("user32.Dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr parentHandle, Win32Callback callback, IntPtr lParam);
    }
}
