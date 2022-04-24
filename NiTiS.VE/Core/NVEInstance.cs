using System.Collections.Generic;

namespace NiTiS.VE.Core;

public class NVEInstance
{
	private readonly NVEType @typeof;
	private readonly Dictionary<string, NVEInstance> localVariables = new();
	public NVEInstance(NVEType @typeof)
	{
		this.@typeof = @typeof;
	}
	public NVEInstance(byte[] rawData)
	{
		this._data = rawData;
		this.@typeof = NVEType.RELEATIVE_TYPE;
	}

	public NVEInstance GetVariable(string name)
	{
		return localVariables[name];
	}
	public byte[] GetRawData()
	{
		return _data;
	}

	/// <summary>
	/// Required for realization basic types
	/// </summary>
	private readonly byte[] _data;
}
