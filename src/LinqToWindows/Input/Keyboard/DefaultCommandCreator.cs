using System;
using System.Collections.Generic;
using Muyou.LinqToWindows.Extensions;
using Muyou.LinqToWindows.Input.Keyboard.Exceptions;

namespace Muyou.LinqToWindows.Input.Keyboard
{
	public class DefaultCommandCreator : ICommandCreator
	{
		private static readonly IDictionary<string, ushort> KeyDescriptions
			= new Dictionary<string, ushort>
			  	{
			  		{"SHIFT", 0xA0},
			  		{"LSHIFT", 0xA0},
			  		{"RSHIFT", 0xA1},

			  		{"CTRL", 0xA2},
			  		{"LCTRL", 0xA2},
			  		{"RCTRL", 0xA3},

			  		{"MENU", 0xA4},
			  		{"LMENU", 0xA4},
			  		{"RMENU", 0xA5},

			  		{"ENTER", 0x0D},
			  		{"SPACE", 0x20},

			  		{"F1", 0x70},
			  		{"F2", 0x71},
			  		{"F3", 0x72},
			  		{"F4", 0x73},
			  		{"F5", 0x74},
			  		{"F6", 0x75},
			  		{"F7", 0x76},
			  		{"F8", 0x77},
			  		{"F9", 0x78},
			  		{"F10", 0x79},
			  		{"F11", 0x7A},
			  		{"F12", 0x7B},

			  		{";", 0xBA},
			  		{"=", 0xBB},
			  		{"\\,", 0xBC},
			  		{"-", 0xBD},
			  		{".", 0xBE},
			  		{"/", 0xBF},
			  		{"`", 0xC0},
			  		{"[", 0xDB},
			  		{"\\", 0xDC},
			  		{"]", 0xDD},
			  		{"'", 0xDE},
			  	};

		public IEnumerable<KeyboardInputCommand> Create(string sequence)
		{
			var keySequence = sequence.ToUpperInvariant().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

			foreach (var key in keySequence)
			{
				if (key.Contains("+") == false)
					yield return new KeypressInputCommand(GetKeyCode(key));
				else
				{
					var chordKeys = key.Split(new[] {'+'}, StringSplitOptions.RemoveEmptyEntries);

					if (chordKeys.Length > 2)
						throw new KeyChordIsTooLongException(key);
					if (chordKeys.Length != 2)
						throw new MalformedKeyChordException(key);

					yield return new KeydownInputCommand(GetKeyCode(chordKeys[0]));
					yield return new KeypressInputCommand(GetKeyCode(chordKeys[1]));
					yield return new KeyupInputCommand(GetKeyCode(chordKeys[2]));
				}
			}
		}

		private static ushort GetKeyCode(string key)
		{
			if (key.Length == 1 && (key[0].IsInRange('A', 'Z') || key[0].IsInRange('0', '9')))
				return key[0];
			if (KeyDescriptions.ContainsKey(key))
				return KeyDescriptions[key];

			throw new ArgumentOutOfRangeException("key", "Unrecognized key");
		}

		public KeyboardInputCommand CreateKeydown(string key)
		{
			return new KeydownInputCommand(GetKeyCode(key.ToUpperInvariant()));
		}
		
		public KeyboardInputCommand CreateKeyup(string key)
		{
			return new KeyupInputCommand(GetKeyCode(key.ToUpperInvariant()));
		}
	}
}