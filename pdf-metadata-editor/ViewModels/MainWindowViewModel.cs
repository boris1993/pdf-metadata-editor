using System.Collections.Generic;
using PdfMetadataEditor.Lang;

namespace PdfMetadataEditor.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly LanguageManager _languageManager;
        private string _openPDFFileButtonText;
        private string _openedFileName;
        
        public MainWindowViewModel()
        {
            _languageManager = new LanguageManager();
            OpenPdfFileButtonText = _languageManager.GetString("OpenFileText");
        }

        public string OpenedFileName
        {
            get => _openedFileName;
            set
            {
                if (_openedFileName == value)
                {
                    return;
                }
            
                _openedFileName = value;
                OnPropertyChanged();
            }
        }
        
        public string OpenPdfFileButtonText
        {
            get => _openPDFFileButtonText;
            set
            {
                if (_openPDFFileButtonText == value)
                {
                    return;
                }
                
                _openPDFFileButtonText = value;
                OnPropertyChanged();
            }
        }

        public void SwitchLanguage(string languageCode)
        {
            _languageManager.SwitchLanguage(languageCode);
            OpenPdfFileButtonText = _languageManager.GetString("OpenFileText");
        }
    }
}
