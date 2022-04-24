using System;
using System.Collections.Generic;
using System.Text;
using static NiTiS.VE.Core.Exec.ActCode;

namespace NiTiS.VE.Core.Exec;

public class Execute
{
	private readonly Act[] actions;
	public Execute(params Act[] actions)
	{
		this.actions = actions;
	}
	public void Invoke(NVEInstance? instance, params NVEInstance[] arguments)
	{
		foreach(Act act in actions)
		{
			if (act.Code == READ_VALUE)
			{
				string readValueName = act.ReadDataAsString();

			}
		}
	}
	[Obsolete]
	static Execute Load(byte[] rawExecute)
	{
		return null;
	}
}
public enum ActCode : byte
{
	READ_VALUE = 0,
	WRITE_VALUE = 1,
}
public record struct Act(ActCode Code, byte[] Data)
{
	public string ReadDataAsString()
	{
		return Encoding.UTF8.GetString(Data);
	}
}
