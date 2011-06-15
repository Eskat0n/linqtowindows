using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Muyou.LinqToWindows.Extensibility;
using Muyou.LinqToWindows.Menus;
using Muyou.LinqToWindows.Windows;
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
				PressKey();

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

			printWindowButtons.PressViaPost();

			Thread.Sleep(1000);

        	var documentProperties = shell.Windows
        		.Where(x => x.Text.Contains("Document Properties"))
        		.SingleOrDefault();

        	var advancedTab = documentProperties.ChildWindows
        		.Where(x => x.Text.Contains("Advanced"))
        		.SingleOrDefault();
        }
    }
}
