using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Core.Exec;

public class Execute
{
	public Execute()
	{
	}
	public NVEInstance? Invoke(NVEInstance? instance, params NVEInstance[] arguments)
	{
		Console.WriteLine($"Try to invoke from {instance?.ToString()}");
		return null;
	}
}