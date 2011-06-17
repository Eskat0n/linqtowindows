using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Muyou.LinqToWindows.Extensions;
using Muyou.LinqToWindows.Input.Keyboard;
using Muyou.LinqToWindows.Menus;
using Muyou.LinqToWindows.Windows.NativeTypes;

namespace Muyou.LinqToWindows.Windows.Types
{
    public class Window
    {
    	private readonly DefaultCommandCreator _commandCreator = new DefaultCommandCreator();

    	protected readonly IntPtr Handle;

    	public IEnumerable<Window> ChildWindows { get; private set; }
    	public Menu Menu { get; private set; }
    	public string ClassName { get; private set; }
        public string Text { get; protected set; }

        public Window(IntPtr handle, string className, string text, IEnumerable<Window> childWindows = null, Menu menu = null)
        {
            Handle = handle;
            ClassName = className;
            Text = text;
            ChildWindows = childWindows;
        	Menu = menu;
        }

    	public bool SetFocus()
    	{
    		return SetFocus(Handle) != IntPtr.Zero;
    	}

		public void SetActive()
		{
			if (GetActiveWindow() != Handle)
				SetActiveWindow(Handle);
		}

		public void SetForeground()
		{
			if (GetForegroundWindow() != Handle)
				SetForegroundWindow(Handle);
		}

    	public void SetText(string text)
        {
            SendMessage(Handle, WindowMessages.SetText, IntPtr.Zero, text);
            Text = text;
        }

		public void Close()
		{
			SendMessage(Handle, WindowMessages.Close, IntPtr.Zero, IntPtr.Zero);
		}

		public void PushKey(string key)
		{
			SetForeground();
			_commandCreator.CreateKeydown(key).Execute();
		}

		public void ReleaseKey(string key)
		{
			SetForeground();
			_commandCreator.CreateKeyup(key).Execute();
		}

		public void PressKey(string sequence)
		{
			SetForeground();
			_commandCreator.Create(sequence).ForEach(x => x.Execute());
		}

    	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint messageCode, IntPtr wParam, string lParam);
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
		private static extern IntPtr SendMessage(IntPtr hWnd, uint messageCode, IntPtr wParam, IntPtr lParam);

    	[DllImport("user32.dll")]
		private static extern IntPtr GetFocus();
		[DllImport("user32.dll")]
		private static extern IntPtr SetFocus(IntPtr hWnd);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr GetActiveWindow();
		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr SetActiveWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}