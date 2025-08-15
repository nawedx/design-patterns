namespace Creation.FactoryMethod.DocumentProcessor.Documents;

public class ExcelDocument : IDocument
{
    public void Open() => Console.WriteLine("Opening ExcelDocument");

    public void Process() => Console.WriteLine("Processing ExcelDocument");

    public void Save() => Console.WriteLine("Saving ExcelDocument");

    public void Close() => Console.WriteLine("Closing ExcelDocument");
}