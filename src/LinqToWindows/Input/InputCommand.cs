using System;
using System.Runtime.InteropServices;
using Muyou.LinqToWindows.Input.NativeTypes;

namespace Muyou.LinqToWindows.Input
{
    public abstract class InputCommand
	{
    	protected readonly SendInputEventType EventType;
    	protected readonly IntPtr Handle;
    	protected InputDataChunk[] Chunks;

    	protected InputCommand(IntPtr handle, SendInputEventType eventType)
		{
			Handle = handle;
			EventType = eventType;
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
			
			return new InputDataChunk {Type = EventType, InputData = inputDataUnion};
		}

		public void Execute(InputMode inputMode = InputMode.Send)
		{
			if (Chunks == null)
				return;

			switch (inputMode)
			{
				case InputMode.Send:
					foreach (var inputDataChunk in Chunks)
					{
						var chunk = inputDataChunk;
						SendInput(1, ref chunk, InputDataChunk.SizeOf);
					}
					break;
				case InputMode.Post:
					ExecutePost();
					break;
			}
		}

    	protected abstract void ExecutePost();

    	[DllImport("user32.dll", SetLastError = true)]
		static extern uint SendInput(uint inputDataChunksCount, ref InputDataChunk inputDataChunk, uint cbSize);

		[DllImport("user32.dll", SetLastError = true)]
		protected static extern bool PostMessage(IntPtr hWnd, uint msg, uint wParam, uint lParam);
	}
}