namespace TextMemento;

public class TextEditor
{
    private TextWindow Window;
    private Stack<TextWindowSnapshot> UndoMemento;
    private Stack<TextWindowSnapshot> DoMemento;

    public TextEditor(TextWindow window) {
        this.Window = window;
        this.UndoMemento = new Stack<TextWindowSnapshot>();
        UndoMemento.Push(Window.CreateSnapshot());
        this.DoMemento = new Stack<TextWindowSnapshot>();
    }

    public void Write(String text)
    {
        this.Window.AddText(text);
    }

    public void Snapshot()
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
        else
        {
            Window.SetState(new TextWindow());
        }
    }

    public void Do()
    {
        if (DoMemento.Count != 0)
        {
            UndoMemento.Push(Window.CreateSnapshot());
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