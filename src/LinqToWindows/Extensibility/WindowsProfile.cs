using System.Collections.Generic;
using System.Linq;
using Muyou.LinqToWindows.Windows;
using Muyou.LinqToWindows.Windows.Types;

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

			if ((string.IsNullOrEmpty(className) || _configurations.Any(x => x.Equals(windowConfiguration))) == false)
				_configurations.Add(windowConfiguration);
		}
	}
}