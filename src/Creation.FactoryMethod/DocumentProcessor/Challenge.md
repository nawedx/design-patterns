## Challenge: Document Processing System

**Scenario**: You're building a document processing system for a company that handles different types of documents (PDF, Word, Excel). Each document type needs different processing steps, but the overall workflow is the same.

**Requirements**:

1. **Document Types**: PDF, Word, Excel
2. **Each document should have these methods**:
    - `Open()` - How to open the document
    - `Process()` - How to process the content
    - `Save()` - How to save the document
    - `Close()` - How to close the document

3. **Different Processors**:
    - `OfficeDocumentProcessor` - Handles Word and Excel documents
    - `AdobeDocumentProcessor` - Handles PDF documents
    - `CloudDocumentProcessor` - Handles all types but with cloud-specific processing

4. **Processing workflow** should always be: Open → Process → Save → Close

5. **Specific behaviors**:
    - **PDF**: "Opening PDF with Adobe Reader", "Processing PDF content with OCR", "Saving PDF with compression", "Closing PDF viewer"
    - **Word**: "Opening Word document", "Processing Word content with spell check", "Saving Word document", "Closing Word application"
    - **Excel**: "Opening Excel spreadsheet", "Processing Excel data with formulas", "Saving Excel workbook", "Closing Excel application"

**Your Task**:
1. Design the Factory Method pattern for this system
2. Implement at least 2 different processors
3. Show that adding a new document type (like PowerPoint) doesn't require changing existing code
4. Demonstrate the system working with different processors

**Bonus Challenge**:
- Add a `GetSupportedFormats()` method to each processor
- Handle unsupported document types gracefully
- Add some basic validation (like file extension checking)

## What I'm Testing:

1. **Interface Design**: Can you create a proper document interface?
2. **Factory Method Implementation**: Can you implement the abstract factory class correctly?
3. **Concrete Factories**: Can you create specific processor classes?
4. **Extensibility**: Can you add new types without modifying existing code?
5. **Understanding the Pattern**: Do you use inheritance properly for the factory method?

Try implementing this step by step:

1. Start with the document interface
2. Create concrete document classes
3. Create the abstract processor (with factory method)
4. Implement specific processors
5. Test with a main method

Once you've given it a try, share your code and I'll provide feedback and show you how to improve it! Don't worry about getting it perfect - the goal is to practice and learn.

**Hint**: Think about which class should have the `ProcessDocument(string documentType)` method and which should have the `CreateDocument(string type)` factory method.

Take your time with this. The key is understanding WHY you're making each design decision, not just writing code that works.