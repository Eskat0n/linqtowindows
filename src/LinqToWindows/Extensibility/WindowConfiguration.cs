using System;

namespace Muyou.LinqToWindows.Extensibility
{
	public class WindowConfiguration : IEquatable<WindowConfiguration>
	{
		public WindowConfiguration(Type windowType, string className)
		{
			WindowType = windowType;
			ClassName = className;
		}

		public Type WindowType { get; private set; }
		public string ClassName { get; private set; }

		public bool Equals(WindowConfiguration other)
		{
			return ClassName.Equals(other.ClassName, StringComparison.InvariantCultureIgnoreCase) || WindowType == other.WindowType;
		}
	}
}