using Creation.FactoryMethod.DocumentProcessor.Documents;

namespace Creation.FactoryMethod.DocumentProcessor.DocumentProcessors;

public class CloudDocumentProcessor: DocumentProcessor
{
    protected override IDocument CreateDocument(string type)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);
        
        return type.ToLower() switch
        {
            "pdf" => new PDFDocument(),
            "word" => new WordDocument(),
            "excel" => new ExcelDocument(),
            _ => throw new ArgumentOutOfRangeException(
                $"{type} type Document is not supported by CloudDocumentProcessor")
        };
    }
}