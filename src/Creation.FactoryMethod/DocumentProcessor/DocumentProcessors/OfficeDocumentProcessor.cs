using Creation.FactoryMethod.DocumentProcessor.Documents;

namespace Creation.FactoryMethod.DocumentProcessor.DocumentProcessors;

public class OfficeDocumentProcessor : DocumentProcessor
{
    protected override IDocument CreateDocument(string type)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);

        return type.ToLower() switch
        {
            "word" => new WordDocument(),
            "excel" => new ExcelDocument(),
            "powerpoint" => new PowerPointDocument(),
            _ => throw new ArgumentOutOfRangeException(
                $"{type} type Document is not supported by OfficeDocumentProcessor")
        };
    }
}