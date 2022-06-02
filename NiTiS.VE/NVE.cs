// The NiTiS-Dev licenses this file to you under the MIT license.

using NiTiS.VE.Services.Runtime;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE;
public class NVE
{
	private readonly string runnerName;
	private readonly Sequence<Package> packages;
	private readonly NiTiS.VE.Services.Version version = new(0, 0, 0, 2);
	public NVE(string runnerName)
	{
		this.runnerName = runnerName;
		this.packages = new(16);
	}
	public void LoadPackage(Package pack)
	{
		this.packages.Add(pack);
	}
	public void LoadPackage(byte[] rawData)
		=> throw new System.NotImplementedException();
	public void Execute()
	{

	}
	public Type? GetType(string packageName, string typeName)
		=> packages.Where(pack => pack.name == packageName).SelectMany(pack => pack.types).Where(type => type.name == typeName).FirstOrDefault();
	public Type? GetType(string typeName)
		=> packages.SelectMany(pack => pack.types).Where(type => type.name == typeName).FirstOrDefault();
	public Type? GetType(Reference<Package> packageRef, string typeName)
		=> packages.Where(pack => pack == packageRef).SelectMany(pack => pack.types).Where(type => type.name == typeName).FirstOrDefault();
	public Type? GetType(Reference<Package> packageRef, Reference<Type> typeRef)
		=> packages.Where(pack => pack == packageRef).SelectMany(pack => pack.types).Where(type => type == typeRef).FirstOrDefault();
	public IEnumerable<Package> GetPackages()
		=> packages;
}
