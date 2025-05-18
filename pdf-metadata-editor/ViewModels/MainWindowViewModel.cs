using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PdfMetadataEditor.Lang;
using PdfSharp.Pdf;

namespace PdfMetadataEditor.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly LanguageManager _languageManager;
        private string _buttonTextOpenPdfFile = "";
        private string _labelTextKeywords = "";
        private string _labelTextAuthor = "";
        private string _labelTextSubject = "";
        private string _labelTextTitle = "";

        private string _openedFileName = "";
        private string _pdfInfoKeywords = "";

        public MainWindowViewModel()
        {
            _languageManager = new LanguageManager();
            ReloadLocalizedTexts();
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

        public string ButtonTextOpenPdfFile
        {
            get => _buttonTextOpenPdfFile;
            set
            {
                if (_buttonTextOpenPdfFile == value)
                {
                    return;
                }

                _buttonTextOpenPdfFile = value;
                OnPropertyChanged();
            }
        }

        public string LabelTextKeywords
        {
            get => _labelTextKeywords;
            set
            {
                if (_labelTextKeywords == value)
                {
                    return;
                }

                _labelTextKeywords = value;
                OnPropertyChanged();
            }
        }

        public string LabelTextAuthor
        {
            get => _labelTextAuthor;
            set
            {
                if (_labelTextAuthor == value)
                {
                    return;
                }

                _labelTextAuthor = value;
                OnPropertyChanged();
            }
        }

        public string LabelTextSubject
        {
            get => _labelTextSubject;
            set
            {
                if (_labelTextSubject == value)
                {
                    return;
                }

                _labelTextSubject = value;
                OnPropertyChanged();
            }
        }

        public string LabelTextTitle
        {
            get => _labelTextTitle;
            set
            {
                if (_labelTextTitle == value)
                {
                    return;
                }

                _labelTextTitle = value;
                OnPropertyChanged();
            }
        }

        public string PdfInfoKeywords
        {
            get => _pdfInfoKeywords;
            set
            {
                if (_pdfInfoKeywords == value)
                {
                    return;
                }

                _pdfInfoKeywords = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PdfMetadata> PdfMetadataList { get; set; } = [];

        public void SwitchLanguage(string languageCode)
        {
            _languageManager.SwitchLanguage(languageCode);
            ReloadLocalizedTexts();
        }

        private void ReloadLocalizedTexts()
        {
            ButtonTextOpenPdfFile = _languageManager.GetString(LocalizationKeys.OpenPdfFile);
            LabelTextKeywords = _languageManager.GetString(LocalizationKeys.PdfInfoKeywords);
            LabelTextAuthor = _languageManager.GetString(LocalizationKeys.PdfInfoAuthor);
            LabelTextSubject = _languageManager.GetString(LocalizationKeys.PdfInfoSubject);
            LabelTextTitle = _languageManager.GetString(LocalizationKeys.PdfInfoTitle);
        }
    }
}
