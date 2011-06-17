using System.Runtime.InteropServices;
using Muyou.LinqToWindows.Input.NativeTypes;

namespace Muyou.LinqToWindows.Input
{
    public abstract class InputCommand
	{
		private readonly SendInputEventType _eventType;

		protected InputDataChunk[] Chunks;

		protected InputCommand(SendInputEventType eventType)
		{
			_eventType = eventType;
		}

		protected InputDataChunk CreateInputDataChunk(MouseInputData? mouseInputData = null, KeyboardInputData? keyboardInputData = null, HardwareInputData? hardwareInputData = null)
		{
			var inputDataUnion = new InputDataUnion();
			if (mouseInputData != null)
				inputDataUnion.MouseInputData = mouseInputData.Value;
			else if (keyboardInputData != null)
				inputDataUnion.KeyboardInputData = keyboardInputData.Value;
			else if (hardwareInputData != null)
				inputDataUnion.HardwareInputData = hardwareInputData.Value;
			
			return new InputDataChunk {Type = _eventType, InputData = inputDataUnion};
		}

		public void Execute()
		{
			if (Chunks == null)
				return;

			foreach (var inputDataChunk in Chunks)
			{
				var chunk = inputDataChunk;
				SendInput(1, ref chunk, InputDataChunk.SizeOf);
			}
		}

		[DllImport("user32.dll", SetLastError = true)]
		static extern uint SendInput(uint inputDataChunksCount, ref InputDataChunk inputDataChunk, uint cbSize);
	}
}