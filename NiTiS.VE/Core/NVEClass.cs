using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Core;

public class NVEClass : NVEMemberAlocation
{
	public NVEClass(PackageReference reference, string name) : base(reference, name)
	{
	}
	public NVEClass(PackageReference reference, string name, string? alias) : base(reference, name, alias)
	{
	}

	public class Builder
	{
		private string className;
		private string? alias;
		private readonly PackageReference reference;
		private readonly List<NVEClass> extends = new();
		private readonly List<NVEInterface> realize = new();
		private readonly List<NVEMethod> methods = new();
		public Builder(PackageReference reference, string className)
		{
			this.reference = reference;
			this.className = className;
		}
		public Builder ExtendClass(NVEClass inherited)
		{
			this.extends.Add(inherited);
			return this;
		}
		public Builder RealizeInterface(NVEInterface inherited)
		{
			this.realize.Add(inherited);
			return this;
		}
		public Builder WithName(string className)
		{
			this.className = className;
			return this;
		}
		public Builder WithMethod(NVEMethod method)
		{
			this.methods.Add(method);
			return this;
		}
		public Builder WithAlias(string alias)
		{
			this.alias = alias;
			return this;
		}
		public Builder WithMethod()
		{
			return this;
		}
		public Builder WithField(string fieldName, NVEClass fieldType)
		{
			return this;
		}
		public NVEClass Build()
		{
			return new NVEClass(reference, className)
			{
			};
		}
		public PackageBuilder Build(PackageBuilder builder)
		{
			NVEClass @class = new NVEClass(reference, className, alias)
			{
			};
			return builder.WithClass(@class);
		}
		public PackageReference GetPackageReference() => reference;
	}
}
