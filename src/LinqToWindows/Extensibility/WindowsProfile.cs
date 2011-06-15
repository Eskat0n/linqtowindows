using System;
using System.Collections.Generic;
using System.Linq;
using Muyou.LinqToWindows.Windows;

namespace Muyou.LinqToWindows.Extensibility
{
	public abstract class WindowsProfile
	{
		private readonly ICollection<WindowConfiguration> _configurations = new List<WindowConfiguration>();

		public IEnumerable<WindowConfiguration> Configurations 
		{
			get { return _configurations; }
		}

		protected void RegisterWindowType<TWindow>(string className)
			where TWindow : Window
		{
			var windowConfiguration = new WindowConfiguration(typeof(TWindow), className);

			if (string.IsNullOrEmpty(className) == false && _configurations.Any(x => IsConfigurationsSimilar(x, windowConfiguration)) == false)
				_configurations.Add(windowConfiguration);
		}

		private bool IsConfigurationsSimilar(WindowConfiguration x, WindowConfiguration y)
		{
			return x.ClassName.Equals(y.ClassName, StringComparison.InvariantCultureIgnoreCase) || x.WindowType == y.WindowType;
		}
	}
}