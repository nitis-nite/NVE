using NiTiS.Collections.Generic;
using NiTiS.IO;
using System.Collections.Generic;
using System.Linq;

namespace NiTiS.VE.Services.Packing;

public class Package : IPackable
{
	private string name = System.String.Empty;
	private Version version;
	private Type[] types;
#pragma warning disable CS8618
	private Package() { }
#pragma warning restore CS8618
	public byte[] GetBytes()
	{
		Sequence<byte> bytes = new(2048);

		if (name.Length > byte.MaxValue)
			throw new System.ArgumentException("Package name is soo long! Max lenght is 256");

		//Header
		bytes.AddRange(73, 46);
		
		//Metadata
		byte[] metaName, metaVer;
		metaName = UTF8.GetBytes(name);
		metaVer = version.GetBytes();
		bytes.Add((byte)name.Length);
		bytes.AddRange(metaName);
		bytes.AddRange(metaVer);

		//Data

		return bytes.ToArray();
	}
	public override string ToString() 
		=> $"{name} {version}";
	public static Package Load(File file)
	{
		Reader reader = new(file.ReadBytes());

		byte h1, h2;

		h1 = reader.Byte();
		h2 = reader.Byte();

		if (h1 != 73 && h2 != 46) throw new System.BadImageFormatException("Invalid format");
		
		Package package = new Package();

		//Read Metadata
		package.name = reader.String();
		package.version = reader.Version();

		return package;
	}
}
