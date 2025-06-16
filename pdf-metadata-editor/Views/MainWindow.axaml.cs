using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        private static readonly string[] StandardProperties =
        [
            "/Title",
            "/Subject",
            "/Author",
            "/Keywords",
            "/Creator",
            "/CreationDate",
            "/Producer",
            "/ModDate",
        ];

        private string? _openedFilePath;
        private PdfDocument? _pdfDocument;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void OpenFileButtonClicked(object sender, RoutedEventArgs e)
        {
            var filePickerOptions = new FilePickerOpenOptions
            {
                Title = ((MainWindowViewModel)DataContext!).ButtonTextOpenPdfFile,
                AllowMultiple = false,
                FileTypeFilter = new List<FilePickerFileType>([FilePickerFileTypes.Pdf]),
            };

            var topLevel = GetTopLevel(this);
            var files = topLevel!.StorageProvider.OpenFilePickerAsync(filePickerOptions).Result;

            if (files.Count != 1)
            {
                // Nothing selected. Nothing opened.
                return;
            }

            using var fileOpened = files[0];
            _openedFilePath = fileOpened.Path.LocalPath;
            ((MainWindowViewModel)DataContext!).OpenedFileName = fileOpened.Name;
            LoadPdfMetadata(_openedFilePath);
        }

        private void SaveFileButtonClicked(object sender, RoutedEventArgs e)
        {
            if (_pdfDocument == null || _openedFilePath == null)
            {
                // Popup error. This shouldn't happen.
                return;
            }

            var topLevel = GetTopLevel(this);
            var file = topLevel!.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
                {
                    Title = ((MainWindowViewModel)DataContext!).ButtonTextSavePdfFile,
                    FileTypeChoices = [FilePickerFileTypes.Pdf],
                })
                .Result;

            if (file == null)
            {
                // Nothing selected. Nothing saved.
                return;
            }

            var path = file.Path.LocalPath;
            if (path == _openedFilePath)
            {
                _pdfDocument = PdfReader.Open(path, PdfDocumentOpenMode.Modify);
                // Update the properties
                _pdfDocument.Close();
            }
            else
            {
                _pdfDocument = PdfReader.Open(_openedFilePath, PdfDocumentOpenMode.Modify);
                // Update the properties
                _pdfDocument.Save(path);
            }
        }

        private void ResetChangesButtonClicked(object sender, RoutedEventArgs e)
        {
            if (_openedFilePath == null)
            {
                return;
            }

            LoadPdfMetadata(_openedFilePath);
        }

        private void SwitchLanguageSimplifiedChinese(object sender, RoutedEventArgs e)
        {
            ((MainWindowViewModel)DataContext!).SwitchLanguage(LanguageZhCn);
        }

        private void SwitchLanguageEnglish(object sender, RoutedEventArgs e)
        {
            ((MainWindowViewModel)DataContext!).SwitchLanguage(LanguageEnUs);
        }

        private void LoadPdfMetadata(string path)
        {
            if (PdfReader.TestPdfFile(path) == 0)
            {
                // Not a PDF file. Popup error.
            }

            _pdfDocument = PdfReader.Open(path, PdfDocumentOpenMode.Import);

            var mainWindowViewModel = (MainWindowViewModel)DataContext!;
            mainWindowViewModel.PdfInfoTitle = _pdfDocument.Info.Title;
            mainWindowViewModel.PdfInfoSubject = _pdfDocument.Info.Subject;
            mainWindowViewModel.PdfInfoAuthor = _pdfDocument.Info.Author;
            mainWindowViewModel.PdfInfoKeywords = _pdfDocument.Info.Keywords;

            _pdfDocument.Info
                .Where(info => !StandardProperties.Contains(info.Key))
                .ToList()
                .ForEach(metadata => mainWindowViewModel.PdfMetadataList[metadata.Key] = metadata.Value?.ToString() ?? "");

            mainWindowViewModel.IsFileOpened = true;
        }
    }
}
