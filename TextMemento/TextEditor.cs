namespace TextMemento;

public class TextEditor: ICateraker
{
    private TextWindow Window;
    private Stack<TextWindowSnapshot> UndoMemento;
    private Stack<TextWindowSnapshot> DoMemento;

    public TextEditor(TextWindow window) {
        this.Window = window;
        this.UndoMemento = new Stack<TextWindowSnapshot>();
        this.DoMemento = new Stack<TextWindowSnapshot>();
    }

    public void Write(String text)
    {
        Snapshot();
        this.Window.AddText(text);
        DoMemento.Clear();
    }

    private void Snapshot()
    {
        UndoMemento.Push(Window.CreateSnapshot());
    }

    public void Undo()
    {
        if (UndoMemento.Count != 0)
        {
            DoMemento.Push(Window.CreateSnapshot());
            Window.SetState(UndoMemento.Pop().Restore());
        }
    }

    public void Do()
    {
        if (DoMemento.Count != 0)
        {
            Snapshot();
            Window.SetState(DoMemento.Pop().Restore());
        }
        else
        {
            Console.WriteLine("Nothing to do :(");
        }

    }

    public void Print()
    {
        Console.WriteLine(Window.GetContent());
    }
}