using NiTiS.VE.Services.Packing;
using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Services.Runtime;

public class Class : Type
{
	private Class[]? dependensClasses;

	public Class(string @namespace, string name, Reference<Package> package) : base(@namespace, name, package)
	{
	}
	public sealed class Builder
	{
		private string @namespace, name;
		private Reference<Package>? reference;
		private List<Class> dependensClasses = new(2);
		public Builder(string @namespace, string name)
		{
			this.@namespace = @namespace;
			this.name = name;
		}
		public Builder Depend(Class @class)
		{
			dependensClasses.Add(@class);
			return this;
		}
		public Builder Depends(params Class[] classes)
		{
			dependensClasses.AddRange(classes);
			return this;
		}
		public Builder FromPackage(Package package)
			=> FromPackage(package.Reference);
		public Builder FromPackage(Reference<Package> reference)
		{
			this.reference = reference;
			return this;
		}
		public Class Build()
		{
			return new Class(@namespace, name, reference!)
			{
				dependensClasses = this.dependensClasses.ToArray(),
			};
		}
		public Class Build(NVE nve)
		{
			Class @class = Build();
			nve.RegistryType(@class);
			return @class;
		} 
	}
}
