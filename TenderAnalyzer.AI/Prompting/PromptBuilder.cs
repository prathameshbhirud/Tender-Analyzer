namespace TenderAnalyzer.AI.Prompting;

public class PromptBuilder : IPromptBuilder
{
    public string BuildSummaryPrompt(string text)
    {
        return
            $"""
            Summarize the following document.

            Maximum 100 words.

            {text}
            """;
    }

    public string BuildJsonExtractionPrompt(string text)
    {
        return
            $$$"""
            Return ONLY valid JSON.

            {{
                "title":"",
                "organization":""
            }}

            {text}
            """;
    }

    public string BuildFieldExtractionPrompt(string text, IEnumerable<string> fields)
    {
        var fieldList = string.Join(
            Environment.NewLine,
            fields.Select(f => $"- {f}"));

        return $"""
                You are an expert information extraction assistant.

                Extract ONLY the requested fields.

                If a value is not present,
                return an empty string.

                Return ONLY valid JSON.

                Fields:

                {fieldList}

                Document:

                {text}
                """;
    }
}