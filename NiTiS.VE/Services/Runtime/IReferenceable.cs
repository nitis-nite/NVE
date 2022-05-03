using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE.Services.Runtime;

public interface IReferenceable<T> where T : IReferenceable<T>
{
	public Reference<T> Reference { get; }
}
