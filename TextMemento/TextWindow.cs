using System.Text;

namespace TextMemento;

public class TextWindow: IOriginator<TextWindow, TextWindowSnapshot>
{
    private StringBuilder CurrentText;

    public TextWindow() {
        this.CurrentText = new StringBuilder();
    }

    public void SetState(TextWindow state)
    {
        this.CurrentText = state.CurrentText;
    }

    public void AddText (String text) {
        CurrentText.Append(text);
    }

    public TextWindowSnapshot CreateSnapshot()
    {
        return new TextWindowSnapshot(this);
    }

    public String GetContent()
    {
        return CurrentText.ToString();
    }

    public override string ToString()
    {
        return "TextWindow : " + CurrentText.ToString();
    }
}