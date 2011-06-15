using System.Linq;
using Muyou.LinqToWindows.Input.Keyboard;
using Xunit;

namespace Muyou.LinqToWindows.Tests.Input.Keyboard
{
    public class DefaultCommandCreatorTests
    {
        [Fact]
        public void ShouldCreateOneKeypressCommand()
        {
            var creator = new DefaultCommandCreator();

            var commands = creator.Create("A");

            Assert.Equal(1, commands.Count());
            Assert.IsType<KeypressInputCommand>(commands.ElementAt(0));
        }

        [Fact]
        public void ShouldCreateSequenceOfKeypressCommandsIfSeparatedByComma()
        {
            var creator = new DefaultCommandCreator();

            var commands = creator.Create("A,B,C");

            Assert.Equal(3, commands.Count());
            Assert.IsType<KeypressInputCommand>(commands.ElementAt(0));
            Assert.IsType<KeypressInputCommand>(commands.ElementAt(1));
            Assert.IsType<KeypressInputCommand>(commands.ElementAt(2));
        }
    }
}