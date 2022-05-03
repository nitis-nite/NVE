namespace NiTiS.VE.Services.Runtime;

public interface IVEInstance<out T>
{
	public T GetItself();
}
