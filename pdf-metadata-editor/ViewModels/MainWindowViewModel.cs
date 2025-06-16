using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NSwag.Collections;
using PdfMetadataEditor.Lang;
using PdfSharp.Pdf;

namespace PdfMetadataEditor.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly LanguageManager _languageManager;
        private string _buttonTextOpenPdfFile = "";
        private string _buttonTextAddPdfMetadataPropertyValue = "";
        private string _buttonTextSavePdfFile = "";
        private string _buttonTextResetChanges = "";
        private string _labelTextKeywords = "";
        private string _labelTextAuthor = "";
        private string _labelTextSubject = "";
        private string _labelTextTitle = "";
        private string _labelTextPropertyName = "";
        private string _labelTextPropertyValue = "";

        private string _openedFileName = "";
        private bool _isFileOpened = false;
        private string _pdfInfoTitle = "";
        private string _pdfInfoSubject = "";
        private string _pdfInfoAuthor = "";
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

        public string ButtonTextSavePdfFile
        {
            get => _buttonTextSavePdfFile;
            set
            {
                if (_buttonTextSavePdfFile == value)
                {
                    return;
                }

                _buttonTextSavePdfFile = value;
                OnPropertyChanged();
            }
        }
        
        public string ButtonTextResetChanges
        {
            get => _buttonTextResetChanges;
            set
            {
                if (_buttonTextResetChanges == value)
                {
                    return;
                }

                _buttonTextResetChanges = value;
                OnPropertyChanged();
            }
        }
        
        public string ButtonTextAddPdfMetadataPropertyValue
        {
            get => _buttonTextAddPdfMetadataPropertyValue;
            set
            {
                if (_buttonTextAddPdfMetadataPropertyValue == value)
                {
                    return;
                }

                _buttonTextAddPdfMetadataPropertyValue = value;
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
        
        public string LabelTextPropertyName
        {
            get => _labelTextPropertyName;
            set
            {
                if (_labelTextPropertyName == value)
                {
                    return;
                }

                _labelTextPropertyName = value;
                OnPropertyChanged();
            }
        }
        
        public string LabelTextPropertyValue
        {
            get => _labelTextPropertyValue;
            set
            {
                if (_labelTextPropertyValue == value)
                {
                    return;
                }

                _labelTextPropertyValue = value;
                OnPropertyChanged();
            }
        }

        public string PdfInfoTitle
        {
            get => _pdfInfoTitle;
            set
            {
                if (_pdfInfoTitle == value)
                {
                    return;
                }

                _pdfInfoTitle = value;
                OnPropertyChanged();
            }
        }
        
        public string PdfInfoSubject
        {
            get => _pdfInfoSubject;
            set
            {
                if (_pdfInfoSubject == value)
                {
                    return;
                }

                _pdfInfoSubject = value;
                OnPropertyChanged();
            }
        }

        public string PdfInfoAuthor
        {
            get => _pdfInfoAuthor;
            set
            {
                if (_pdfInfoAuthor == value)
                {
                    return;
                }

                _pdfInfoAuthor = value;
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

        public ObservableDictionary<string, string> PdfMetadataList { get; } = [];

        public bool IsFileOpened
        {
            get => _isFileOpened;
            set
            {
                _isFileOpened = value;
                OnPropertyChanged();
            }
        }

        public void SwitchLanguage(string languageCode)
        {
            _languageManager.SwitchLanguage(languageCode);
            ReloadLocalizedTexts();
        }

        private void ReloadLocalizedTexts()
        {
            ButtonTextOpenPdfFile = _languageManager.GetString(LocalizationKeys.OpenPdfFile);
            ButtonTextAddPdfMetadataPropertyValue = _languageManager.GetString(LocalizationKeys.AddPdfMetadataPropertyValue);
            ButtonTextSavePdfFile = _languageManager.GetString(LocalizationKeys.SavePdfFile);
            ButtonTextResetChanges = _languageManager.GetString(LocalizationKeys.ResetChanges);
            LabelTextKeywords = _languageManager.GetString(LocalizationKeys.PdfInfoKeywords);
            LabelTextAuthor = _languageManager.GetString(LocalizationKeys.PdfInfoAuthor);
            LabelTextSubject = _languageManager.GetString(LocalizationKeys.PdfInfoSubject);
            LabelTextTitle = _languageManager.GetString(LocalizationKeys.PdfInfoTitle);
            LabelTextPropertyName = _languageManager.GetString(LocalizationKeys.LabelTextPropertyName);
            LabelTextPropertyValue = _languageManager.GetString(LocalizationKeys.LabelTextPropertyValue);
        }
    }
}
