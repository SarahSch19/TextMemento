namespace TextMemento;

public class TextWindowSnapshot: IMemento<TextWindow>
{
    private String Content;
    
    public TextWindowSnapshot(TextWindow window)
    {
        Content = window.GetContent();
    }

    public TextWindow Restore()
    {
        TextWindow window = new TextWindow();
        window.AddText(Content);
        return window;
    }
}