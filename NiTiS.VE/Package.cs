using NiTiS.VE.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NiTiS.VE;

public class Package
{
	internal string name;
	internal Version version;
	private PackageReference reference;
	private NVEClass[] classes;
	private Package() { }

	public string Name => name;
	public Version Version => version;
	public PackageReference Reference => reference;
	public IEnumerable<NVEClass> Classes => classes;
	public override string ToString()
	{
		return $"{name} {version}";
	}
	public class Builder
	{
		private string? packageName;
		private Version version;
		private readonly PackageReference reference = new();
		private readonly List<NVEClass> classes = new();
		public Builder(string packageName)
		{
			this.packageName = packageName;
		}
		public Builder WithName(string packageName)
		{
			this.packageName = packageName;
			return this;
		}
		public Builder WithClass(NVEClass rawClass)
		{
			this.classes.Add(rawClass);
			return this;
		}
		public Builder WithVersion(Version version)
		{
			this.version = version;
			return this;
		}
		public Package Build()
		{
			return new Package()
			{
				name = packageName ?? "_unset_",
				version = this.version,
				reference = this.reference,
				classes = this.classes.ToArray(),
			};
		}
		public PackageReference GetPackageReference() => reference;
		public ClassBuilder CreateClassBuilder(string className)
		{
			return new(reference, className);
		}
	}
	public class PackageReference : IEquatable<PackageReference>, IEquatable<Package>
	{
		private static uint pckID = 0;
		private readonly uint packageID = pckID++;
		public uint ID => packageID;
		internal PackageReference()
		{

		}
		public override int GetHashCode() => (int)(packageID -3215847);
		public bool Equals([AllowNull] PackageReference other)
		{
			return other?.packageID == this.packageID;
		}
		public bool Equals([AllowNull] Package other)
		{
			return other?.reference?.packageID == this.packageID;
		}
		public override bool Equals(object? obj)
		{
			if (obj is Package pck)
			{
				return Equals(pck);
			}
			if (obj is PackageReference pckRef)
			{
				return Equals(pckRef);
			}
			return false;
		}
		public override string? ToString() => $"Package Reference: {packageID}";
	}
}