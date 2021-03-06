// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.VE;
public class UnsupportableFeatureException : Exception
{
	public UnsupportableFeatureException(string featureName) : base($"Feature {featureName} doesn't supported") { }
}
