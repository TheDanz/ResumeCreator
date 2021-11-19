using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;

namespace ResumeCreator
{
    class WordHelper
    {
        private FileInfo _fileInfo;

        public WordHelper(string fileName)
        {
            _fileInfo = new FileInfo(fileName);
        }

        public void Process(Dictionary<string, string> items)
        {
            Word.Application app = null;
            try
            {
                app = new Word.Application();
                object file = _fileInfo.FullName;
                object missing = Type.Missing;
                app.Documents.Open(file);
                foreach (var item in items)
                {
                    Word.Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;
                    object wrap = Word.WdFindWrap.wdFindContinue;
                    object replace = Word.WdReplace.wdReplaceAll;
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
                object newFileName = Path.Combine(_fileInfo.DirectoryName, "Ready" + _fileInfo.Name);
                app.ActiveDocument.SaveAs2(newFileName);
                app.ActiveDocument.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ResumeCreator", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                app?.Quit();
            }
        }
    }
}
