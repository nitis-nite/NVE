namespace NiTiS.VE.Core.Runtime;

public class NVEInstanceBasicType<T> : NVEInstance where T : struct
{
	private T value;
	public NVEInstanceBasicType(NVEType @typeof) : base(@typeof)
	{
	}
	public T Value
	{
		get => this.value;
		set => this.value = value;
	}
}
