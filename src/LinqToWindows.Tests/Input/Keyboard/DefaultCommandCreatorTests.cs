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

            var commands = creator.Create("A B C");

            Assert.Equal(3, commands.Count());
        	Assert.Equal(3, commands.OfType<KeypressInputCommand>().Count());
        }

    	[Fact]
    	public void ShouldCreateSequenceOfKeypressCommandsFromDifferentKeys()
    	{
			var creator = new DefaultCommandCreator();

			var commands = creator.Create("Enter F12 RCtrl A Y");

			Assert.Equal(5, commands.Count());
			Assert.Equal(5, commands.OfType<KeypressInputCommand>().Count());
    	}

    	[Fact]
    	public void ShouldCreateCorrectSequenceForKeyChord()
    	{
			var creator = new DefaultCommandCreator();

			var commands = creator.Create("Ctrl+A");

			Assert.Equal(3, commands.Count());
    		Assert.IsType<KeydownInputCommand>(commands.ElementAt(0));
    		Assert.IsType<KeypressInputCommand>(commands.ElementAt(1));
    		Assert.IsType<KeyupInputCommand>(commands.ElementAt(2));
    	}
    }
}