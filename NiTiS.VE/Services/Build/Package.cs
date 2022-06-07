// The NiTiS-Dev licenses this file to you under the MIT license.

using NiTiS.VE.Services.Runtime;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Services.Build;
public class Package
{
	internal Type[] types;
	internal Strlnk name;
	internal Strlnk filePath;

	public class Builder
	{
		private Strlnk filePath, name;
		private Sequence<Type> types = new(16);
		public Builder(string name, File filePath)
		{
			this.filePath = new(filePath.Path);
			this.name = new(name);
		}
		public void AddType(Type type)
		{
			types.Add(type);
		}
		public Package Build()
		{
			return new()
			{
				filePath = this.filePath,
				name = this.name,
				types = this.types.ToArray()
			};
		}
	}
}
