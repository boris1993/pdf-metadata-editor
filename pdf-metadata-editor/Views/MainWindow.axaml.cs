using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using PdfMetadataEditor.ViewModels;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PdfMetadataEditor.Views
{
    public partial class MainWindow : Window
    {
        private const string LanguageZhCn = "zh-CN";
        private const string LanguageEnUs = "en-US";
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private async void OpenFileButtonClicked(object sender, RoutedEventArgs e)
        {
            var topLevel = GetTopLevel(this);
            var files = await topLevel!.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = ((MainWindowViewModel)DataContext!).ButtonTextOpenPdfFile,
                AllowMultiple = false,
                FileTypeFilter = new List<FilePickerFileType>([FilePickerFileTypes.Pdf]),
            });

            if (files.Count != 1)
            {
                // Popup error. This shouldn't happen.
            }

            LoadPdfMetadata(files[0]);
        }

        private void SwitchLanguageSimplifiedChinese(object sender, RoutedEventArgs e)
        {
            ((MainWindowViewModel)DataContext!).SwitchLanguage(LanguageZhCn);
        }
        
        private void SwitchLanguageEnglish(object sender, RoutedEventArgs e)
        {
            ((MainWindowViewModel)DataContext!).SwitchLanguage(LanguageEnUs);
        }

        private void LoadPdfMetadata(IStorageFile file)
        {
            ((MainWindowViewModel)DataContext!).OpenedFileName = file.Name;
            var path = file.Path.LocalPath;

            if (PdfReader.TestPdfFile(path) == 0)
            {
                // Not a PDF file. Popup error.
            }

            var pdfDocument = PdfReader.Open(path, PdfDocumentOpenMode.Modify);
        }
    }
}
