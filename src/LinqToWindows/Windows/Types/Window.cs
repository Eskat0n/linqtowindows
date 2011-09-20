using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Muyou.LinqToWindows.Extensions;
using Muyou.LinqToWindows.Input;
using Muyou.LinqToWindows.Input.Keyboard;
using Muyou.LinqToWindows.Menus;
using Muyou.LinqToWindows.Windows.NativeTypes;

namespace Muyou.LinqToWindows.Windows.Types
{
    public class Window
    {
    	private readonly DefaultCommandCreator _commandCreator;

    	protected readonly IntPtr Handle;		

    	public IEnumerable<Window> ChildWindows { get; private set; }
    	public Menu Menu { get; private set; }
    	public string ClassName { get; private set; }
        public string Text { get; protected set; }
		public InputMode InputMode { get; set; }		

        public Window(IntPtr handle, string className, string text, IEnumerable<Window> childWindows = null, Menu menu = null)
        {
            Handle = handle;
            ClassName = className;
            Text = text;
            ChildWindows = childWindows;
        	Menu = menu;
			InputMode = InputMode.Send;

			_commandCreator = new DefaultCommandCreator(handle);
        }

		public IntPtr WindowHandle { get { return Handle; } }

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
            SendMessage(Handle, (uint) Wm.SetText, IntPtr.Zero, text);
            Text = text;
        }

		public void Maximize()
		{
			SendMessage(Handle, (uint) Wm.Syscommand, (IntPtr) Sc.Maximize, IntPtr.Zero);
		}

		public void Minimize()
		{
			SendMessage(Handle, (uint) Wm.Syscommand, (IntPtr) Sc.Minimize, IntPtr.Zero);
		}

		public virtual void Close()
		{
			SendMessage(Handle, (uint) Wm.Close, IntPtr.Zero, IntPtr.Zero);
		}

		public void PushKey(string key)
		{
			_commandCreator.CreateKeydown(key).Execute(InputMode);
		}

		public void ReleaseKey(string key)
		{
			_commandCreator.CreateKeyup(key).Execute(InputMode);
		}

		public void PressKey(string sequence)
		{
			_commandCreator.Create(sequence).ForEach(x => x.Execute(InputMode));
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