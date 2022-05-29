using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Services.Runtime;
public class Type
{
	public Name Name { get; set; }
	public class Builder
	{
		private Name name;
		private Link<Type> link = new(null!);
		public Builder(Name name)
			=> this.name = name;
		public Builder() { }
		public Type Build()
		{
			Type type = new();

			return type;
		}
	}
}
