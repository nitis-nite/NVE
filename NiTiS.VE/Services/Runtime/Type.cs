// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

namespace NiTiS.VE.Services.Runtime;

[StructLayout(LayoutKind.Sequential)]
public class Type : IReferencable<Type>
{
	public Reference<Type> Reference => new();
}
