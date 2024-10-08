using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace RichTextBox
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadDocumentToRtb(string filePath)
        {
            TextRange documentText = new TextRange(DocumentRtb.Document.ContentStart, DocumentRtb.Document.ContentEnd);

            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    documentText.Load(fs, DataFormats.Text);
                }
            }
            else
            {
                documentText.Text = String.Empty;
                MessageBox.Show("Такого файла не существует.");
            }
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            this.LoadDocumentToRtb(FilePathTb.Text);
        }

        private void DocumentRtb_DragEvent(object sender, DragEventArgs e)
        {
            TextRange documentText = new TextRange(DocumentRtb.Document.ContentStart, DocumentRtb.Document.ContentEnd);
            string fileName = (e.Data.GetData(DataFormats.FileDrop) as string[])[0];
            this.LoadDocumentToRtb(fileName);
        }
    }
}