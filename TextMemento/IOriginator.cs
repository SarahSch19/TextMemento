namespace TextMemento;

public interface IOriginator<in TOrigin, out TSnapshot>
{
    public TSnapshot CreateSnapshot();

    public void SetState(TOrigin state);
}