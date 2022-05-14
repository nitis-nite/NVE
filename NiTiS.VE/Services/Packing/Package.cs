using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Services.Packing;

public class Package
{

	public class Builder
	{
		private string packageName;
		private Version version;
		public Builder(string packageName)
		{
			this.packageName = packageName;
		}
		public Builder WithVersion(Version version)
		{
			this.version = version;
			return this;
		}
	}
}
