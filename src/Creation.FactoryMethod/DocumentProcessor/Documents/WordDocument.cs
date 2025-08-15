namespace Creation.FactoryMethod.DocumentProcessor.Documents;

public class WordDocument : IDocument
{
    public void Open() => Console.WriteLine("Opening WordDocument");

    public void Process() => Console.WriteLine("Processing WordDocument");

    public void Save() => Console.WriteLine("Saving WordDocument");

    public void Close() => Console.WriteLine("Closing WordDocument");
}