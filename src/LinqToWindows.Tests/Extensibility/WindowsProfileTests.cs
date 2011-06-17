using System;
using System.Collections.Generic;
using System.Linq;
using Muyou.LinqToWindows.Extensibility;
using Muyou.LinqToWindows.Menus;
using Muyou.LinqToWindows.Windows;
using Muyou.LinqToWindows.Windows.Types;
using Xunit;

namespace Muyou.LinqToWindows.Tests.Extensibility
{
	public class WindowsProfileTests
	{
		private class TestWindowOne : Window
		{
			public TestWindowOne(IntPtr handle, string className, string text, IEnumerable<Window> childWindows, Menu menu)
				: base(handle, className, text, childWindows, menu)
			{
			}
		}

		private class TestWindowTwo : Window
		{
			public TestWindowTwo(IntPtr handle, string className, string text, IEnumerable<Window> childWindows, Menu menu)
				: base(handle, className, text, childWindows, menu)
			{
			}
		}

		private class TestProfile : WindowsProfile
		{
			public TestProfile()
			{
				RegisterWindowType<TestWindowOne>("TestClass");
			}
		}

		private class TestDublicatedClassNameProfile : WindowsProfile
		{
			public TestDublicatedClassNameProfile()
			{
				RegisterWindowType<TestWindowOne>("TestClass1");

				RegisterWindowType<TestWindowTwo>("TestClass1");
			}
		}

		private class TestDublicatedWindowTypeProfile : WindowsProfile
		{
			public TestDublicatedWindowTypeProfile()
			{
				RegisterWindowType<TestWindowOne>("TestClass1");

				RegisterWindowType<TestWindowOne>("TestClass2");
			}
		}

		[Fact]
		public void TestProfileConfigurationsShouldContainsConfigurationSpecifiedInConstructor()
		{
			var profile = new TestProfile();

			Assert.Equal(1, profile.Configurations.Count());
			Assert.Equal(typeof(TestWindowOne), profile.Configurations.Single().WindowType);
			Assert.Equal("TestClass", profile.Configurations.Single().ClassName);
		}

		[Fact]
		public void TestProfileCanNotAddDublicateClassNameConfigurations()
		{
			var profile = new TestDublicatedClassNameProfile();

			Assert.Equal(1, profile.Configurations.Count());
		}

		[Fact]
		public void FactMethodName()
		{
			var profile = new TestDublicatedWindowTypeProfile();

			Assert.Equal(1, profile.Configurations.Count());
		}
	}
}