namespace NiTiS.VE.Services.Runtime.Exec;

public class Instance
{
	private Class type;
	public byte self;
	public Instance(Class type)
	{ this.type = type; }

	public void Add(Instance instance)
		=> Add(instance.self); 
	public void Add(byte value)
		=> self += value;
	public void Set(Instance instance)
		=> Set(instance.self);
	public void Set(byte value)
		=> self += value;
	public override string ToString() 
		=> $"{type} {self}";
}
