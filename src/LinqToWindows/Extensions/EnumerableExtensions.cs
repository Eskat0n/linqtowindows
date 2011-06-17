using System;
using System.Collections.Generic;

namespace Muyou.LinqToWindows.Extensions
{
	public static class EnumerableExtensions
	{
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
		{
			foreach (var element in enumerable)
				action.Invoke(element);

			return enumerable;
		}
	}
}