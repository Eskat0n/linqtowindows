using System;
using System.Collections.Generic;
using System.Linq;
using Muyou.LinqToWindows.Input.NativeTypes;
using Muyou.LinqToWindows.Windows.NativeTypes;

namespace Muyou.LinqToWindows.Input.Keyboard
{
    public abstract class KeyboardInputCommand : InputCommand
	{
    	protected KeyboardInputCommand(IntPtr handle, ushort keyCode)
			: base(handle, SendInputEventType.InputKeyboard)
		{
			Chunks = CreateInputData(keyCode)
                .Select(x => CreateInputDataChunk(keyboardInputData: x))
                .ToArray();
		}

    	protected abstract IEnumerable<KeyboardInputData> CreateInputData(ushort virtualKeyCode);

    	protected override void ExecutePost()
    	{
    		foreach (var inputDataChunk in Chunks)
    		{
    			var chunk = inputDataChunk;

    			uint? message;
				switch (chunk.InputData.KeyboardInputData.dwFlags)
				{
					case 0:
						message = (uint) Wm.Keydown;
						break;
					case (uint)KeyboardEventFlags.KEYEVENTF_KEYUP:
						message = (uint) Wm.Keyup;
						break;
					default:
						message = null;
						break;
				}

				if (message.HasValue == false)
					throw new NotSupportedException("Unrecognized message type");

    			PostMessage(Handle, message.Value, chunk.InputData.KeyboardInputData.wVk, 5);
    		}
    	}
	}
}