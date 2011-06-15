using System.Runtime.InteropServices;

namespace Muyou.LinqToWindows.Input.NativeTypes
{
	/// <summary>
	/// Captures the union of the three three structures.
	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct InputDataUnion
	{
		/// <summary>
		/// The Mouse Input Data
		/// </summary>
		[FieldOffset(0)]
		public MouseInputData MouseInputData;

		/// <summary>
		/// The Keyboard input data
		/// </summary>
		[FieldOffset(0)]
		public KeyboardInputData KeyboardInputData;

		/// <summary>
		/// The hardware input data
		/// </summary>
		[FieldOffset(0)]
		public HardwareInputData HardwareInputData;
	}
}