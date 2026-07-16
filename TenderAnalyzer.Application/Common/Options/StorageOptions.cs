namespace TenderAnalyzer.Application.Common.Options;

public class StorageOptions
{
    public const string SectionName = "Storage";

    public string RootPath { get; set; } = "storage";

    public string TenderFolder { get; set; } = "tenders";
}