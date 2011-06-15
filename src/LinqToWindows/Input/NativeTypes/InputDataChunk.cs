using System.Runtime.InteropServices;

namespace Muyou.LinqToWindows.Input.NativeTypes
{
	/// <summary>
	/// The Data passed to SendInput in an array.
	/// </summary>
	/// <remarks>Contains a union field type specifies what it contains </remarks>
	public struct InputDataChunk
	{
		/// <summary>
		/// The actual data type contained in the union Field
		/// </summary>
		public SendInputEventType Type;
		public InputDataUnion InputData;

		public static uint SizeOf
		{
			get { return (uint) Marshal.SizeOf(typeof (InputDataChunk)); }
		}
	}
}