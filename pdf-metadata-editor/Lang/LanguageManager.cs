using System.Globalization;
using System.Resources;

namespace PdfMetadataEditor.Lang
{
    public class LanguageManager
    {
        private ResourceManager ResourceManager { get; } = Resources.ResourceManager;

        // CurrentUICulture returns the display language
        // while CurrentCulture returns the regional format
        private CultureInfo CurrentCulture { get; set; } = CultureInfo.CurrentUICulture;

        public string GetString(string key) => ResourceManager.GetString(key, CurrentCulture);

        public void SwitchLanguage(string languageCode)
        {
            CurrentCulture = new CultureInfo(languageCode);
        }
    }
}
