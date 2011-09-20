using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Muyou.LinqToWindows.Extensibility;
using Muyou.LinqToWindows.Input;
using Muyou.LinqToWindows.Menus;
using Muyou.LinqToWindows.Windows.Types;
using Muyou.LinqToWindows.Windows.Types.Dialogs;
using Xunit;

namespace Muyou.LinqToWindows.Tests
{
	public class Tests
    {
		private class AdobeWindow : Window
		{
			public AdobeWindow(IntPtr handle, string className, string text, IEnumerable<Window> childWindows, Menu menu)
				: base(handle, className, text, childWindows, menu)
			{
			}

			public void OpenPrint()
			{
				SetForeground();
				PressKey("Ctrl+P");

				Thread.Sleep(1000);
			}
		}

		private class TestProfile : WindowsProfile
		{
			public TestProfile()
			{
				RegisterWindowType<AdobeWindow>("AcrobatSDIWindow");
			}
		}

        [Fact]
        public void SomeTest()
        {
            var shell = new Shell(new TestProfile());

        	var adobeWindow = shell.Windows
        		.OfType<AdobeWindow>()
        		.Single();

        	adobeWindow.OpenPrint();

			var printWindow = shell.Windows
				.Where(x => x.Text == "Print")
				.SingleOrDefault();

        	var printWindowButtons = printWindow.ChildWindows
        		.OfType<Button>()
        		.Where(x => x.Text == "Properties")
				.SingleOrDefault();

			printWindowButtons.PressByPost();

			Thread.Sleep(1000);

        	var documentProperties = shell.Windows
        		.Where(x => x.Text.Contains("Document Properties"))
        		.SingleOrDefault();

        	var advancedTab = documentProperties.ChildWindows
        		.Where(x => x.Text.Contains("Advanced"))
        		.SingleOrDefault();
        }

		[Fact]
		public void FactMethodName()
		{
			var shell = new Shell();

			var openDialog = shell.Windows
				.OfType<Dialog>()
				.Where(x => x.Text.Contains("Open"))
				.SingleOrDefault()
				.Cast<OpenFileDialog>();

			openDialog.SelectFile(@"D:\fileToUpload.jpg");
		}

		[Fact]
		public void CanSendKeysToBrowser()
		{
			var shell = new Shell();

			var browserWindow = shell.Windows
				.Where(x => x.Text.Contains("muyou"))
				.SingleOrDefault();

			browserWindow.PressKey("Enter");
		}

		[Fact]
		public void FactMethodName1()
		{
			var shell = new Shell();

			var notepad = shell.Windows
				.Where(x => x.Text.Contains("Notepad"))
				.SingleOrDefault();

			notepad.PressKey("+ ` 1 . 0 1 2 3 4 5 6 7 8 9");
		}

		[Fact]
		public void FactMethodName3()
		{
			var shell = new Shell();

			var notepad = shell.Windows
				.Where(x => x.Text.Contains("Notepad"))
				.SingleOrDefault();

			notepad.Minimize();
			notepad.Maximize();
		}
		
		[Fact]
		public void FactMethodName4()
		{
			var shell = new Shell();

			var notepad = shell.Windows
				.Where(x => x.Text.Contains("Notepad"))
				.SingleOrDefault();

			notepad.InputMode = InputMode.Post;
			notepad.PressKey("F5");
		}
    }
}
