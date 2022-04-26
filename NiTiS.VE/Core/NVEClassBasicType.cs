using NiTiS.VE.Core.Runtime;

namespace NiTiS.VE.Core;

public class NVEClassBasicType<T> : NVEClass where T : struct
{
	public NVEClassBasicType(PackageReference reference, string name) : base(reference, name)
	{
	}
	public NVEClassBasicType(PackageReference reference, string name, string? alias) : base(reference, name, alias)
	{
	}
	public override NVEInstance CreateInstance() => new NVEInstanceBasicType<T>(this);
	public class Builder<B> : ClassBuilder where B : struct
	{
		public Builder(PackageReference reference, string className) : base(reference, className)
		{
		}
		public override NVEClass Build()
		{
			return new NVEClassBasicType<B>(reference, className, alias)
			{

			};
		}
	}
}
