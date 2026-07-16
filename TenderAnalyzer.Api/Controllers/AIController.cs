using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TenderAnalyzer.AI.Clients;
using TenderAnalyzer.AI.Prompting;
using TenderAnalyzer.Application.DTOs.AI;

namespace TenderAnalyzer.Api.Controllers;

[ApiController]
[Route("api/ai")]
public class AIController : ControllerBase
{
    private readonly IOllamaClient _client;

    private readonly IPromptBuilder _promptBuilder;

    public AIController(IOllamaClient client, IPromptBuilder promptBuilder)
    {
        _client = client;
        _promptBuilder = promptBuilder;
    }

    [HttpPost("chat")]
    public async Task<ActionResult<ChatResponse>> Chat(ChatRequest request)
    {
        var sw = Stopwatch.StartNew();

        var response = await _client.GenerateAsync(request.Prompt);

        sw.Stop();

        return Ok(new ChatResponse
        {
            Response = response,
            ElapsedMilliseconds = sw.ElapsedMilliseconds
        });
    }

    [HttpPost("summarize")]
    public async Task<ActionResult<ChatResponse>> Summarize(ChatRequest request)
    {
        var sw = Stopwatch.StartNew();

        var prompt = _promptBuilder.BuildSummaryPrompt(request.Prompt);

        var response = await _client.GenerateAsync(prompt);

        sw.Stop();

        return Ok(new ChatResponse
        {
            Response = response,
            ElapsedMilliseconds = sw.ElapsedMilliseconds
        });
    }

    [HttpPost("extract-json")]
    public async Task<ActionResult<ChatResponse>> ExtractJSON(ChatRequest request)
    {
        var sw = Stopwatch.StartNew();

        var prompt = _promptBuilder.BuildJsonExtractionPrompt(request.Prompt);

        var response = await _client.GenerateAsync(prompt);

        sw.Stop();

        return Ok(new ChatResponse
        {
            Response = response,
            ElapsedMilliseconds = sw.ElapsedMilliseconds
        });
    }

    [HttpPost("extract-fields")]
public async Task<ActionResult<ChatResponse>> ExtractFields([FromBody] ExtractFieldsRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Text))
        {
            return BadRequest("Text is required.");
        }

        if (request.Fields == null || request.Fields.Count == 0)
        {
            return BadRequest("At least one field is required.");
        }

        var sw = Stopwatch.StartNew();

        var prompt = _promptBuilder.BuildFieldExtractionPrompt(request.Text, request.Fields);

        var response = await _client.GenerateAsync(prompt, cancellationToken);

        sw.Stop();

        return Ok(new ChatResponse
        {
            Response = response,
            ElapsedMilliseconds = sw.ElapsedMilliseconds
        });
    }
}
