using Creation.FactoryMethod.DocumentProcessor.Documents;

namespace Creation.FactoryMethod.DocumentProcessor.DocumentProcessors;

public class AdobeDocumentProcessor : DocumentProcessor
{
    protected override IDocument CreateDocument(string type)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);

        return type.ToLower() switch
        {
            "pdf" => new PDFDocument(), 
            _ => throw new ArgumentOutOfRangeException(
                $"{type} type Document is not supported by AdobeDocumentProcessor")
        };
    }
}