using System;

namespace Muyou.LinqToWindows.Input.Keyboard.Exceptions
{
	public class MalformedKeyChordException : Exception
	{
		public MalformedKeyChordException(string keyChord)
			: base(string.Format("The following key chord is malformed or too short: {0}", keyChord))
		{
		}
	}
}