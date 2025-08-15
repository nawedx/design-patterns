using Creation.FactoryMethod.DocumentProcessor.Documents;

namespace Creation.FactoryMethod.DocumentProcessor.DocumentProcessors;

public abstract class DocumentProcessor
{
    protected abstract IDocument CreateDocument(string type);
    
    public IDocument Process(string type)
    {
        var document = CreateDocument(type);
        
        document.Open();
        document.Process();
        document.Save();
        document.Close();
        
        return document;
    }
}