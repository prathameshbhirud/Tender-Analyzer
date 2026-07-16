namespace TenderAnalyzer.Application.DTOs.Summary;

public class TenderSummaryDto
{
    public string Title { get; set; } = string.Empty;

    public string Organization { get; set; } = string.Empty;

    public string SubmissionDate { get; set; } = string.Empty;

    public string EmdAmount { get; set; } = string.Empty;

    public string EstimatedValue { get; set; } = string.Empty;

    public string Scope { get; set; } = string.Empty;

    public string EligibilityCriteria { get; set; } = string.Empty;
}