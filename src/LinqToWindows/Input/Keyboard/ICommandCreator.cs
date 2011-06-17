using System.Collections.Generic;

namespace Muyou.LinqToWindows.Input.Keyboard
{
    public interface ICommandCreator
    {
        IEnumerable<KeyboardInputCommand> Create(string sequence);
    }
}