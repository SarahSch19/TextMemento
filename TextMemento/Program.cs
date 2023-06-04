// See https://aka.ms/new-console-template for more information

using TextMemento;

Console.WriteLine("Welcome to the memento text editor !");
Console.WriteLine("- To snapshot, type 'Snapshot'.");
Console.WriteLine("- To quit type 'Exit'");
Console.WriteLine("- To undo type 'Undo'");
Console.WriteLine("- To redo type 'Do'");

TextEditor editor = new TextEditor(new TextWindow());

string? input = "";
while (input != "Exit")
{
    Console.Write("> ");
    input = Console.ReadLine();
    switch (input)
    {
        case "Exit": continue;
        case "Snapshot": editor.Snapshot();
            Console.WriteLine("Snapshot !");
            break;
        case "Do": editor.Do();
            break;
        case "Undo": editor.Undo();
            break;
        default:
            if (input != null) editor.Write(input);
            break;
    }

    Console.WriteLine("*****");
    editor.Print();
    Console.WriteLine("*****");
}