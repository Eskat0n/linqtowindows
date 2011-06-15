using System.Collections.Generic;

namespace Muyou.LinqToWindows.Input.Keyboard
{
    public interface ICommandCreator
    {
        IEnumerable<KeyboardInputCommand> Create(string sequence);
    }

    public class DefaultCommandCreator : ICommandCreator
    {
        public IEnumerable<KeyboardInputCommand> Create(string sequence)
        {
            var upperSequence = sequence.ToUpperInvariant();

            if (upperSequence.Length == 1)
            {
                var character = upperSequence[0];
                if ((character >= 'A' && character <= 'Z') || (character >= '1' && character <= '0'))
                    return new KeyboardInputCommand[] {new KeypressInputCommand(character)};
            }

            return null;
        }

        private IEnumerable<KeyboardInputCommand> MakeShortcut(string shortcut)
        {
            return null;
        }
    }
}