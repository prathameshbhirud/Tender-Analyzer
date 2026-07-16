using Microsoft.AspNetCore.Mvc;
using TenderAnalyzer.Application.Abstractions.AI;

namespace TenderAnalyzer.Api.Controllers;

[ApiController]
[Route("api/summary")]
public class SummaryController : ControllerBase
{
    private readonly ISummaryGenerator _generator;

    public SummaryController(ISummaryGenerator generator)
    {
        _generator = generator;
    }

    [HttpGet("test")]
    public async Task<IActionResult> Test()
    {
        var result = await _generator.GenerateSummaryAsync(
                """
                Explain what a government tender is in simple terms.
                """
            );

        return Ok(result);
    }

    [HttpGet("prompt-test")]
    public async Task<IActionResult> PromptTest()
    {
        var prompt = """
        Analyze the following tender and return JSON only.

        {
        "title":"",
        "organization":"",
        "submissionDate":""
        }

        Tender:

        Construction of internal roads at industrial estate.
        EMD Amount: ₹50,000.
        Last date of submission: 15-Aug-2026.
        """;

        var result = await _generator.GenerateSummaryAsync(prompt);

        return Ok(result);
    }

    [HttpGet("raw-ollama")]
    public async Task<IActionResult> RawOllama()
    {
        using var client = new HttpClient();

        var request = new
        {
            model = "phi3:mini",
            prompt = "Say hello",
            stream = false
        };

        var response = await client.PostAsJsonAsync("http://localhost:11434/api/generate", request);

        var result = await response.Content.ReadAsStringAsync();

        return Ok(result);
    }
}