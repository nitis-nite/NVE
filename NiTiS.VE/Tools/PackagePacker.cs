using NiTiS.IO;
using System.Text;

namespace NiTiS.VE.Tools;

public abstract class PackagePacker
{
	/// <summary>
	/// Default header for NVE compiled files <c>%nvecc</c>
	/// </summary>
	public static readonly byte[] FIXED_NVE_HEADER = new byte[]
	{
		0x25, 0x6E, 0x76, 0x65, 0x63,
	};
	public abstract File Compile(File projectFile, params string[] arguments);
}
