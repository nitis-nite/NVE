using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NiTiS.VE.Core.Runtime;

namespace NiTiS.VE.Core;

public class NVEClass : NVEMemberAlocation
{
	private List<NVEMethod> methods = new();
	private readonly List<NVEClass> extends = new();
	private readonly List<NVEInterface> realize = new();
	public NVEMethod? GetMethod(string name, params NVEType[] arguments)
	{
		return GetMethods().Where(m => m.Name == name).Where(m => m.Arguments == arguments).FirstOrDefault();
	}
	public IEnumerable<NVEMethod> GetMethods()
	{
		foreach(NVEMethod method in methods)
		{
			yield return method;
		}
		foreach (NVEClass @class in extends)
		{
			foreach (NVEMethod method in @class.GetMethods())
			{
				yield return method;
			}
		}
		
	}
	public virtual NVEInstance CreateInstance() => new(this);
	public NVEClass(PackageReference reference, string name) : base(reference, name)
	{
	}
	public NVEClass(PackageReference reference, string name, string? alias) : base(reference, name, alias)
	{
	}

	public class Builder
	{
		protected string className;
		protected string? alias;
		protected readonly PackageReference reference;
		protected readonly List<NVEClass> extends = new();
		protected readonly List<NVEInterface> realize = new();
		protected readonly List<NVEMethod> methods = new();
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
		public virtual NVEClass Build()
		{
			return new NVEClass(reference, className, alias)
			{
			};
		}
		public NVEClass Build(PackageBuilder builder)
		{
			NVEClass @class = Build();
			builder.WithClass(@class);
			return @class;
		}
		public PackageReference GetPackageReference() => reference;
	}
}
