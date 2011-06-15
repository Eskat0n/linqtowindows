using System.Collections.Generic;
using Muyou.LinqToWindows.Input.NativeTypes;

namespace Muyou.LinqToWindows.Input.Keyboard
{
    public class KeypressInputCommand : KeyboardInputCommand
    {
        public KeypressInputCommand(ushort keyCode)
            : base(keyCode)
        {
        }

        public KeypressInputCommand(VirtualKeyCodes virtualKeyCodes)
            : base(virtualKeyCodes)
        {
        }

        protected override IEnumerable<KeyboardInputData> CreateInputData(ushort virtualKeyCode)
        {
            return new[]
                       {
                           new KeyboardInputData
                               {
                                   wScan = 0,
                                   time = 0,
                                   dwFlags = 0,
                                   wVk = virtualKeyCode
                               },
                           new KeyboardInputData
                               {
                                   wScan = 0,
                                   time = 0,
                                   dwFlags = (uint) KeyboardEventFlags.KEYEVENTF_KEYUP,
                                   wVk = virtualKeyCode
                               }
                       };
        }
    }
}