namespace NiTiS.VE.Services.Runtime;

public interface INVEInstance<out T>
{
	public T GetItself();
}
