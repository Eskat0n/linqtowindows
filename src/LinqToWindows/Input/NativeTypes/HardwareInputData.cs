using System.Runtime.InteropServices;

namespace Muyou.LinqToWindows.Input.NativeTypes
{
	[StructLayout(LayoutKind.Sequential)]
	public struct HardwareInputData
	{
		public int uMsg;
		public short wParamL;
		public short wParamH;
	}
}