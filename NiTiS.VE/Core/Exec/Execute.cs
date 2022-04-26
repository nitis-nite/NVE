using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Core.Exec;

public class Execute
{
	public Execute()
	{
	}
	public NVEInstanceOLD? Invoke(NVEInstanceOLD? instance, params NVEInstanceOLD[] arguments)
	{
		Console.WriteLine($"Try to invoke from {instance?.ToString()}");
		return null;
	}
}