using System;

namespace Muyou.LinqToWindows.Input.Keyboard.Exceptions
{
	public class KeyChordIsTooLongException : Exception
	{
		public KeyChordIsTooLongException(string keyChord)
			: base(string.Format("The following key chord is too long: {0}", keyChord))
		{
		}
	}
}