namespace TextMemento;

public interface IMemento<out T>
{
   public T Restore();
}