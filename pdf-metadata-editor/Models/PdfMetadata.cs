namespace PdfMetadataEditor.Models
{
    public class PdfMetadata(string key, string value)
    {
        public string Key { get; set; } = key;
        public string Value { get; set; } = value;
    }
}
