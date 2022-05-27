using NiTiS.Collections.Generic;
using NiTiS.IO;
using System.Collections.Generic;
using System.Linq;

namespace NiTiS.VE.Services.Packing;

public class Package : IPackable, IReferenceable<Package>
{
	private string name = System.String.Empty;
	private Version version;
	private Type[] types;
	private Reference<Package> reference;
	public Reference<Package> Reference => reference;
#pragma warning disable CS8618
	private Package()
	{
		this.reference = new Reference<Package>(this);
	}
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

		if (h1 != 73 && h2 != 46) throw new System.Exception("Invalid format");
		
		Package package = new Package();

		//Read Metadata
		package.name = reader.String();
		package.version = reader.Version();

		return package;
	}
	public class Builder : IReferenceable<Package>
	{
		private Package package;
		private Sequence<Type> types = new(4);
		public Builder(string packageName)
		{
			this.package = new();
			this.package.name = packageName;
		}

		public Reference<Package> Reference
			=> this.package.reference;

		public Builder WithVersion(Version version)
		{
			this.package.version = version;
			return this;
		}
		public Builder WithType(Type type)
		{
			this.types.Add(type);
			return this;
		}
		public Package Build()
		{
			this.package.types = types.ToArray();
			return this.package;
		}
		public void Write(System.IO.FileStream stream)
		{
			byte[] buffer = this.package.GetBytes();
			stream.Write(buffer, 0, buffer.Length);
		}
		public void Write(File file)
		{
			byte[] buffer = this.package.GetBytes();
			file.WriteBytesAsync(buffer).Wait();
		}
	}
}
