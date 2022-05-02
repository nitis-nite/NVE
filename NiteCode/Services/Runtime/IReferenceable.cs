using System;
using System.Collections.Generic;
using System.Text;

namespace NiteCode.Services.Runtime;

public interface IReferenceable<T> where T : IReferenceable<T>
{
	public Reference<T> Reference { get; }
}
