using System;

namespace Muyou.LinqToWindows.Extensibility
{
	public class WindowConfiguration
	{
		public WindowConfiguration(Type windowType, string className)
		{
			WindowType = windowType;
			ClassName = className;
		}

		public Type WindowType { get; private set; }
		public string ClassName { get; private set; }
	}
}