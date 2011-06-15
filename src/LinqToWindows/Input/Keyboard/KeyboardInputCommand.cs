using System.Collections.Generic;
using System.Linq;
using Muyou.LinqToWindows.Input.NativeTypes;

namespace Muyou.LinqToWindows.Input.Keyboard
{
    public abstract class KeyboardInputCommand : InputCommand
	{
        protected KeyboardInputCommand(ushort keyCode)
			: base(SendInputEventType.InputKeyboard)
        {
            Chunks = CreateInputData(keyCode)
                .Select(x => CreateInputDataChunk(keyboardInputData: x))
                .ToArray();
        }

        protected KeyboardInputCommand(VirtualKeyCodes virtualKeyCodes)
            : this((ushort) virtualKeyCodes)
        {
        }

        protected abstract IEnumerable<KeyboardInputData> CreateInputData(ushort virtualKeyCode);
	}
}