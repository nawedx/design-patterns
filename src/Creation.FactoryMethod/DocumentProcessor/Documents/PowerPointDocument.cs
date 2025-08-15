namespace Creation.FactoryMethod.DocumentProcessor.Documents;

public class PowerPointDocument : IDocument
{
    public void Open() => Console.WriteLine("Opening PowerPoint Document");

    public void Process() => Console.WriteLine("Processing PowerPoint Document");
    
    public void Save() => Console.WriteLine("Saving PowerPoint Document");
    
    public void Close() => Console.WriteLine("Closing PowerPoint Document");
}