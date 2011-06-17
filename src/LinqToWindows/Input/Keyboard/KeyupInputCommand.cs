using System.Collections.Generic;
using Muyou.LinqToWindows.Input.NativeTypes;

namespace Muyou.LinqToWindows.Input.Keyboard
{
	public class KeyupInputCommand : KeyboardInputCommand
	{
		public KeyupInputCommand(ushort keyCode) 
			: base(keyCode)
		{
		}

		protected override IEnumerable<KeyboardInputData> CreateInputData(ushort virtualKeyCode)
		{
			yield return new KeyboardInputData
			             	{
			             		wScan = 0,
			             		time = 0,
			             		dwFlags = (uint) KeyboardEventFlags.KEYEVENTF_KEYUP,
			             		wVk = virtualKeyCode
			             	};
		}
	}
}