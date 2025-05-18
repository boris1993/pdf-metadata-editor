using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using PdfMetadataEditor.ViewModels;

namespace PdfMetadataEditor.Views
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private async void OpenFileButtonClicked(object sender, RoutedEventArgs e)
        {
            var topLevel = GetTopLevel(this);
            var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Open PDF file",
                AllowMultiple = false,
                FileTypeFilter = new List<FilePickerFileType>([FilePickerFileTypes.Pdf]),
            });

            if (files.Count != 1)
            {
                // Popup error. This shouldn't happen.
            }

            var file = files[0];
            ((MainWindowViewModel)DataContext!).OpenedFileName = file.Name;
        }

        private void SwitchLanguageButtonClicked(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel viewModel)
            {
                viewModel.SwitchLanguage("zh-CN");
            }
        }
    }
}
