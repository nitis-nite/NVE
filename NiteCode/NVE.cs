using NiTiS.Collections.Generic;
using NiTiS.VE;
using NiTiS.VE.Services.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using NiteCode.Services;
using NiteCode.Services.Runtime;

namespace NiteCode;

public class NVE
{
	private SmartDictonary<string, NType> typeCollection = new(type => type.FullName, 128);

	/// <summary>
	/// Register <paramref name="type"/>
	/// </summary>
	/// <param name="type"></param>
	public void RegistryType(NType type)
	{
		typeCollection.Add(type);
	}
	/// <summary>
	/// Delete <paramref name="type"/> from registry
	/// </summary>
	/// <remarks>
	/// Not recommended (use only with annotation types)
	/// </remarks>
	/// <param name="type">Type for deletion</param>
	public void RestoreType(NType type)
	{
		typeCollection.Remove("");
	}
	/// <summary>
	/// Create instance of type
	/// </summary>
	/// <param name="type">Type of instance</param>
	/// <typeparam name="T">Generic type of instance</typeparam>
	public IVEInstance<T> CreateInstance<T>(NType type)
	{
		return null;
	}
}