// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE;
public class InvalidCreateTypeException : Exception
{
	public InvalidCreateTypeException(string message) : base(message)
	{

	}
}
