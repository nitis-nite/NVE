using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE;

public class NVEMethod
{
	public NVEType OutParam { get; }
	public NVEType[] InParams { get; }
	public Method Method { get; }
	public NVEMethod(Method method, NVEType @out, params NVEType[] @in)
	{
		OutParam = @out;
		InParams = @in;
		Method = method;
	}
}
