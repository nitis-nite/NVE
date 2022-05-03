using System;
using System.Collections.Generic;
using System.Text;

namespace NiteCode.Services.Runtime;

public class Package : IReferenceable<Package>
{
	private Reference<Package> reference = new();
	public Reference<Package> Reference => reference;
	protected string name;
	public Package(string name)
	{
		this.name = name;
	}

}
