namespace Creation.FactoryMethod.DocumentProcessor.Documents;

public interface IDocument
{
    void Open();
    void Process();
    void Save();
    void Close();
}