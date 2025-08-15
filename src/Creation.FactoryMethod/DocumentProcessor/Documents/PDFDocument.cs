namespace Creation.FactoryMethod.DocumentProcessor.Documents;

public class PDFDocument : IDocument
{
    public void Open() => Console.WriteLine("Opening PDFDocument");

    public void Process() => Console.WriteLine("Processing PDFDocument");

    public void Save() => Console.WriteLine("Saving PDFDocument");

    public void Close() => Console.WriteLine("Closing PDFDocument");
}