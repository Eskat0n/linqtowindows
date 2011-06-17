using System.Linq;

namespace Muyou.LinqToWindows.Extensions
{
	public static class CharExtensions
	{
		public static bool IsInRange(this char @char, char lower, char upper)
		{
			return @char >= lower && @char <= upper;
		}

		public static bool IsOneOf(this char @char, params char[] chars)
		{
			return chars.Any(@char.Equals);
		}
	}
}