
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;

namespace ResumeCreator
{
    class WordHelper
    {
        private FileInfo _fileInfo;
        private string _filePath;

        public WordHelper(string fileName, string filePath)
        {
            _filePath = filePath;
            _fileInfo = new FileInfo(fileName);
        }

        protected void ConvertToPDF()
        {
            Word.Application appWord = new Word.Application();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            var wordDocument = appWord.Documents.Open(path + @"\1Sample.docx");
            wordDocument.ExportAsFixedFormat(_filePath + @".pdf", Word.WdExportFormat.wdExportFormatPDF);
            wordDocument.Close();
        }
        internal bool Process(Dictionary<string, string> items)
        {
            Word.Application app = null;
            try
            {
                app = new Word.Application();
                Object file = _fileInfo.FullName;
                Object missing = Type.Missing;

                app.Documents.Open(file);
                foreach (var item in items)
                {
                    Word.Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;

                    Object wrap = Word.WdFindWrap.wdFindContinue;
                    Object replace = Word.WdReplace.wdReplaceAll;

                    find.Execute(FindText: Type.Missing,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchSoundsLike: missing,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: missing,
                        Replace: replace);
                }
                Object newFileName = Path.Combine(_fileInfo.DirectoryName, "1" + _fileInfo.Name);
                app.ActiveDocument.SaveAs2(newFileName);
                app.ActiveDocument.Close();
                ConvertToPDF();
                return true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                if (app != null)
                    app.Quit();
            }
            return false;
        }
    }
}
