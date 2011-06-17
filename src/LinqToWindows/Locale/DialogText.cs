using System;
using System.Globalization;

namespace Muyou.LinqToWindows.Locale
{
	public static class DialogText
	{
		private class EnDialogTextDictionary : IDialogTextDictionary
		{
			public string Open
			{
				get { return "Open"; }
			}

			public string Cancel
			{
				get { return "Cancel"; }
			}
		}
		
		private class RuDialogTextDictionary : IDialogTextDictionary
		{
			public string Open
			{
				get { return "Открыть"; }
			}

			public string Cancel
			{
				get { return "Отмена"; }
			}
		}

		public static IDialogTextDictionary Get()
		{
			return For();
		}

		public static IDialogTextDictionary For(string culture = null)
		{
			var targetCulture = culture ?? CultureInfo.InstalledUICulture.Name;

			switch (targetCulture)
			{
				case "en-US":
					return new EnDialogTextDictionary();
				case "ru-RU":
					return new RuDialogTextDictionary();
				default:
					throw new NotSupportedException();
			}
		}
	}
}