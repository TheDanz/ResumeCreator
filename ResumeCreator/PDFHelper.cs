using System;
using Word = Microsoft.Office.Interop.Word;

namespace ResumeCreator
{
    class PDFHelper
    {
        public Word.Document wordDocument { get; set; }
        public void ConvertToPDF()
        {
            string baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            Word.Application appWord = new Word.Application();
            wordDocument = appWord.Documents.Open(baseDirectoryPath + @"\ReadySample.docx");
            wordDocument.ExportAsFixedFormat(baseDirectoryPath + @"\ReadySample.pdf", Word.WdExportFormat.wdExportFormatPDF);
            appWord.ActiveDocument.Close();
        }
    }
}
